using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon : MonoBehaviour 
{
    public float cooldownTime;
    public float lastFired = -9999f;
    public int baseDamage;
    public bool isGun;
    //put bullet here
    public GameObject bullet;

    private GameObject thisObject;
    
    void Start() 
    {
            
    }

    public virtual void Fire()
    {
        if (isGun == true)
        {
            Instantiate(bullet);
        }
        else if( this == enabled)
        {

        }

    }
}
