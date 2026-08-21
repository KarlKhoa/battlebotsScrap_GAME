using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMaterialGet : MonoBehaviour
{
    private Client _thisClient;
    private MeshRenderer _thisMeshRenderer;

    private PlayerController _thisPlayerController;
    
    void Awake()
    {
        _thisClient = GetComponentInParent<Client>();
        _thisMeshRenderer = GetComponent<MeshRenderer>();
        _thisPlayerController = GetComponentInParent <PlayerController>();
        _thisPlayerController.OnPlayerHurt += UpdatePlayerMaterial;
    }
    void Start()
    {
        _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetCleanMaterialForClient(_thisClient);
    }

    void UpdatePlayerMaterial(float currentHP, float maxHP)
    {
        var healthPercentage = (currentHP / maxHP) * 100;
        Debug.Log(healthPercentage);
        //currently just makes bots immediately appear wrecked, no correlation to health when it's updated in playercontroller
        if (healthPercentage <= 75f)
        {
            _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetLightDmgMaterialForClient(_thisClient);
        }
        if (healthPercentage <= 50f)
        {
            _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetMedDmgMaterialForClient(_thisClient);
        }
        if (healthPercentage <= 25f)
        {
            _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetHeavyDmgMaterialForClient(_thisClient);
        }
    }
}
