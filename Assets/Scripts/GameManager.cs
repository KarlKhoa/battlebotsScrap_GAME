using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public WeaponRegistry WeaponsRegistry;

    public Transform[] spawnPoints;

    private int rounds = 3;

    private int roundCount;

    //
    public int savedPlayerCount;

    private int livePlayerCount;

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
        livePlayerCount = savedPlayerCount;
    }

    public void AddPlayerCount()
    {
        savedPlayerCount++;
    }

    public void MinusPlayerCount()
    {
        savedPlayerCount--;
    }

    public void LastPlayerCheck()
    {
        //on death the bots will call this function, which will check if the this bot is the last bot, by minusing the amount whenever a bot dies, until it hits one (the last playar)
        if(livePlayerCount <= 1)
        {
            EndRound();
        }
        else
        {
            livePlayerCount--;
        }
    }
    
    public int ScorePoints()
    {
        int maxPlayers = 4;
        return maxPlayers - livePlayerCount;
    }

    public void EndRound()
    {
        Debug.Log("Game Over Man");
    }

}
