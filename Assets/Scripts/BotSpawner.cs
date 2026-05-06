using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BotSpawner : MonoBehaviour
{
    //Player prefab is the saved prefab between scenes, if this is empty the script constructs a generic/blank bot instead
    public BlankBot playerData;
    public PlayerController playerPrefab;
    //allows the the client to access function in its script
    public GameManager gameManager;

    public int playerScore = 0;

    //temprorary code to test bot attachments
    public Weapon c_attachment1;
    public Weapon c_attachment2;
    public Weapon c_attachment3;
    public Weapon c_attachment4;

    //liveplayer is the bot being used in the scene, this can be deleted and reconstructed, and uses the player prefab as a base
    public PlayerController livePlayer;
    //Create a List of weapons in inspector; currently not doing anything but could be used to keep track of players' current weapons
    public List<Weapon> weapons;
    //this constructionRequest is something the game manager should do between rounds
    private bool spawnRequest = true;

    public PlayerInput Input;

    public bool playerComtroller;

    void Start()
    {
        //when this script starts it will call the addplayercount function on the GameManager script (this should probably be done in the OnPlayerJoined function in this script)
        GameManager.Instance.AddPlayerCount();
        GameManager.Instance.ReturnClient(gameObject);
        c_attachment1 = GameManager.Instance.WeaponsRegistry.AvailableWeapons[1];
        Input = GetComponent<PlayerInput>();
    }


    // Update is called once per frame
    void Update()
    {
        //code checks for when construction is requested and creates a generic bot class for bot prefab to used in combat
        if (spawnRequest == true)
        {
            //creates a generic bot class of player if bot data is empty
            if(playerData == null)
            {
                playerData = new BlankBot(50, 400, 100, 0, 0);
            }

            //creates a bot, puts it into the live player, and makes that object a child of the client (liveplayer not needed/ check)
            livePlayer = Instantiate(playerPrefab, this.transform);

            spawnRequest = false;
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {

    }

    public void SpawnRequest()
    {
            if(playerData == null)
            {
                playerData = new BlankBot(50, 400, 100, 0, 0);
            }

            //creates a bot, puts it into the live player, and makes that object a child of the client (liveplayer not needed/ check)
            livePlayer = Instantiate(playerPrefab, this.transform);

            spawnRequest = false;
    }

    public void AddPoints(int points)
    {
        playerScore += points;
    }

    public void ToggleUIAccess(bool enabled)
    {
        if(enabled)
        {
            Input.actions.Enable();
            Debug.Log(Input.actions);
        }
        else
        {
            Input.actions.Disable();
            Debug.Log(Input.actions);
        }
    }
}
