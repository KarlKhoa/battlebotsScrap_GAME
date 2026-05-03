using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachManager : MonoBehaviour
{
    private MenuManager menuManager;
    private GameObject m_selectedWeapon;
    private List<GameObject> m_players;

    void Start()
    {
        menuManager = GetComponentInParent<MenuManager>();
    }

    public void AttachWeapon(GameObject weapon)
    {
        //code to attach player weapon here
        menuManager.PlayerHasSelected();
        menuManager.WeaponSelectOnOff();
        menuManager.WeaponAttachOnOff();
    }

    public void AttachSlot1()
    {
        AttachWeapon(null);
    }
    public void AttachSlot2()
    {

    }
    public void AttachSlot3()
    {

    }
    public void AttachSlot4()
    {

    }

    public void GetSelectedWeaponInParent()
    {
        m_selectedWeapon = menuManager.selectedWeapon;
    }

}
