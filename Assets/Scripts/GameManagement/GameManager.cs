using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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
    public GameObject firstSelectRestartUI;
    public MenuManager menuManager;
    [SerializeField] private WeaponSelectManager weaponSelectManager;
    [SerializeField] private GameEndUIManager gameEndUIManager;
    [SerializeField] private ConfirmStartArea _welcomeMat;
    [SerializeField] private PlayerVisualManager _playerVisualsManager;

    public float lobbyCountdownDuration = 5;
    public float roundCountdownDuration = 4;
    private float _currentLobbyCountdownDuration;
    private float _currentRoundCountdownDuration;
    public int rounds = 3;
    public int roundCount;

    public bool CanStartGameWithOnePlayer = true;
    public bool isLobbyOver = false;
    private bool hasSelectionStarted;
    private bool _isDoingStartCountdown;
    //private bool _isDoingRoundCountdown = false;
    public static bool hasGameStartedYet = false;

    [SerializeField] private PlayerInputManager playerInputManager;
    
    private Coroutine _startLobbyCountdown;
    private Coroutine _startBeginRoundCountdown;

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

    private IEnumerator LobbyCountdown()
    {
        _currentLobbyCountdownDuration = lobbyCountdownDuration;
        menuManager.ToggleTransitionUI(true);
        menuManager.transition.SetTransitionTitle("Game Starts In...");
        menuManager.transition.UpdateCountdownTimer(_currentLobbyCountdownDuration);
        while (_currentLobbyCountdownDuration > 0)
        {
            _currentLobbyCountdownDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            menuManager.transition.UpdateCountdownTimer(_currentLobbyCountdownDuration + 1);
        }
        StartGame();
        menuManager.ToggleTransitionUI(false);
        _welcomeMat.gameObject.SetActive(false);
        _welcomeMat.playersOnMe = 0;
    }

    public void StartRoundCountdown()
    {
        StartCoroutine(RoundStartCountdown());
    }

    private IEnumerator RoundStartCountdown()
    {
        //_isDoingRoundCountdown = true;
        _currentRoundCountdownDuration = roundCountdownDuration;
        menuManager.ToggleTransitionUI(true);
        menuManager.transition.SetTransitionTitle($"Round {roundCount}/{rounds} starts in...");
        menuManager.transition.UpdateCountdownTimer(_currentRoundCountdownDuration);
        while (_currentRoundCountdownDuration > 0)
        {
            _currentRoundCountdownDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (_currentRoundCountdownDuration <= 1)
                menuManager.transition.SetTransitionBody("SCRAP!");
            else
                menuManager.transition.UpdateCountdownTimer(_currentRoundCountdownDuration);
        }

        //_isDoingRoundCountdown = false;
        menuManager.ToggleTransitionUI(false);
        StartRound();
    }

    private IEnumerator RoundEndSequence(Client client, int currentRound, int totalRounds)
    {
        menuManager.ToggleTransitionUI(true);
        menuManager.transition.SetTransitionTitle($"Round {currentRound}/{totalRounds} over!");
        menuManager.transition.SetTransitionBody($"{client.gameObject.name} wins!");
        yield return new WaitForSeconds(3f);
        menuManager.ToggleTransitionUI(false);
        ScorePointsForLivingPlayers();
        DestroyAllPlayers();
        if (roundCount >= rounds)
        {
            EndGame();
        }
        else
        {
            if (!hasSelectionStarted)
            {
                hasSelectionStarted = true;
            }

            BeginWeaponSelectionSequence();
        }
        
        ActivePlayers.Clear();
    }

    public void StopGameCountdown()
    {
        if (_isDoingStartCountdown)
        {
            _isDoingStartCountdown = false;
            if (_startLobbyCountdown != null)
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
        StartCoroutine(RoundEndSequence(ActivePlayers[0].Owner, roundCount, rounds));
    }

    private void BeginWeaponSelectionSequence()
    {
        ActivePlayers.Clear();
        weaponSelectManager.WeaponSelectionSequence();
    }

    public void StartRound()
    {
        /*//put timer for transition screen here/if not relocating to after bind
        StartCoroutine(RoundStartCountdown());*/
        SpawnPlayersInRound();
        roundCount++;
    }

    private void ScorePointsForLivingPlayers()
    {
        foreach (var client in registeredClients)
        {
            if (!client.livePlayer || !client.livePlayer.IsAlive) continue;
            client.AddPoints(ScorePoints());
        }
    }

    private void DestroyAllPlayers()
    {
        foreach (var client in registeredClients)
        {
            if (!client.livePlayer) continue;
            Destroy(client.livePlayer.gameObject);
        }
    }

    private void SpawnPlayersInRound()
    {
        hasSelectionStarted = false;
        for (int i = 0; i < registeredClients.Count; i++)
        {
            registeredClients[i].SpawnRequest();
        }
    }


    public void RegisterClient(Client client)
    {
        registeredClients.Add(client);
    }

    public void RegisterPlayer(PlayerController player)
    {
        ActivePlayers.Add(player);
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
        playerInputManager.DisableJoining();
        BeginWeaponSelectionSequence();
        hasGameStartedYet = true;
    }
    private void EndGame()
    {
        menuManager.ToggleGameEndUI(true);
        gameEndUIManager.WinningPlayer(ClientsByScoreAscending[registeredClients.Count - 1]);
        foreach (var Client in registeredClients)
        {
            Debug.Log(Client.playerScore);
            Client.ToggleUIAccess(true, firstSelectRestartUI);
        }
        //set the first selected game object to the first button
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}

