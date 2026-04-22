using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    private Rigidbody rb;
    private int[] bulletID;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        baseDamage = 12;
    }
    void Start() 
    {
        if(rb != null)
        {
            //move bullet forward
            rb.velocity = transform.forward * 10;

            //destroy automatically after whatever seconds (aka range)
            Destroy(this.gameObject, 0.5f);
        }
    }

    //destroy self on collision
    private void OnTriggerEnter(Collider other)
    {
        //if(weaponID != other.gameObject.GetComponent<PlayerController>().myID)
        Destroy(this.gameObject);
    }

}
