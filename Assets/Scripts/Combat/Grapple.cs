using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : Gun
{
    //private Projectile _myProjectile;
    void Start()
    {
        //var hook = projectile.gameObject;
        //_myProjectile = hook.GetComponent<Projectile>();
        //_my
        projectile.AssignOwner(owner);
    }
}
