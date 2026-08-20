using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualManager : MonoBehaviour
{

    [SerializeField] PlayerVisualsRegistry VisualsRegistry;

    public Material GetCleanMaterialForClient(Client client)
    {
        Material result = null;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].playerMaterial;

        return result;
    }
    
    
    public Material GetLightDmgMaterialForClient(Client client)
    {
        Material result = null;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].lightDamageMat;

        return result;
    }
    public Material GetMedDmgMaterialForClient(Client client)
    {
        Material result = null;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].medDamageMat;

        return result;
    }

    public Material GetHeavyDmgMaterialForClient(Client client)
    {
        Material result = null;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].heavyDamageMat;
        return result;
    }

    
    
    public Color GetColourForClient(Client client)
    {
        Color result = Color.black;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].playerColour;

        return result;
    }

    public string GetNameForClient(Client client)
    {
        string result = null;
        var index = GameManager.Instance.registeredClients.IndexOf(client);
        result = VisualsRegistry.BotMats[index].playerName;

        return result;
    }
}
