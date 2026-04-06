using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBot
{
    void Move();
    void Turn();

    void Activate1();
    void Activate2();
    void Activate3();
    void Activate4();

    void TakeDamage();
    void Die();
}
