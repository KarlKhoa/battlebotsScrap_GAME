using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    
    private Rigidbody rb;
    public float bulletSpeed;
    private bool hasCollided;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        baseDamage = 12;
        bulletSpeed = 800;
        hasCollided = false;
        
    }

    void Start()
    {
        //if (rb != null)
        //{
        //    //move bullet forward
        //    rb.AddForce(transform.forward * bulletSpeed);

        //    Die();
        //}
    }

    public override void Fire(Vector3 pos, Quaternion rot)
     {
        if (rb != null)
        {
            //move bullet forward
            rb.AddForce(transform.forward * bulletSpeed);

            Die();
        }
        Debug.Log("I sploded!");
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
            Destroy(this.gameObject, 0.2f);
        }
    }

}
