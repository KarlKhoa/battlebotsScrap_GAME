using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPointManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Transform[] spawnPoints;

    private int playerCount; //counts how many players have joined to determine where to put them


    void Start()
    {
        
    }

    //Spawn player input clients on new controller input
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        //position of new client = position of transform at current playerCount number in array
        playerInput.transform.position = spawnPoints[playerCount].transform.position;
        playerCount++;

    }

    public void Update()
    {
        
    }
}
