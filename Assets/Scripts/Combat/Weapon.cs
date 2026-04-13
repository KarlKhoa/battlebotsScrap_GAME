using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon : MonoBehaviour 
{
    public float cooldownTime;
    public float lastFired = -9999f;
    public int baseDamage;
    //put bullet here
    public GameObject bullet;
    

    public virtual void Fire(){}
}
