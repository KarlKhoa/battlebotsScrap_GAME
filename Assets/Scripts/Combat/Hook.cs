using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Projectile
{
    private bool isAnchored;
    private bool firstCollision;
    
    void Start()
    {
        if(_rigidbody != null)
        {
            _rigidbody.AddForce(transform.forward * _projectileSpeed);
        }
    }

    void update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        transform.SetParent(other.transform);
    }

    public override void Detonate()
    {
        if(isAnchored == true)
        {
            
        }

        Destroy(this.gameObject);
    }
}
