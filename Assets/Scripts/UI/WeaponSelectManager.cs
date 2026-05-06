using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private BotSpawner m_client;

    public Sprite noWeapon;

    public List<Image> weaponSelectButtonList;
    
    // Update is called once per frame
    void Update()
    {

    }

    public void WeaponSelectionSequence()
    {
        StartCoroutine(WeaponSelectionSequence_Internal());
    }

    IEnumerator WeaponSelectionSequence_Internal()
    {
        CreateWeaponPool();
        
        foreach(var player in GameManager.Instance.c_players)
        {
            var playerClient = player.GetComponent<BotSpawner>();
            playerClient.ToggleUIAccess(false);
        }

        foreach(var player in GameManager.Instance.c_players)
        {
            UIIsBusy = true;
            UpdateButtonDisplay();
            var playerClient = player.GetComponent<BotSpawner>();
            playerClient.ToggleUIAccess(true);
            SelectWeaponForClient(playerClient);
            yield return new WaitUntil(() => !UIIsBusy);
            playerClient.ToggleUIAccess(false);
        }

        GameManager.Instance.StartRound();
    }



    public void CreateWeaponPool()
    {
            for(int i = 0; i < GameManager.Instance.c_players.Count + 1; i++)
            {
                weaponPool.Add(GameManager.Instance.WeaponsRegistry.AvailableWeapons[Random.Range(0, GameManager.Instance.WeaponsRegistry.AvailableWeapons.Count)]);
            }

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

    public void SelectWeaponForClient(BotSpawner client)
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

    public void UpdateButtonDisplay()
    {
        for(int i = 0; i < weaponPool.Count; i++)
        {
            weaponSelectButtonList[i].sprite = weaponPool[i].selectSprite;
        }
        if(weapon1 == null)
        {
            weaponSelectButtonList[0].sprite = noWeapon;
        }
        if(weapon2 == null)
        {
            weaponSelectButtonList[1].sprite = noWeapon;
        }
        if(weapon3 == null)
        {
            weaponSelectButtonList[2].sprite = noWeapon;
        }
        if(weapon4 == null)
        {
            weaponSelectButtonList[3].sprite = noWeapon;
        }
         if(weapon5 == null)
        {
            weaponSelectButtonList[4].sprite = noWeapon;
        }
    }
}
