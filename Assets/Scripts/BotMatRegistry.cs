using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BattleBots/Registries/Bot Mat Registry", fileName = "New Bot Mat Registry")]
public class BotMatRegistry : ScriptableObject
{
    public List<Material> BotMats;
}
