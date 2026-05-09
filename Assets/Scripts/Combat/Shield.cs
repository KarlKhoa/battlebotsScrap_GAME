using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon
{

    private float cooldownTime = 5.0f;
    private bool isCooldownOver = true;
    private int usesLeft;

    void Awake()
    {
        RestoreShields();
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


}
