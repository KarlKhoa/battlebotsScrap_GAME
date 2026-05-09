using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Projectile
{
    private Rigidbody rb;
    private float hookSpeed;

    private bool hitSomething;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hookSpeed = 800;
        hitSomething = false;
    }

    void Start()
    {
        if(rb != null)
        {
            rb.AddForce(transform.forward * hookSpeed);
        }
    }

    void FixedUpdate()
    {
        StartCoroutine(StopHook());
    }

    private void OnTriggerEnter(Collider other)
    {
        hitSomething = true;
        //if we hit something
        if (other != null) //other.TryGetComponent<PlayerController>(out var playerController))
        {
            //if (owner == playerController.owner)
            //{
            //    return; //do nothing
            //}
            //else
            //{
            //    //store location and transform owner to this position
            //    //owner.transform.position = transform.position; //(?)
            //    Debug.Log("Hit another player with grappling hook");
            //    Die();
            //}
        }
        else { return; }
    }

    private IEnumerator StopHook()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector3.zero;

        if (!hitSomething)
        {
            Die();
        }
    }


    private void Die()
    {
        Destroy(gameObject);
    }
}
