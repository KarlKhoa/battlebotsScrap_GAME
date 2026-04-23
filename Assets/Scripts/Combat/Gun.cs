using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gun : Weapon 
{
    public GameObject bulletPrefab;
    public GameObject weaponController;

    //private PlayerInput playerInput;

    public override void Fire(Vector3 pos, Quaternion rot)
    {
        //link to playerIndex somehow
        Instantiate(bulletPrefab, pos, rot); //iterates a bullet at position of gun in WeaponController
        //bulletPrefab.bulletID = playerInput.playerIndex; //returns error/ could not be found (do this properly later)
    }
}
