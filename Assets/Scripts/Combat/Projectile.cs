using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public PlayerController Owner { get; protected set; }
    public float _baseDamage;
    public float _projectileSpeed;
    [SerializeField] private bool isDetonatable;
    
    protected Rigidbody _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public bool IsDetonatable()
    {
        return isDetonatable;
    }
    public virtual void Detonate() { }
    public void AssignOwner(PlayerController client)
    {
        Owner = client;
    }
}