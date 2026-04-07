using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon : MonoBehaviour 
{
    public float cooldownTime;
    public float lastFired = -9999f;
    public int baseDamage;
    public virtual void Fire() {}
}
