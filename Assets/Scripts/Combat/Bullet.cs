using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    
    private Rigidbody rb;
    //[SerializeField] private GameObject bulletOrigin; 
    //private Weapon gun;
    //liveplayer pos/make a child of Gun?

    void Awake()
    {
        //gun = GetComponentInParent<BotConstructor>(this);
        rb = this.GetComponent<Rigidbody>();
    }
    void Start() 
    {
        if(rb != null)
        {
            //this.transform.position = bulletOrigin.transform.position; //gun pos
            rb.velocity = new Vector3(10,0,0);
            Debug.Log("Bullet Fired!");
        }
    }
}
