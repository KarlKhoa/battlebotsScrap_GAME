using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BotCloner : MonoBehaviour
{
    //Player prefab is the saved prefab between scenes, if this is empty the script constructs a generic/blank bot instead
    public BlankBot playerData;
    public PlayerController playerPrefab;

    //temprorary code to test bot attachments
    public GameObject c_attachment1;
    public GameObject c_attachment2;
    public GameObject c_attachment3;
    public GameObject c_attachment4;

    //Create a List of weapons in inspector; currently not doing anything but could be used to keep track of players' current weapons
    public List<Weapon> weapons;

    //this cloneRequest is something the game manager should do between rounds
    public bool cloneRequest = true;


    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CloneBots()
    {
        //code checks for when clone is requested and creates a generic bot class for bot prefab to used in combat
        if (cloneRequest == true)
        {
            //creates a generic bot class of player if bot data is empty
            if (playerData == null)
            {

                playerData = new BlankBot(50, 400, 100, 0, 0, 1);
                //playerData = new BlankBot(50, 400, 100, 0, 0, 2);
                //playerData = new BlankBot(50, 400, 100, 0, 0, 3);
                //playerData = new BlankBot(50, 400, 100, 0, 0, 4);
            }
            //creates a bot and makes that object a child of the client
            Instantiate(playerPrefab, this.transform);
            playerData.playerID++;
            cloneRequest = false;
        }
    }
}
