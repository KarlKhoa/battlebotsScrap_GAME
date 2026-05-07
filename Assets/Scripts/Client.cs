using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;


public class Client : MonoBehaviour
{
    //Player prefab is the saved prefab between scenes, if this is empty the script constructs a generic/blank bot instead
    public BlankBot playerData;
    public PlayerController playerPrefab;
    
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

    public PlayerInput Input;
    private MultiplayerEventSystem _multiplayerEventSystem;
    private InputSystemUIInputModule _uiInputModule;
    
    void Start()
    {
        //when this script starts it will call the addplayercount function on the GameManager script (this should probably be done in the OnPlayerJoined function in this script)
        GameManager.Instance.RegisterClient(this);
        c_attachment1 = GameManager.Instance.WeaponsRegistry.AvailableWeapons[1];
        Input = GetComponent<PlayerInput>();
        
        //Locate and bind the per-client event system to the shared UI - MEL
        _multiplayerEventSystem = GetComponent<MultiplayerEventSystem>();
        _multiplayerEventSystem.playerRoot = GameManager.Instance.menus;
        _multiplayerEventSystem.firstSelectedGameObject = GameManager.Instance.firstSelectedWeaponUI;
        _uiInputModule = GetComponent<InputSystemUIInputModule>();
        _uiInputModule.actionsAsset = Input.actions;
        
        SpawnRequest();

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
            GameManager.Instance.RegisterPlayer(livePlayer);
    }

    public void AddPoints(int points)
    {
        Debug.Log($"Scored {points}");
        playerScore += points;
    }

    public void ToggleUIAccess(bool enabled, GameObject selectedUIElement = null)
    {
        _uiInputModule.enabled = enabled; //turn off mouse events
        _multiplayerEventSystem.sendNavigationEvents = enabled; //disable normal navigation
        _multiplayerEventSystem.SetSelectedGameObject(GameManager.Instance.firstSelectedWeaponUI); //reset selected element to ensure player uses UI properly
    }
}
