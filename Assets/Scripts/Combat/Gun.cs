using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon 
{
    public GameObject bulletPrefab;
    public override void Fire()
    {
        Instantiate(bulletPrefab);
        Debug.Log("cooldown:"+cooldownTime); //gun firing code here
    }
}
