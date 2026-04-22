using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class BlankBot : MonoBehaviour
{
     public float health;
     public float genSpeed;
     public float rotSpeed;
     public float weight;
     public float traction;

     public int playerID;
   

   //use in future instad of in BotConstructor
     public GameObject attachment1;
     public GameObject attachment2;
     public GameObject attachment3;
     public GameObject attachment4;

     public BlankBot(float botHealth, float botGenSpeed, float botRotSpeed, float botWeight, float botTraction, int botID)
     {
        health = botHealth;
        genSpeed = botGenSpeed;
        rotSpeed = botRotSpeed;
        weight = botWeight;
        traction = botTraction;
        playerID = botID;
     }

}
