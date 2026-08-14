using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualManager : MonoBehaviour
{

    [SerializeField] PlayerVisualsRegistry VisualsRegistry;

    public Material GetMaterialForClient(Client client)
    {
        Material result = null;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].playerMaterial;

        return result;
    }

    public Color GetColourForClient(Client client)
    {
        Color result = Color.black;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].playerColour;

        return result;
    }
}
