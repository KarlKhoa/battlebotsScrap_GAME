using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IFireable //Vestigial, does nothing, delete later? Maybe use if we swicth to system where only some weapons use Fire();
{
    void Fire(Vector3 pos, Quaternion rot);
}
