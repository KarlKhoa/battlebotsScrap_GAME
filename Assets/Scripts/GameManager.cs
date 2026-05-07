using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public WeaponRegistry WeaponsRegistry;

    public List<Client> registeredClients;

    public GameObject menus;
    public GameObject firstSelectedWeaponUI; //store this so we can force users to select the correct UI component when reenabling UI controls - MEL
    private MenuManager menuManager;
    [SerializeField] private WeaponSelectManager weaponSelectManager;

    //public Transform[] spawnPoints;

    public int rounds = 3;

    public int roundCount;

    public List<PlayerController> ActivePlayers = new();

    //public int playerIndex { get; } //unique zero-based player index. assign to each player + keep track

    private void Awake() 
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        //on start this will set the live player count to the saved playercount, this should be changed later to do this at the start of every round so we can get a freshed reset clock every round
        menuManager = menus.GetComponent<MenuManager>();
    }

    public void OnPlayerDeath(PlayerController player)
    {
        if (ActivePlayers.Contains(player))
            ActivePlayers.Remove(player);
        
        if(ActivePlayers.Count <= 1)
            EndRound();
    }
    
    
    public int ScorePoints()
    {
        int maxPlayers = 5;
        return maxPlayers - ActivePlayers.Count;
    }

    public void EndRound()
    {
        if(roundCount >= rounds)
        {
            EndGame();
        }
        else
        {
            for(int i = 0; i < registeredClients.Count; i++)
            {
                if(registeredClients[i].livePlayer)
                {
                    if(registeredClients[i].livePlayer.IsAlive)
                        registeredClients[i].AddPoints(ScorePoints()); //hack to add points to last remaining player
                    Destroy(registeredClients[i].livePlayer.gameObject);
                }
            }
        
            registeredClients.Sort(SortByPlayerScore);

            BeginWeaponSelectionSequence();
        }
        ActivePlayers.Clear();
    }

    private void BeginWeaponSelectionSequence()
    {
        weaponSelectManager.WeaponSelectionSequence();
    }

    public void StartRound()
    {
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
    }
    private void EndGame()
    {
        registeredClients.Sort(SortByPlayerScore);
        registeredClients.Reverse();
        Debug.Log(registeredClients[0] + "has won");
    }

}
