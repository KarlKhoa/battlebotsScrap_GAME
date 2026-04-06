using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseWeapon : MonoBehaviour 
{
    public float cooldownTime;
    public float lastFired = -9999f;
    public int baseDamage;
    public virtual void Fire() {}
}
