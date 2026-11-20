using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : Gun
{
    //private Projectile _myProjectile;
    void Start()
    {
        //var hook = projectile.gameObject;
        //_myProjectile = hook.GetComponent<Projectile>();
        //_my
        projectile.AssignOwner(owner);
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            if (owner == playerController.OwningClient)
            {
                //Debug.Log("Player was hit by their own Shield");
                return; //do nothing
            }
            else
            {
                var playerSpeed = owner.Rigidbody.velocity.magnitude;
                playerController.Hurt(_baseDamage + playerSpeed);
            }
        }
    }
}
