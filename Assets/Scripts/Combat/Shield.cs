using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon
{

    private float cooldownTime = 5.0f;
    private bool isCooldownOver = true;
    private int usesLeft;
    private float baseDamage;

    void Awake()
    {
        RestoreShields();
        baseDamage = 3f;
    }

    public override void Fire(Vector3 pos, Quaternion rot)
    {
        if (isCooldownOver & usesLeft > 0)
        {
            StartCoroutine(ActivateShield());
        }
        else { return; }
    }
    
    private void RestoreShields()
    {
        usesLeft = 3;
        //Debug.Log("Shields Restored!");
    }

    private IEnumerator ActivateShield()
    {
        //get WeaponController and set isShieldUp to true
        var weaponController = GetComponentInParent<WeaponController>();
        weaponController.isShieldUp = true;
        Debug.Log("Shield is active!");

        usesLeft--;
        Debug.Log(owner + "'s Shields left:" + usesLeft);

        yield return new WaitForSeconds(5); //leave isShieldUp active for 5sec
        
        weaponController.isShieldUp = false;
        Debug.Log("Shield went down!");

        StartCoroutine(ResetTimer()); //start cooldown
    }

    //cooldown
    private IEnumerator ResetTimer()
    {
        Debug.Log(owner + "'s Shield must cool down...");
        isCooldownOver = false;
        yield return new WaitForSeconds(cooldownTime);
        isCooldownOver = true;
        Debug.Log(owner + "'s Shield is ready!");
    }
    
    
    //does this count as a new feature?
    
    //shield bash + reduce damage passively when a shield is hit
    void OnTriggerEnter(Collider other)
    {
        var weaponController = GetComponentInParent<WeaponController>();
        //Debug.Log("Shield detected a collider!");
        weaponController.didHitShield = true;
        
        //If the gameobject we hit has a PlayerController component
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            Debug.Log(playerController);
            //if our client is the same as player we hit
            if (owner == playerController.owner)
            {
                //Debug.Log("Player was hit by their own Shield");
                return; //do nothing
            }
            else
            {
                //do damage if we do not own the playercontroller
                playerController.Hurt(baseDamage);
                if (playerController.hurtWasSuccessful)
                {
                    //Debug.Log(playerController.owner + "took " + baseDamage + " damage from Shield!");
                }
                else
                {
                    return;
                }

            }
        }
        else
        {
            //Debug.Log("Shield could not find a PlayerController.");
            //Debug.Log(other);
        }
        //weaponController.didHitShield = false;
    }

    //when shield isn't in contact with anything
    void OnTriggerExit(Collider other)

    {
        var weaponController = GetComponentInParent<WeaponController>();
        weaponController.didHitShield = false;
    }


}
