using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Projectile
{
    private bool isAnchored;
    private bool firstCollision = true;
    private bool grapplePull;
    private bool grappleDistrupted;
    [SerializeField] private float grappleSpeed;

    void Start()
    {
        if(_rigidbody != null)
        {
            _rigidbody.AddForce(transform.forward * _projectileSpeed);
        }
    }

    void update()
    {
        if(grapplePull == true)
        {
            Vector3 grappleDirection = this.transform.position - owner.transform.position;
            owner.transform.position += grappleDirection * grappleSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(firstCollision != false)
        {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        transform.SetParent(other.transform);
        Destroy(_rigidbody);
        Destroy(this.GetComponentInChildren<Collider>());
        firstCollision = false;
        isAnchored = true;
        }

    }

    public override void Detonate()
    {
        if(isAnchored == true)
        {
            grapplePull = true;
            owner.livePlayer.ToggleMoveBackAndForthOff(true);
        }
        else
        {
            owner.livePlayer.ToggleMoveBackAndForthOff(false);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
