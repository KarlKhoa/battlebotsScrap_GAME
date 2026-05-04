using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gun : Weapon 
{
    public Projectile bulletPrefab;
    private GameObject m_bulletSpawned;

    private Weapon m_bulletScript;


    void Awake()
    {

    }


    public override void Fire(Vector3 pos, Quaternion rot)
    {
        var bullet = Instantiate(bulletPrefab.gameObject, pos, rot); //iterates a bullet at position of gun in WeaponController
        bullet.GetComponent<Projectile>().Owner = Owner; //makes bullet's Owner same as our client
    }
}
