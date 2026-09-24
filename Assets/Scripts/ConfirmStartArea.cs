using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Serialization;

public class ConfirmStartArea : MonoBehaviour
{
    public float timeTilStart;
    private int _timeTilStartInt;
    public int playersOnMe;
    [SerializeField] private GameObject menus;

    private void Update()
    {
        _timeTilStartInt = (int)timeTilStart;
        GameManager.Instance.menuManager.ToggleTransitionUI(true);
        StartCoroutine(GameManager.Instance.menuManager.transition.LobbyTransitionSequence(playersOnMe, _timeTilStartInt));
        
        if(playersOnMe >= GameManager.Instance.registeredClients.Count && (playersOnMe >= 2 || GameManager.Instance.CanStartGameWithOnePlayer))
        {
            timeTilStart -= Time.fixedDeltaTime * 0.3f;
            if(timeTilStart <= 0)
            {
                GameManager.Instance.menuManager.ToggleTransitionUI(false);
                GameManager.Instance.StartGame();
                this.gameObject.SetActive(false);
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the object we collided with has a PlayerController
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            playersOnMe++;
            Debug.Log("A Player entered the start area");
        }
        else { return; }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //if the object we collided with has a PlayerController
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            playersOnMe--;
        }
        else { return; }
    }
}
