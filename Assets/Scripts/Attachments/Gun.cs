using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon 
{
    public GameObject bulletPrefab;
    public GameObject weaponController;

    public override void Fire(Vector3 pos, Quaternion rot)
    {
        Instantiate(bulletPrefab, pos, rot); //iterates a bullet at position of gun in WeaponController
    }
}
