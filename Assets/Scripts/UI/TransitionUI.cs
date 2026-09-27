using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TransitionUI : MonoBehaviour
{
    public TextMeshProUGUI transitionHeader;
    public TextMeshProUGUI transitionBody;

    public IEnumerator EndOfRoundTransitionSequence(Client client,int currentRound, int totalRounds)
    {
        transitionHeader.text = $"Round {currentRound}/{totalRounds} over!";
        transitionBody.text = $"{client} wins!";
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }

    public IEnumerator StartOfRoundTransitionSequence(int currentRound, int totalRounds, int timeTilStart)
    {
        
        Debug.Log("Round transition sequence started");
        //transitionHeader.text = $"Round {currentRound}/{totalRounds} starts in...";
        //move this countdown to gamemanager, don't use waitforseconds just use deltatime like in lobby. make it so this sequence happens during bind screen instead of after round start so we aren't playing while it happens
        //transitionBody.text = $"{timeTilStart}";
        /*if (GameManager.)
        {
            transitionBody.text = "SCRAP!";
        }*/
        /*yield return new WaitForSeconds(1f);
        transitionBody.text = "2";
        yield return new WaitForSeconds(1f);
        transitionBody.text = "1";
        yield return new WaitForSeconds(1f);
        transitionBody.text = "SCRAP!";
        yield return new WaitForSeconds(1f);*/

        return null;
    }

    public void SetTransitionTitle(string title)
    {
         transitionHeader.text = title;
    }

    public void SetTransitionBody(string body)
    {
        transitionBody.text = body;
    }

    public void UpdateCountdownTimer(float timeRemaining)
    {
        transitionBody.text = timeRemaining.ToString("#");
    }

    public IEnumerator LobbyTransitionSequence(int playersJoined, int timeTilStart)
    {
        //Debug.Log("Lobby transition sequence started");
        transitionHeader.text = $"{playersJoined}/4 players ready";
        transitionBody.text = " ";
        if (playersJoined >= 1)
        {
            transitionBody.text = $"{timeTilStart}";
        }
        if (timeTilStart >= 0f)
        {
            yield return new WaitForSeconds(0.1f);
            this.gameObject.SetActive(false);
        }

    }

}
