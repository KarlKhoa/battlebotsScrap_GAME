using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Weapon 
{
    private float baseDamage;
    private float cooldownTime = 2.0f;
    private bool isCooldownOver = true;

    void Awake()
    {
        ResetSawDamage();
    }

    //on pressing, saw temporarily does more damage
    public override void Fire(Vector3 pos, Quaternion rot)
    {
        if (isCooldownOver)
        {
            StartCoroutine(ActivateSaw());
        }
        else { return; }

        StartCoroutine(ResetTimer());
    }

    //has trouble making contact because the collider is too low/attachments are built too high
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Saw detected a collider!");

        //If the gameobject we hit has a PlayerController component
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if (owner == playerController.owner)
            {
                //Debug.Log("Player was hit by their own Saw!");
                return; //do nothing
            }
            else
            {
                //do damage if we do not own the playercontroller
                playerController.Hurt(baseDamage);
                Debug.Log("Opposing player took " + baseDamage + " damage from Saw!");
            }
        }
        else
        {
            Debug.Log("Saw could not find a PlayerController.");
            Debug.Log(other);
        }
    }

    void ResetSawDamage()
    {
        baseDamage = 1;
        Debug.Log("Saw Deactivated!");
    }

    //saw does more damage for 3 seconds
    private IEnumerator ActivateSaw()
    {
        baseDamage = 5;
        Debug.Log("Saw is spinning!");
        yield return new WaitForSeconds(3);
        ResetSawDamage();
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
