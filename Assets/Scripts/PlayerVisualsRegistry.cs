using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BattleBots/Registries/Player Visual Registry", fileName = "New Visual Registry")]
public class PlayerVisualsRegistry : ScriptableObject
{
    public List<PlayerStyleData> BotMats;
}

[System.Serializable]
public struct PlayerStyleData
{
    public Material playerMaterial;
    public Color playerColour;
}