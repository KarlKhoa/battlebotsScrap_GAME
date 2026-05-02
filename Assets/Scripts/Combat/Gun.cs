using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gun : Weapon 
{
    public GameObject bulletPrefab;
    private GameObject m_bulletSpawned;

    public bool isBulletDetonate = true;
    public bool hasBulletDetonate = false;

    private Weapon m_bulletScript;


    void Awake()
    {
        //meant to give bullet script the same ID as this Gun but currently gives bullets the last instance ID.
        //Maybe if we only instantiate bullets at the start and just teleport them around idfk
        m_bulletScript = bulletPrefab.GetComponent<Weapon>();
        m_bulletScript.weaponID = weaponID;
    }


    public override void Fire(Vector3 pos, Quaternion rot)
    {
        //checks if bullet is detonatable
        if(isBulletDetonate == true)
        {
            //checks if the bullet has already detonated
            if(hasBulletDetonate == true)
            {
                //cooldown

                hasBulletDetonate = false;
            }
            //if not, it will activate the fire script on the weapon (detonating it)
            else
            {
                //Instantiate(bulletPrefab, pos, rot); //iterates a bullet at position of gun in WeaponController
                m_bulletScript.Fire(pos,rot);
                hasBulletDetonate = true;
            }
        }
        else
        {
            Instantiate(bulletPrefab, pos, rot); //iterates a bullet at position of gun in WeaponController
        }
    }
}
