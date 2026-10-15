using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class None : Weapon
{
    private float baseDamage = 2;

    void Update()
    {
        baseDamage = baseDamage*owner.livePlayer.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("None detected a collider!");

        //If the gameobject we hit has a PlayerController component
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if (owner == playerController.Owner)
            {
                
                return; //do nothing
            }
            else
            {
                //do damage if we do not own the playercontroller
                playerController.Hurt(baseDamage);
                Debug.Log(baseDamage);
                if (playerController.hurtWasSuccessful)
                {
                }
                else { return; }
                
            }
        }
        else
        {
            Debug.Log("None could not find a PlayerController.");
            Debug.Log(other);
        }
    }
}
