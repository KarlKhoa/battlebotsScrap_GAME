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
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask wallOverlapMask;

    void Start()
    {
        if (_rigidbody != null)
        {
            _rigidbody.velocity = transform.forward * _projectileSpeed;
        }
    }

    void Update()
    {
        Vector3 grappleDirection = (transform.position - Owner.transform.position).normalized;
        var grapplePos = Owner.transform.position + grappleDirection * grappleSpeed;
        Debug.DrawRay(grapplePos, Vector3.up, Color.green, 3);
        var overlaps = Physics.OverlapSphere(grapplePos, 0.51f, wallOverlapMask);

        foreach (var ol in overlaps)
        {
            Debug.Log(ol.gameObject.name);
        }

        if (grapplePull == true && overlaps.Length == 0)
            {
                Owner.Rigidbody.MovePosition(grapplePos);
            }
        lineRenderer.SetPosition(0, Owner.transform.position);
        lineRenderer.SetPosition(1, transform.position);
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
        if(isAnchored == true && grapplePull == false)
        {
            grapplePull = true;
            Owner.ToggleMoveBackAndForthOff(true);
        }
        else
        {
            Owner.ToggleMoveBackAndForthOff(false);
            Destroy(this.gameObject);
        }
    }
}
