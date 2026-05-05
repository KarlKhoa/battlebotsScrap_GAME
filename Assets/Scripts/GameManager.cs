using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public WeaponRegistry WeaponsRegistry;

    public List<GameObject> c_players;

    public GameObject menus;

    private MenuManager menuManager;
    [SerializeField] private WeaponSelectManager weaponSelectManager;

    //public Transform[] spawnPoints;

    private int rounds = 3;

    private int roundCount;

    //
    public int savedPlayerCount;

    public int livePlayerCount;

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

    public void AddPlayerCount()
    {
        savedPlayerCount++;
    }

    public void MinusPlayerCount()
    {
        savedPlayerCount--;
    }

    public void LastPlayerCheck(bool isLastPlayer = false)
    {
        livePlayerCount--;
        //on death the bots will call this function, which will check if the this bot is the last bot, by minusing the amount whenever a bot dies, until it hits one (the last playar)
        if(livePlayerCount <= 1 && isLastPlayer == false)
        {
            EndRound();
        }
    }
    
    public int ScorePoints()
    {
        int maxPlayers = 5;
        return maxPlayers - livePlayerCount;
    }

    public void EndRound()
    {
        for(int i = 0; i < c_players.Count; i++)
        {
            if(c_players[i].GetComponentInChildren<PlayerController>() != null)
            {
                c_players[i].GetComponentInChildren<PlayerController>().Die(true);
            }
        }
        
        c_players.Sort(SortByPlayerScore);
        for(int i = 0; 1 < c_players.Count; i++)
        {
            Debug.Log(c_players[i].GetComponent<BotSpawner>().playerScore);
        }

        BeginWeaponSelectionSequence();
    }

    private void BeginWeaponSelectionSequence()
    {
        weaponSelectManager.WeaponSelectionSequence();
    }

    public void StartRound()
    {
        for(int i = 0; i < savedPlayerCount; i++)
        {
            c_players[i].GetComponent<BotSpawner>().SpawnRequest();
        }
        
        roundCount++;
        livePlayerCount = savedPlayerCount;
    }

    public void ReturnClient(GameObject player)
    {
        c_players.Add(player);
    }

    private int SortByPlayerScore(GameObject gameObject1, GameObject gameObject2)
    {
        return gameObject1.GetComponent<BotSpawner>().playerScore.CompareTo(gameObject2.GetComponent<BotSpawner>().playerScore);
    }

}
