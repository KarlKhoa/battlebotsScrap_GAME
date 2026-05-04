using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject weaponSelect;
    public GameObject weaponAttach;


    public GameObject weaponSelectFirstButton;
    public GameObject weaponAttachFirstButton;

    private bool isNotFirstSelectionOfRound;
    private bool currentRoundClock;

    private int playerCount;
    private int playersThatHaveSelected  = 0;


    void Start()
    {

    }

    public void ToggleWeaponSelectionUI(bool state)
    {
        weaponSelect.SetActive(state);
        if(state)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(weaponSelectFirstButton);
        }
        
    }

    public void ToggleWeaponBindingUI(bool state)
    {
        weaponAttach.SetActive(state);
        if(state)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(weaponAttachFirstButton);
        }
    }




}
