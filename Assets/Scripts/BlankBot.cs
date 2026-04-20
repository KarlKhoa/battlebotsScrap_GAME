using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class BlankBot : MonoBehaviour
{
    public float health;
     public float generalSpeed;
     public float rotationSpeed;

     public float weight;
     public float traction;
   

   //use in future instad of in BotConstructor
     public GameObject attachment1;
     public GameObject attachment2;
     public GameObject attachment3;
     public GameObject attachment4;

     public BlankBot(float botHealth, float botGSpeed, float botRSpeed, float botWeight, float botTraction)
     {
        health = botHealth;
        generalSpeed = botGSpeed;
        rotationSpeed = botRSpeed;
        weight = botWeight;
        traction = botTraction;
     }

}
