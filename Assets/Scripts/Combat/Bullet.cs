using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    
    private Rigidbody rb;
    public float bulletSpeed;
    private bool hasCollided;

    public int bulletID;
    

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        baseDamage = 12;
        bulletSpeed = 10;
        hasCollided = false;
    }

    void Start() 
    {
        if(rb != null)
        {
            //move bullet forward
            rb.velocity = transform.forward * bulletSpeed;

            Die();
        }
    }

    //destroy self on collision
    private void OnTriggerEnter(Collider other) 
    {
        hasCollided = true;
        Die();
    }


    private void Die()
    {
        //destroy after hitting something
        if (hasCollided == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //destroy automatically after whatever seconds (aka range)
            Destroy(this.gameObject, 0.3f);
        }
    }

}
