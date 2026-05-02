using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon : MonoBehaviour
{
    public float cooldownTime;
    public float baseDamage;

    public int weaponID;

    public virtual void Fire(Vector3 pos, Quaternion rot){}

    [SerializeField] private GameObject playerPrefab;

}
