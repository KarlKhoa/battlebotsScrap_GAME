using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMaterialGet : MonoBehaviour
{
    private Client _thisClient;
    private MeshRenderer _thisMeshRenderer;

    private PlayerController _thisPlayerController;

    private float _thisPlayerHealth;
    
    void Awake()
    {
        _thisClient = GetComponentInParent<Client>();
        _thisMeshRenderer = GetComponent<MeshRenderer>();
        _thisPlayerController = GetComponentInParent <PlayerController>();
    }
    void Start()
    {
        _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetCleanMaterialForClient(_thisClient);
    }

    void Update()
    {
        //currently just makes bots immediately appear wrecked, no correlation to health when it's updated in playercontroller
        /*if (_thisPlayerHealth <= 37f)
        {
            _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetLightDmgMaterialForClient(_thisClient);
        }
        if (_thisPlayerHealth <= 25f)
        {
            _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetMedDmgMaterialForClient(_thisClient);
        }
        if (_thisPlayerHealth <= 13f)
        {
            _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetHeavyDmgMaterialForClient(_thisClient);
        }*/
    }
}
