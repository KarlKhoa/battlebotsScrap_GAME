using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    public float bulletSpeed;
    
    private Rigidbody rb;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Start() 
    {
        if(rb != null)
        {
            rb.velocity = new Vector3(0,10,0);
            Debug.Log("Bullet Fired!");
        }
    }
}
