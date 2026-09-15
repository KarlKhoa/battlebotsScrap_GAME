using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WeaponSelectManager : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private WeaponAttachManager attachManager;
    public List<Weapon> weaponPool;
    public bool UIIsBusy;

    [SerializeField] private Weapon weapon1;
    [SerializeField] private Weapon weapon2;
    [SerializeField] private Weapon weapon3;
    [SerializeField] private Weapon weapon4;
    [SerializeField] private Weapon weapon5;
    [SerializeField] private Button selectionButtonPrefab;
    [SerializeField] private Transform selectionButtonContainer;

    private Client m_client;


    public Sprite noWeapon;

    private bool playerSelectUIOn;
    public GameObject selectUI;

    private List<Image> weaponSelectButtonBackdrops = new();
    private List<Image> weaponSelectButtonLabels = new();
    private List<Image> weaponSelectButtonIcons = new();
    
    private List<RectTransform> weaponSelectIconTransforms = new();

    private List<Button> weaponSelectButtons = new();

    void Update()
    {
        if( playerSelectUIOn == true)
        {

        }
    }

    public void WeaponSelectionSequence()
    {
        StartCoroutine(WeaponSelectionSequence_Internal());
    }

    IEnumerator WeaponSelectionSequence_Internal()
    {
        CreateWeaponPool();
        
        var orderedClients = GameManager.Instance.ClientsByScoreAscending;

        foreach(var player in orderedClients)
        {
            var playerClient = player.GetComponent<Client>();
            playerClient.ToggleUIAccess(false);
        }

        foreach(var player in orderedClients)
        {
            UIIsBusy = true;
            var playerClient = player.GetComponent<Client>();
            UpdateButtonDisplay(playerClient);
            playerClient.ToggleUIAccess(true);
            SelectWeaponForClient(playerClient);
            yield return new WaitUntil(() => !UIIsBusy);
            playerClient.ToggleUIAccess(false);
        }

        weaponPool.Clear();

        foreach(Button b in weaponSelectButtons)
        {
            Destroy(b.gameObject);
        }

        weaponSelectButtons.Clear();
        weaponSelectIconTransforms.Clear();
        weaponSelectButtonBackdrops.Clear();
        weaponSelectButtonLabels.Clear();
        weaponSelectButtonIcons.Clear();


        GameManager.Instance.StartRound();
    }



    public void CreateWeaponPool()
    {
            for(int i = 0; i < GameManager.Instance.registeredClients.Count + 1; i++)
            {
                weaponPool.Add(GameManager.Instance.WeaponsRegistry.AvailableWeapons[Random.Range(0, GameManager.Instance.WeaponsRegistry.AvailableWeapons.Count)]);
            }

            foreach(var weapon in weaponPool)
            {
                var button = Instantiate(selectionButtonPrefab, Vector3.zero, Quaternion.identity, selectionButtonContainer);
                button.onClick.AddListener(delegate { SelectWeapon(weapon); });
                weaponSelectButtons.Add(button);
                weaponSelectButtonBackdrops.Add(button.GetComponent<Image>());
                weaponSelectButtonLabels.Add(button.transform.GetChild(0).GetComponent<Image>());
                weaponSelectButtonIcons.Add(button.transform.GetChild(1).GetComponent<Image>());
                weaponSelectIconTransforms.Add(button.transform.GetChild(1).GetComponent<RectTransform>());
            }
            
            GameManager.Instance.firstSelectedWeaponUI = weaponSelectButtons[0].gameObject;

            if(weaponPool.Count >= 1)
            {               
                 weapon1 = weaponPool[0];
            }
            if(weaponPool.Count >= 2)
            {               
                 weapon2 = weaponPool[1];
            }
            if(weaponPool.Count >= 3)
            {               
                 weapon3 = weaponPool[2];
            }
            if(weaponPool.Count >= 4)
            {               
                 weapon4 = weaponPool[3];
            }
            if(weaponPool.Count >= 5)
            {               
                 weapon5 = weaponPool[4];
            }
    }

    public void SelectWeaponForClient(Client client)
    {
        menuManager.ToggleWeaponSelectionUI(true);
        m_client = client;
        
    }
    
    private void SelectWeapon(Weapon weapon)
    {
        if(weapon != null)
        {
            //Debug.Log("BINDING");
            menuManager.ToggleWeaponSelectionUI(false);
            attachManager.BindWeaponForClient(m_client, weapon);
        }
        else
        {
            //Debug.Log("oops no weapon");
        }
    }

    public void Weapon1Selected()
    {
        SelectWeapon(weapon1);
        weapon1 = null;
    }
    public void Weapon2Selected()
    {
        SelectWeapon(weapon2);
        weapon2 = null;
    }
    public void Weapon3Selected()
    {
        SelectWeapon(weapon3);
        weapon3 = null;
    }
    public void Weapon4Selected()
    {
        SelectWeapon(weapon4);
        weapon4 = null;
    }
    public void Weapon5Selected()
    {
        SelectWeapon(weapon5);
        weapon5 = null;
    }

    public void UpdateButtonDisplay(Client client)
    {
        var uiColour = GameManager.Instance.PlayerVisuals.GetColourForClient(client);

        for(int i = 0; i < weaponSelectButtons.Count; i++)
        {
            ColorBlock colorVar = weaponSelectButtons[i].colors;
            colorVar.selectedColor = uiColour;
            weaponSelectButtons[i].colors = colorVar;
        }

        for(int i = 0; i < weaponPool.Count; i++)
        {
            weaponSelectButtonBackdrops[i].sprite = weaponPool[i].selectBackdrop;
            weaponSelectButtonLabels[i].sprite = weaponPool[i].selectLabel;
            weaponSelectButtonIcons[i].sprite = weaponPool[i].selectIcon;
            
            weaponSelectIconTransforms[i].offsetMin = weaponPool[i].iconPosMinOffset; //left + bottom values for rect transform
            weaponSelectIconTransforms[i].offsetMax = weaponPool[i].iconPosMaxOffset; //right + top values for rect transform
            weaponSelectIconTransforms[i].localScale = weaponPool[i].iconScale;
            weaponSelectIconTransforms[i].rotation = weaponPool[i].iconRotation;
            
        }

        /*
        for(int i = 0; i < weaponPool.Count; i++)
        {
            if(weaponPool == null)
            {
                
            }
        }
        */
    }
}
