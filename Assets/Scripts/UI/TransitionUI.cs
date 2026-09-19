using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TransitionUI : MonoBehaviour
{
    public TextMeshProUGUI transitionText;

    public IEnumerator EndOfRoundTransitionSequence(Client client,int currentRound, int totalRounds)
    {
        transitionText.text = $"Round {currentRound}/{totalRounds} has Ended";
        yield return new WaitForSeconds(3f);
        transitionText.text = $"{client} has Won!";
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }

    public IEnumerator StartOfRoundTransitionSequence(int currentRound, int totalRounds)
    {
        Debug.Log("transition sequence started");
        transitionText.text = $"Round {currentRound}/{totalRounds}";
        yield return new WaitForSeconds(3f);
        transitionText.text = "Round Starts in";
        yield return new WaitForSeconds(3f);
        transitionText.text = "3";
        yield return new WaitForSeconds(1f);
        transitionText.text = "2";
        yield return new WaitForSeconds(1f);
        transitionText.text = "1";
        yield return new WaitForSeconds(1f);
        transitionText.text = "SCRAP!";
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }

}
