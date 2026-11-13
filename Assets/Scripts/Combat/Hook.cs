using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Projectile
{
    private bool isAnchored;
    private bool firstCollision = true;
    private bool grapplePull;
    [SerializeField] private Transform stickyHand;
    [SerializeField] private float grappleObjectOverlapArea = 0.51f;
    [SerializeField] private float grappleSpeed;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask wallOverlapMask;
    [SerializeField] private LayerMask clientOverlapMask;


    void Start()
    {

        if (_rigidbody != null)
        {
            _rigidbody.velocity = transform.forward * _projectileSpeed;
        }
    }

    void Update()
    {
        
        lineRenderer.SetPosition(0, Owner.transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    private void FixedUpdate() //moved this into fixed update to prevent phys checks every frame
    {
        Vector3 grappleDirection = (transform.position - Owner.transform.position).normalized;
        var grapplePos = Owner.transform.position + grappleDirection * grappleSpeed;
        Debug.DrawRay(grapplePos, Vector3.up, Color.green, 3);
        var overlaps = Physics.OverlapSphere(grapplePos, grappleObjectOverlapArea, wallOverlapMask);
        var clientOverlaps = Physics.OverlapSphere(grapplePos, grappleObjectOverlapArea, clientOverlapMask);
        List<Client> enemyOverlaps = new List<Client>();

        foreach(Collider col in clientOverlaps)
        {
            PlayerController player = col.gameObject.GetComponent<PlayerController>();
            if(player != null && player != Owner)
            {
                enemyOverlaps.Add(player.OwningClient);
            }
        }
        
        if (grapplePull && overlaps.Length == 0 && enemyOverlaps.Count == 0)
        {
            Owner.Rigidbody.MovePosition(grapplePos);
        }
        enemyOverlaps.Clear();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(firstCollision != false)
        {
            Anchor(other);
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

    private void Anchor(Collision col)
    {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            transform.SetParent(col.transform);
            Destroy(_rigidbody);
            Destroy(this.GetComponentInChildren<Collider>());
            firstCollision = false;
            isAnchored = true;
    }


}
