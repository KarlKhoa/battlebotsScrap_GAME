using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Weapon 
{
    private float baseDamage;
    private float cooldownTime = 2.0f;
    private bool isCooldownOver = true;
    private bool isSawSpinning = false;

    void Awake()
    {
        transform.position = transform.position + transform.forward * 0.1f; //bring saw forward a bit so it can more easily strike target
        ResetSawDamage();
    }

    void Update()
    {
        if (isSawSpinning)
        {
            transform.Rotate(0f, 300f * Time.deltaTime, 0f, Space.Self); //rotate saw while it's active
        }
    }

    //on pressing, saw temporarily does more damage
    public override void Fire(Vector3 pos, Quaternion rot)
    {
        if (isCooldownOver)
        {
            StartCoroutine(ActivateSaw());
        }
        else { return; }

        //StartCoroutine(ResetTimer());
    }

    //has trouble making contact because the collider is too low/attachments are built too high (added a box collider as a quick fix)
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Saw detected a collider!");

        //If the gameobject we hit has a PlayerController component
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if (owner == playerController.owner)
            {
                //Debug.Log("Player was hit by their own Saw!");
                return; //do nothing
            }
            else
            {
                //do damage if we do not own the playercontroller
                playerController.Hurt(baseDamage);
                if (playerController.hurtWasSuccessful)
                { Debug.Log(playerController.owner + "took " + baseDamage + " damage from Saw!"); }
                else { return; }
                
            }
        }
        else
        {
            Debug.Log("Saw could not find a PlayerController.");
            Debug.Log(other);
        }
    }

    void ResetSawDamage()
    {
        baseDamage = 8;
        //Debug.Log("Saw Deactivated!");
    }

    //saw does more damage for 3 seconds
    private IEnumerator ActivateSaw()
    {
        baseDamage = 15;
        isSawSpinning = true;
        Debug.Log(owner + "'s Saw is spinning!");
        yield return new WaitForSeconds(3);
        isSawSpinning = false;
        Debug.Log(owner + "'s Saw stopped spinning...");
        ResetSawDamage();
        StartCoroutine(ResetTimer());
    }

    private IEnumerator ResetTimer()
    {
        Debug.Log(owner + "'s Saw is cooling down...");
        isCooldownOver = false;
        yield return new WaitForSeconds(cooldownTime);
        isCooldownOver = true;
        Debug.Log(owner + "'s Saw is ready!");
    }
}
