using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BotConstructor : MonoBehaviour
{
    //Player prefab is the saved prefab between scenes, if this is empty the script constructs a generic/blank bot instead
    private BlankBot playerData;
    public GameObject playerPrefab;
    //liveplayer is the bot being used in the scene, this can be deleted and reconstructed, and uses the player prefab as a base
    public GameObject livePlayer;
    //I think this is pulling from the public list of weapons in the game manager (check with someone else)
    public List<Weapon> weapons;
    //this constructionRequest is something the game manager should do between rounds
    public bool constructionRequest = true;


    void Awake()
    {
        
        //spawn player object
        //configure player object
        //redirect inputs to player object

        //PlayerBot.GetComponent<PlayerBot>().botData = new BaseBot(10, 12.5f, 7, 0, 0);
        

    }

    

    // Update is called once per frame
    void Update()
    {
        //code checks for when construction is requested and creates a generic bot class for bot prefab to used in combat
        if (constructionRequest == true)
        {
            //this if statement creates a generic bot class of player if bot data is empty, could use this with a game object instead if needed
            if(playerData == null)
            {
                playerData = new BlankBot(10, 12.5f, 7, 0, 0);
            }

            //Creates a bot, this instatiate can be done at a specific location aswell (maybe use the transform data on player spawn here)
            Instantiate(playerPrefab);
            constructionRequest = false;

        }
    }
}
