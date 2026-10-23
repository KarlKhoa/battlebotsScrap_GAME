using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject weaponSelect;
    public GameObject weaponAttach;
    public GameObject gameEnd;
    public GameObject pause;

    public ButtonTargeter ButtonTargeter;

    public GameObject weaponSelectFirstButton;
    public GameObject weaponAttachFirstButton;

    public TransitionUI transition;

    private bool isNotFirstSelectionOfRound;
    private bool currentRoundClock;
    private int playerCount;


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

    public void ToggleGameEndUI(bool state)
    {
        gameEnd.SetActive(state);
        if(state)
        {

        }
    }

    public void ToggleTransitionUI(bool state)
    {
        transition.gameObject.SetActive(state);
        
    }

    public void TogglePauseUI(bool state)
    {
        pause.SetActive(state);
        if (state)
        {
            Time.timeScale = 0;
        }
        else if (!state)
        {
            Time.timeScale = 1;
        }
    }
}
