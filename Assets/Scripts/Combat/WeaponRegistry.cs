using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="BattleBots/Registries/Weapons Registry", fileName = "New Weapons Registry")]
public class WeaponRegistry : ScriptableObject
{
    public List<GameObject> AvailableWeapons;
}
