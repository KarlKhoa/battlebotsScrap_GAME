using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Weapon 
{
    private float baseDamage;

    void Awake()
    {
        baseDamage = 1;
    }

    public void Fire()
    {
        baseDamage = 3;
        //make delay for whatever seconds 
        Invoke(nameof(ResetSawDamage), 2.0f);
    }

    //has trouble making contact because the collider is too low/attachments are built too high
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
                Debug.Log("Player was hit by their own saw!");
                return; //do nothing
            }
            else
            {
                //do damage if we do not own the playercontroller
                playerController.Hurt(baseDamage);
                Debug.Log("Opposing player took damage from Saw!");
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
    }
}
