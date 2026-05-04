using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachManager : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private WeaponSelectManager selectManager;
    private Weapon m_selectedWeapon;
    private BotSpawner m_client;

    public void BindWeaponForClient(BotSpawner client, Weapon toAttach)
    {
        menuManager.ToggleWeaponBindingUI(true);
        m_selectedWeapon = toAttach;
        m_client = client;
    }

    public void AttachSlot1()
    {
        m_client.c_attachment1 = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }
    public void AttachSlot2()
    {
        m_client.c_attachment2 = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }
    public void AttachSlot3()
    {
        m_client.c_attachment3 = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }
    public void AttachSlot4()
    {
        m_client.c_attachment4 = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }

}
