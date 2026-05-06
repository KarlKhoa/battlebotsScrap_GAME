using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmStartArea : MonoBehaviour
{
    public int startCountdown;
    private int playersOnMe;
    private void FixedUpdate()
    {
        if(playersOnMe >= GameManager.Instance.savedPlayerCount && playersOnMe > 1)
        {
            if(startCountdown <= 0)
            {
                GameManager.Instance.StartGame();
                this.gameObject.SetActive(false);
            }
            else
            {
                startCountdown--;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        playersOnMe++;
    }

    private void OnTriggerExit(Collider other)
    {
        playersOnMe--;
    }
}
