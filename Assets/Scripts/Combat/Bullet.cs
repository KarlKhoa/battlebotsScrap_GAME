using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    
    private Rigidbody rb;
    public float bulletSpeed;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Start() 
    {
        if(rb != null)
        {
            //move bullet forward
            rb.velocity = transform.forward * bulletSpeed;

            //destroy automatically after whatever seconds (aka range)
            Destroy(this.gameObject, 0.5f);
        }
    }

    //destroy self on collision
    private void OnCollisionEnter(Collision other) 
    {
        Destroy(this.gameObject);
    }

}
