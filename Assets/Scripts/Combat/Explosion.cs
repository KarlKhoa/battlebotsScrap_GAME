using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Projectile
{
    [SerializeField] private float _baseDamage;
    [SerializeField] private float knockback;
    [SerializeField] private float liveTime;
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 void OnTriggerEnter(Collider other)
    {
        //If the gameobject we hit has a PlayerController component
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if (owner != playerController.Owner)
            {
                //do damage if we do not own the playercontroller
                var playerSpeed = owner.livePlayer.Rigidbody.velocity.magnitude;
                playerController.Hurt(_baseDamage);
            }
        }
        else
        {
            Debug.Log("None could not find a PlayerController.");
            Debug.Log(other);
        }
    }
}
