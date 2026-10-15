using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEndUIManager : MonoBehaviour
{
    //public TMP_Text GameEndWinner;
    public TextMeshProUGUI gameEndText;
    /*public void WinningPlayer(Client client) //will this always be the last player joined?
    {
        GameEndWinner.text = client + "is the winner";
    }*/

    public void SetGameEndText( string text)
    {
        //client = GameManager.ClientsByScoreAscending[registeredClients.Count - 1];
        gameEndText.text = text;
    }

    //restart button function here
    //game manager.instance. restartgame
}
