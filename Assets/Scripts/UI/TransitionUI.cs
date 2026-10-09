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
        transitionBody.text = ((int)timeRemaining).ToString();
    }


}
