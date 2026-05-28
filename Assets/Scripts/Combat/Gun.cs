using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gun : Weapon 
{
    public Projectile projectile;

    private float cooldownTime = 2.0f;
    private bool isCooldownOver = true;
    //private int bulletsLeft; //ammo count

    void Awake()
    {
        //ReloadBullets();
    }
    
    public override void Fire(Vector3 pos, Quaternion rot)
    {
        
        if (isCooldownOver) // & bulletsLeft > 0)
        {
            rot = transform.localRotation;
            var bullet = Instantiate(projectile.gameObject, pos, rot); //iterates a bullet at position of gun in WeaponController - make rot forward attachmentOrientation
            bullet.GetComponent<Projectile>().owner = owner; //makes bullet's Owner same as our client
            //bulletsLeft--;
            //Debug.Log("Bullets left:" + bulletsLeft);
            StartCoroutine(ResetTimer());
        }
        else { return; }
    }

    private IEnumerator ResetTimer()
    {
        //Debug.Log("Resetting" + this + " cooldown...");
        isCooldownOver = false;
        yield return new WaitForSeconds(cooldownTime);
        isCooldownOver = true;
        //Debug.Log(this + "is ready!");
    }

    //reloads ammo
    /*private void ReloadBullets()
    {
        bulletsLeft = 6;
        //Debug.Log("Gun reloaded!");
    }*/

}
