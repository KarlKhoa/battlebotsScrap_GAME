using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPointManager : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] public int playerCount;
    //[SerializeField] public int playerIndex {  get; }



    //wrapping for instantiate
    //public static PlayerInput Instantiate(GameObject prefab, int playerIndex = -1, string controlScheme = null, int splitScreenIndex = -1, InputDevice pairWithDevice = null)
    //{
    //    //
    //}

    void Start()
    {
        
    }

    //Spawn player input clients on new controller input
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        //position of new client = position of transform at current playerCount number in array
        playerInput.transform.position = spawnPoints[playerCount].transform.position;
        playerCount++;

        //playerInput.playerIndex++; //read only

    }

    public void Update()
    {
        
    }
}
