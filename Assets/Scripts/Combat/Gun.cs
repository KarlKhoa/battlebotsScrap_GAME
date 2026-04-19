using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon 
{
    public GameObject bulletPrefab; //originally GameObject
    public GameObject weaponController;
    public GameObject liveBullet;
    //private bool isFired = false;
    //private Transform bulletOrigin;

    public override void Fire()
    {
        //isFired = true;
        //fire bullet
        //trouble finding correct transform because bullet instances can't be parented to Gun
        //var botConstructor = GetComponentInParent<BotConstructor>();
        //Instantiate(bulletPrefab, botConstructor.livePlayer.transform.position, botConstructor.livePlayer.transform.rotation);
        //instantiate bullet at position of weaponcontroller.m_attachment1? this.transform.position? botconstructor.liveplayer
        //if (isFired) { }
        //try raycast?

        liveBullet = Instantiate(bulletPrefab, this.transform); //iterates a bullet, at position of gun (ideally) (should grab transform from parent, why?)
        
        Debug.Log("cooldown:"+cooldownTime);
 
        
    }
}
