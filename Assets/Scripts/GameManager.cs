using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public WeaponRegistry WeaponsRegistry;

    public Transform[] spawnPoints;

    //public int playerIndex { get; } //unique zero-based player index. assign to each player + keep track

    private void Awake() 
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

}
