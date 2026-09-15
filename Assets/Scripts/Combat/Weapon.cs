using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public abstract class Weapon : MonoBehaviour
{
    //icon display (selection menu). set in editor, attachment assets
    public Vector2 iconPosMinOffset; //left and bottom values for rect transform
    public Vector2 iconPosMaxOffset; //right and top values for rect transform
    public Quaternion iconRotation;
    public Vector3 iconScale;
    
    public Sprite selectBackdrop;
    public Sprite selectIcon;
    public Sprite selectLabel;
    public Client owner;
    [SerializeField] private GameObject playerPrefab;

    public virtual void Fire(Vector3 pos, Quaternion rot){}
}
