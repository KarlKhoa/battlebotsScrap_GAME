using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon : MonoBehaviour
{
    public Sprite selectSprite;
    public Client owner;
    [SerializeField] private GameObject playerPrefab;

    public virtual void Fire(Vector3 pos, Quaternion rot){}
}
