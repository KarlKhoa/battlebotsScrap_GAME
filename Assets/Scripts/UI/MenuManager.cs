using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject weaponSelect;
    public GameObject weaponAttach;
    public GameObject selectedWeapon;

    public GameObject weaponSelectFirstButton;
    public GameObject weaponAttachFirstButton;

    private bool isNotFirstSelectionOfRound;
    private bool currentRoundClock;

    private int playerCount;
    private int playersThatHaveSelected  = 0;


    void Start()
    {

    }

    public void WeaponSelectOnOff()
    {
        if(isNotFirstSelectionOfRound == false)
        {
            playerCount = GameManager.Instance.savedPlayerCount;
            isNotFirstSelectionOfRound = true;
        }

        if(weaponSelect.activeSelf == false)
        {
            weaponSelect.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(weaponSelectFirstButton);
        }
        else
        {
            weaponSelect.SetActive(false);
        }
    }

    public void WeaponAttachOnOff()
    {
        if(weaponAttach.activeSelf == false)
        {
            weaponAttach.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(weaponAttachFirstButton);

        }
        else
        {
            weaponAttach.SetActive(false);
        }
    }

    public void GetSelectedWeapon(GameObject weapon)
    {
        selectedWeapon = weapon;
    }

    public void PlayerHasSelected()
    {
        playersThatHaveSelected ++;
        if(playersThatHaveSelected >= playerCount)
        {
            WeaponSelectOnOff();
            GameManager.Instance.StartRound();
        }
    }

}
