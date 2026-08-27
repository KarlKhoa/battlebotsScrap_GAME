using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TransitionUI : MonoBehaviour
{
    public TextMeshProUGUI transitionText;
    private float targetTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
    }

    public void TransitionSequence(int currentRound, int totalRounds)
    {
        transitionText.text = $"Round {currentRound}/{totalRounds} has Ended";
        Timer(10);
        transitionText.text = $"Round{currentRound}/{totalRounds} has Started"; 
    }

    public void Timer(float time)
    {
        targetTime = time;
    }

}
