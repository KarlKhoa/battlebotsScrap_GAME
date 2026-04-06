using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public BaseWeapon[] allWeapons;
    public int currentWeaponIndex = 0;

    //public string attachInput1 = "u";
    //public string attachInput2 = "i";
    
    void Start()
    {
        allWeapons = GetComponentsInChildren<BaseWeapon>();
    }

    void Update()
    {
        //code to change currentWeaponIndex + select weapons goes here
        BaseWeapon currentWeapon = allWeapons[currentWeaponIndex]; //???
        if (Input.GetButtonDown("Fire1") && Time.time > currentWeapon.lastFired + currentWeapon.cooldownTime) //"Fire1" is left ctrl by default
        {
            currentWeapon.Fire();
            currentWeapon.lastFired = Time.time;
        }

        // if (Input.GetKey(attachInput1) && Time.time > attachment1.lastFired + attachment1.cooldownTime)
        // {
        //     attachment1.Fire();
        //     attachment1.lastFired = Time.time;
        // }

    }
}
