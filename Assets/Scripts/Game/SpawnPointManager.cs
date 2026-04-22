using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPointManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public int playerCount;

    //Spawn player input clients on new controller input
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        //position of new client = position of transform at current playerCount number in array
        playerInput.transform.position = spawnPoints[playerCount].transform.position;
        playerCount++;

    }
}
