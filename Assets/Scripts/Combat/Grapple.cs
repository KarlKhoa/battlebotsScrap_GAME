using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//bugs: does not recognise owner
public class Grapple : Weapon
{
    public Projectile projectile;

    private float cooldownTime = 2.0f;
    private bool isCooldownOver = true;


    public override void Fire(Vector3 pos, Quaternion rot)
    {
        if (isCooldownOver)
        {
            var hook = Instantiate(projectile.gameObject, pos, rot); //iterates a hook at position of grapple in WeaponController
            hook.GetComponent<Projectile>().owner = owner; //makes hook's Owner same as our client

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
}
