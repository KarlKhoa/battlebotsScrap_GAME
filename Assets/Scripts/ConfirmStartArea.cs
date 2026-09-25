using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Serialization;

public class ConfirmStartArea : MonoBehaviour
{
    public int playersOnMe;
 
    private bool HasSufficientPlayersToStart()
    {
        var minimumPlayers = GameManager.Instance.CanStartGameWithOnePlayer ? 1 : 2;
        if(playersOnMe < minimumPlayers) return false;
        if(playersOnMe < GameManager.Instance.registeredClients.Count) return false;
        //if(isLobbyOver) { this.gameObject.SetActive(false);};
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the object we collided with has a PlayerController
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            playersOnMe++;
            Debug.Log("A Player entered the start area");
            if(HasSufficientPlayersToStart())
            {
                GameManager.Instance.StartGameCountdown();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if the object we collided with has a PlayerController
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            playersOnMe--;
            if(!HasSufficientPlayersToStart())
            {
                GameManager.Instance.StopGameCountdown();
            }
        }
    }

    public void DisableSelf()
    {
        this.gameObject.SetActive(false);
    }
}
