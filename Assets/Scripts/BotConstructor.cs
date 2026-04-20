using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BotConstructor : MonoBehaviour
{
    //Player prefab is the saved prefab between scenes, if this is empty the script constructs a generic/blank bot instead
    public BlankBot playerData;
    public PlayerController playerPrefab;
    
    //temprorary code to test bot attachments
    public GameObject c_attachment1;
    public GameObject c_attachment2;
    public GameObject c_attachment3;
    public GameObject c_attachment4;

    //liveplayer is the bot being used in the scene, this can be deleted and reconstructed, and uses the player prefab as a base
    public PlayerController livePlayer;
    //Create a List of weapons in inspector; currently not doing anything but could be used to keep track of players' current weapons
    public List<Weapon> weapons;
    //this constructionRequest is something the game manager should do between rounds
    public bool constructionRequest = true;


    void Awake()
    {

    }

    

    // Update is called once per frame
    void Update()
    {
        //code checks for when construction is requested and creates a generic bot class for bot prefab to used in combat
        if (constructionRequest == true)
        {
            //creates a generic bot class of player if bot data is empty
            if(playerData == null)
            {
                playerData = new BlankBot(10, 400, 100, 0, 0);
            }

            //creates a bot, puts it into the live player, and makes that object a child of the client (liveplayer not needed/ check)
            livePlayer = Instantiate(playerPrefab, this.transform);
    

            constructionRequest = false;


        }
    }

    

}
