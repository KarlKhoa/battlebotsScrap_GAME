using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Client owner;
    [SerializeField] private bool isDetonatable;
    public bool IsDetonatable()
    {
        return isDetonatable;
    }
    public virtual void Detonate() { }
    public void AssignOwner(Client client)
    {
        owner = client;
    }
}