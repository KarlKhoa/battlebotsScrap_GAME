using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gun : Weapon 
{
    public Projectile bulletPrefab;
    private GameObject m_bulletSpawned;
    private Weapon m_bulletScript;

    private float cooldownTime = 2.0f;
    private bool isCooldownOver = true;
    private int bulletsLeft;

    void Awake()
    {
        ReloadBullets();
    }
    
    public override void Fire(Vector3 pos, Quaternion rot)
    {
        if (isCooldownOver & bulletsLeft > 0)
        {
            var bullet = Instantiate(bulletPrefab.gameObject, pos, rot); //iterates a bullet at position of gun in WeaponController
            bullet.GetComponent<Projectile>().owner = owner; //makes bullet's Owner same as our client
            bulletsLeft--;
            //Debug.Log("Bullets left:" + bulletsLeft);
        }
        else { return; }

        StartCoroutine(ResetTimer());
    }

    private IEnumerator ResetTimer()
    {
        //Debug.Log("Resetting" + this + " cooldown...");
        isCooldownOver = false;
        yield return new WaitForSeconds(cooldownTime);
        isCooldownOver = true;
        //Debug.Log(this + "is ready!");
    }

    private void ReloadBullets()
    {
        bulletsLeft = 6;
        //Debug.Log("Gun reloaded!");
    }

}
