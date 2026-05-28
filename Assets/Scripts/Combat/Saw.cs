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

        //StartCoroutine(ResetTimer());
    }

    //has trouble making contact because the collider is too low/attachments are built too high (added a box collider as a quick fix)
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Saw detected a collider!");

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
                if (playerController.hurtWasSuccessful)
                { Debug.Log(playerController.owner + "took " + baseDamage + " damage from Saw!"); }
                else { return; }
                
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
        baseDamage = 5;
        //Debug.Log("Saw Deactivated!");
    }

    //saw does more damage for 3 seconds
    private IEnumerator ActivateSaw()
    {
        baseDamage = 10;
        Debug.Log(owner + "'s Saw is spinning!");
        yield return new WaitForSeconds(3);
        Debug.Log(owner + "'s Saw stopped spinning...");
        ResetSawDamage();
        StartCoroutine(ResetTimer());
    }

    private IEnumerator ResetTimer()
    {
        Debug.Log(owner + "'s Saw is cooling down...");
        isCooldownOver = false;
        yield return new WaitForSeconds(cooldownTime);
        isCooldownOver = true;
        Debug.Log(owner + "'s Saw is ready!");
    }
}
