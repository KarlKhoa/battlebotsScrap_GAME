using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{

    private const float DEFAULT_LIFETIME = 0.2f;
    
    public Rigidbody rb;
    private float bulletSpeed;

    private float baseDamage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        baseDamage = 20;
        bulletSpeed = 800;
        
    }

    void Start()
    {
        if (rb != null)
        {
            rb.AddForce(transform.forward * bulletSpeed); //shoots bullet in world forward direction; change to be whatever the gun's forward direction is

            Die(DEFAULT_LIFETIME);
        }
    }

    //destroy self on collision
    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log("Bullet detected a collider!");
        
        //If the gameobject we hit has a PlayerController component
        if(other.TryGetComponent<PlayerController>(out var playerController))
        {
            //Debug.Log("Hit " + playerController);

            //if our client is the same as player we hit
            if(owner == playerController.owner)
            {
                //Debug.Log("Player was hit by their own Bullet!");
                return; //do nothing
            }
            else
            {
                //do damage if we do not own the playercontroller
                playerController.Hurt(baseDamage);

                if (playerController.hurtWasSuccessful)
                {
                    Debug.Log(playerController.owner + "took" + baseDamage + "damage from" + owner + "'s Bullet!");
                }
                else { return; }
            }
        }
        else
        {
            return;
            //Debug.Log("Bullet could not find a PlayerController.");
            //Debug.Log(other);
        }

        Die();
    }

    //destroy self (optional delay)
    private void Die(float delay = 0)
    {
        Destroy(gameObject, delay);
    }

}
