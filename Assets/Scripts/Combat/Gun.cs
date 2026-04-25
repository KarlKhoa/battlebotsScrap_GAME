using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gun : Weapon 
{
    public GameObject bulletPrefab;
    public GameObject weaponController;

    public bool isBulletDetonate;
    public bool hasBulletDetonate;

    private GameObject m_bulletSpawned;
    private Bullet m_bulletScript;

    public int playerIndex { get; }


    //private PlayerInput playerInput;

    public override void Fire(Vector3 pos, Quaternion rot)
    {
        //checks if bullet is detonatable
        if(isBulletDetonate == true)
        {
            //checks if the bullet has already detonated
            if(hasBulletDetonate == true)
            {
                Instantiate(bulletPrefab, pos, rot);
                hasBulletDetonate = false;


            }
            //if not, it will activate the fire script on the weapon (detonating it)
            else
            {
                m_bulletScript = bulletPrefab.GetComponent<Bullet>();
                //m_bulletScript.bulletID = playerIndex;
                m_bulletScript.Fire(pos,rot);
                hasBulletDetonate = true;
            }
        }
        else
        {
            //link to playerIndex/playerID somehow
            //m_bulletScript.bulletID = playerIndex;
            Instantiate(bulletPrefab, pos, rot); //iterates a bullet at position of gun in WeaponController
            //bulletPrefab.bulletID = playerInput.playerIndex; //returns error/ could not be found (do this properly later)
        }
    }
}
