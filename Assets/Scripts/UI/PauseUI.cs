using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PauseUI : MonoBehaviour
{
    public TextMeshProUGUI pauseHeader;
    public TextMeshProUGUI pauseBody;
    // Start is called before the first frame update
    public void SetPauseTitle(string title)
    {
        pauseHeader.text = title;
        
    }

    // Update is called once per frame
    //void SetPauseBody(string body)
    //{
        //pauseBody.text = body;
    //}
}
