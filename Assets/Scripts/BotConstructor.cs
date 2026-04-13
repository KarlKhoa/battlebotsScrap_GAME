using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BotConstructor : MonoBehaviour
{
    //Player prefab is the saved prefab between scenes, if this is empty the script constructs a generic/blank bot instead
    public BlankBot playerData;
    public PlayerController playerPrefab;
    public GameObject parentObject;
    private PlayerInput playerInput;
    private PlayerController playerController;
    
    //liveplayer is the bot being used in the scene, this can be deleted and reconstructed, and uses the player prefab as a base
    public PlayerController livePlayer;
    //I think this is pulling from the public list of weapons in the game manager (check with someone else)
    public List<Weapon> weapons;
    //this constructionRequest is something the game manager should do between rounds
    public bool constructionRequest = true;


    void Awake()
    {

        
        //configure player object
        //redirect inputs to player object
        
        /*playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            Debug.LogError("Player Input is NULL");
        }*/
        

    }

    

    // Update is called once per frame
    void Update()
    {
        playerController = GetComponent<PlayerController>();
        //playerController.PlayerMovement();
        //code checks for when construction is requested and creates a generic bot class for bot prefab to used in combat
        if (constructionRequest == true)
        {
            //this if statement creates a generic bot class of player if bot data is empty
            if(playerData != null)
            {
                playerData = new BlankBot(10, 500, 100, 0, 0);
            }

            //Creates a bot at pos of playerInput on SpawnPointManager, makes it current liveplayer
            playerInput = GetComponent<PlayerInput>();
            //creates a bot, and put it into the live player, and makes that object a child of the client
            livePlayer = Instantiate(playerPrefab, parentObject.transform);
    

            constructionRequest = false;


        }
    }

    

}
