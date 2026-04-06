using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotConstructor : MonoBehaviour
{
    public GameObject playerBot;
    // Start is called before the first frame update
    void Awake()
    {
        playerBot.GetComponent<playerBot>().botData = new BaseBot(10, 12.5f, 7, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
