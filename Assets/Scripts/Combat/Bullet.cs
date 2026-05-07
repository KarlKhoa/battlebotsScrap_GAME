using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{

    private const float DEFAULT_LIFETIME = 0.2f;
    
    private Rigidbody rb;
    private float bulletSpeed;

    private float baseDamage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        baseDamage = 12;
        bulletSpeed = 800;
        
    }

    void Start()
    {
        if (rb != null)
        {
            //move bullet forward
            rb.AddForce(transform.forward * bulletSpeed);

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
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if(owner == playerController.owner)
            {
                //Debug.Log("Player was hit by their own bullet!");
                return; //do nothing
            }
            else
            {
                //do damage if we do not own the playercontroller
                playerController.Hurt(baseDamage);
                //Debug.Log("Opposing player took damage from Bullet!");
            }
        }
        else
        {
            //Debug.Log("Bullet could not find a PlayerController.");
            Debug.Log(other);
        }

        Die();
    }

    //destroy self (optional delay)
    private void Die(float delay = 0)
    {
        Destroy(gameObject, delay);
    }

}
