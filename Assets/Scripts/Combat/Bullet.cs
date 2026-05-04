using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{

    private const float DEFAULT_LIFETIME = 0.2f;
    
    private Rigidbody rb;
    public float bulletSpeed;

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
        Debug.Log("am hitting");
        
        if(other.TryGetComponent<PlayerController>(out var playerController))
        {
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if(Owner == playerController.Owner)
            {
                Debug.Log("You hit yourself idiot");
                return; //do nothing
            }
            else
            {
                //hurt player
                playerController.Hurt(baseDamage);
                Debug.Log("I hit lmao");
            }
        }
        else
        {
            Debug.Log("u didn't find it lmao");
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
