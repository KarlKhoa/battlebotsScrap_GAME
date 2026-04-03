using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bot
{
    public float health;
     public float generalSpeed;
     public float rotationSpeed;

     public float weight;
     public float traction;

     public int weapon1;
     public int weapon2;
     public int weapon3;
     public int weapon4;

     public Bot(float botHealth, float botGSpeed, float botRSpeed, float botWeight, float botTraction, int botWeapon1, int botWeapon2, int botWeapon3, int botWeapon4)
     {
        health = botHealth;
        generalSpeed = botGSpeed;
        rotationSpeed = botRSpeed;
        weight = botWeight;
        traction = botTraction;
        weapon1 = botWeapon1;
        weapon2 = botWeapon2;
        weapon3 = botWeapon3;
        weapon4 = botWeapon4;
     }
}
