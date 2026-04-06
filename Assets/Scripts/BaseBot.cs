using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseBot : IBot
{
    public float health;
     public float generalSpeed;
     public float rotationSpeed;

     public float weight;
     public float traction;

     public int attachment1;
     public int attachment2;
     public int attachment3;
     public int attachment4;

     public BaseBot(float botHealth, float botGSpeed, float botRSpeed, float botWeight, float botTraction, int botAttachment1, int botAttachment2, int botAttachment3, int botAttachment4)
     {
        health = botHealth;
        generalSpeed = botGSpeed;
        rotationSpeed = botRSpeed;
        weight = botWeight;
        traction = botTraction;
        attachment1 = botAttachment1;
        attachment2 = botAttachment2;
        attachment3 = botAttachment3;
        attachment4 = botAttachment4;
     }

   public virtual void Move()
   {

   }
   public virtual void Turn()
   {

   }

    public virtual void Activate1()
    {

    }
    public virtual void Activate2()
    {

    }
    public virtual void Activate3()
    {

    }
    public virtual void Activate4()
    {

    }

    public virtual void TakeDamage()
    {

    }
    public virtual void Die()
    {

    }
}
