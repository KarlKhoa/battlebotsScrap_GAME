using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon : MonoBehaviour 
{
    public float cooldownTime;
    public int baseDamage;
    public virtual void Fire(){}
}
