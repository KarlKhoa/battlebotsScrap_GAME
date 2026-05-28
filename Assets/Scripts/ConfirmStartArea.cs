using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmStartArea : MonoBehaviour
{
    public float timeTilStart;
    private int playersOnMe;
    private void FixedUpdate()
    {
        if(playersOnMe >= GameManager.Instance.registeredClients.Count && playersOnMe >= 2)
        {
            if(timeTilStart <= 0)
            {
                GameManager.Instance.StartGame();
                this.gameObject.SetActive(false);
            }
            else
            {
                timeTilStart -= Time.fixedDeltaTime;
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
