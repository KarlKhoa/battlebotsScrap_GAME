using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Linq;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}
    public PlayerVisualManager PlayerVisuals => _playerVisualsManager; 
    public WeaponRegistry WeaponsRegistry;
    public List<Client> registeredClients;
    public List<Client> ClientsByScoreAscending => registeredClients.OrderBy(_ => _.playerScore).ToList();
    public List<PlayerController> ActivePlayers = new();
    public GameObject menus;
    public GameObject firstSelectedWeaponUI; //store this so we can force users to select the correct UI component when reenabling UI controls - MEL
    public MenuManager menuManager;
    [SerializeField] private WeaponSelectManager weaponSelectManager;
    [SerializeField] private GameEndUIManager gameEndUIManager;
    [SerializeField] private ConfirmStartArea _welcomeMat;
    [SerializeField] private PlayerVisualManager _playerVisualsManager;

    public float StartGameCountdownDurationSeconds = 5;
    public int rounds = 3;
    public int roundCount;

    public bool CanStartGameWithOnePlayer = true;
    public bool isLobbyOver = false;
    public static bool hasGameStartedYet = false;
    
    
    private Coroutine _startLobbyCountdown;
    private bool hasSelectionStarted;
    private bool _isDoingStartCountdown;
    private float _startLobbyCountdownCurrentDuration;

    private void Awake() 
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        menuManager = menus.GetComponent<MenuManager>();
    #if !UNITY_EDITOR
        CanStartGameWithOnePlayer = false;
    #endif
    }
    
  
    public void StartGameCountdown()
    {
        if(!_isDoingStartCountdown)
        {
            _isDoingStartCountdown = true;
            _startLobbyCountdown = StartCoroutine(LobbyCountdown());
        }
    }

    public IEnumerator LobbyCountdown()
    {
        _startLobbyCountdownCurrentDuration = StartGameCountdownDurationSeconds;
        menuManager.ToggleTransitionUI(true);
        menuManager.transition.SetTransitionTitle("Game Starts In...");
        while(_startLobbyCountdownCurrentDuration > 0)
        {
            menuManager.transition.UpdateCountdownTimer(_startLobbyCountdownCurrentDuration);
            yield return new WaitForEndOfFrame();
            _startLobbyCountdownCurrentDuration -= Time.deltaTime;
        }
        StartGame();
        menuManager.ToggleTransitionUI(false);
        _welcomeMat.gameObject.SetActive(false);
        _welcomeMat.playersOnMe = 0;
    }

    public void StopGameCountdown()
    {
        if(_isDoingStartCountdown)
        {
            _isDoingStartCountdown = false;
            if(_startLobbyCountdown != null)
                StopCoroutine(_startLobbyCountdown);
            menuManager.ToggleTransitionUI(false);
        }
    }
    
    

    public void OnPlayerDeath(PlayerController player)
    {
        if (ActivePlayers.Contains(player))
        {
            Debug.Log("player removed");
            ActivePlayers.Remove(player);
        }
        
        if(ActivePlayers.Count <= 1)
        {
            Debug.Log("Round Ended");
            EndRound();
        }
    }
    
    
    public int ScorePoints()
    {
        int maxPlayers = 5;
        return maxPlayers - ActivePlayers.Count;
    }

    public void EndRound()
    {
        menuManager.ToggleTransitionUI(true);
        StartCoroutine(menuManager.transition.EndOfRoundTransitionSequence(ActivePlayers[0].GetComponent<Client>(), roundCount, rounds));
        if(roundCount >= rounds)
        {
            EndGame();
        }
        else
        {
            if(hasSelectionStarted == false)
        {
            hasSelectionStarted = true;
            for(int i = 0; i < registeredClients.Count; i++)
            {
                if(registeredClients[i].livePlayer)
                {
                    if(registeredClients[i].livePlayer.IsAlive)
                        registeredClients[i].AddPoints(ScorePoints()); //hack to add points to last remaining player
                    Destroy(registeredClients[i].livePlayer.gameObject);
                }
            }

            BeginWeaponSelectionSequence();
        }
        }
        ActivePlayers.Clear();
    }

    private void BeginWeaponSelectionSequence()
    {
        ActivePlayers.Clear();
        weaponSelectManager.WeaponSelectionSequence();
    }

    public void StartRound()
    {
        hasSelectionStarted = false;
        //put timer for transition screen here/if not relocating to after bind
        menuManager.ToggleTransitionUI(true);
        StartCoroutine(menuManager.transition.StartOfRoundTransitionSequence(roundCount, rounds));
        for(int i = 0; i < registeredClients.Count; i++)
        {
            registeredClients[i].SpawnRequest();
        }
        
        roundCount++;
    }

    public void RegisterClient(Client client)
    {
        registeredClients.Add(client);
    }

    public void RegisterPlayer(PlayerController player)
    {
        ActivePlayers.Add(player);
    }
    
    private int SortByPlayerScore(Client client1, Client client2)
    {
        return client1.playerScore.CompareTo(client2.playerScore);
    }

    public void StartGame()
    {
        foreach(var player in registeredClients)
        {
            if(player.GetComponentInChildren<PlayerController>() != null)
            {
                player.GetComponentInChildren<PlayerController>().FirstDieToStart();
            }
        }
        BeginWeaponSelectionSequence();
        hasGameStartedYet = true;
    }
    private void EndGame()
    {
        var orderedClients = ClientsByScoreAscending;
        gameEndUIManager.WinningPlayer(registeredClients[orderedClients.Count - 1]);
        menuManager.ToggleGameEndUI(true);
    }

}
