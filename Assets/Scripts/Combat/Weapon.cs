using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon : MonoBehaviour
{
    public float cooldownTime;
    public float baseDamage;

    //probably should be using the Hurt() function on player controller to deal damager in the future
    public BotSpawner Owner;

    public virtual void Fire(Vector3 pos, Quaternion rot){}

    [SerializeField] private GameObject playerPrefab;

}
