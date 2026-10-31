using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Projectile
{
    [SerializeField] private float knockback;
    [SerializeField] private float radius;
    [SerializeField] private float liveTime;
    // Start is called before the first frame update


    void Start()
    {
        Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(knockback, transform.position, radius);
                PlayerController playerController = rb.gameObject.GetComponent<PlayerController>();
                if(playerController != null)
                {
                    if(playerController.Owner != Owner)
                    {
                        playerController.Hurt(_baseDamage);
                    }
                    else
                    {
                        playerController.Hurt(_baseDamage*0.5f);
                    }
                }
            }
        }

        Destroy(this.gameObject);
    }

}
