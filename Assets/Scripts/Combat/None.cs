using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class None : Weapon
{
    private float baseDamage = 2;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("None detected a collider!");

        //If the gameobject we hit has a PlayerController component
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if (owner != playerController.Owner)
            {
                //do damage if we do not own the playercontroller
                var playerSpeed = owner.Rigidbody.velocity.magnitude;
                playerController.Hurt(baseDamage * playerSpeed);
            }
        }
        else
        {
            Debug.Log("None could not find a PlayerController.");
            Debug.Log(other);
        }
    }
}
