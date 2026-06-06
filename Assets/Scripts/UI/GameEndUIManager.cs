using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEndUIManager : MonoBehaviour
{
    public TMP_Text GameEndWinner;
    public void WinningPlayer(Client client)
    {
        GameEndWinner.text = client + "is the winner";
    }
}
