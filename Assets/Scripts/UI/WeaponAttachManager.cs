using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttachManager : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private WeaponSelectManager selectManager;
    public List<Image> weaponBiindButtonList;
    public Sprite noBind;
    private Weapon m_selectedWeapon;
    private Client m_client;



    public void BindWeaponForClient(Client client, Weapon toAttach)
    {
        menuManager.ToggleWeaponBindingUI(true);
        m_selectedWeapon = toAttach;
        m_client = client;
        WeaponBindButtonDisplayUpdate();
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

    public void WeaponBindButtonDisplayUpdate()
    {
        if(m_client.c_attachment1 != null)
        {
            weaponBiindButtonList[0].sprite = m_client.c_attachment1.selectSprite;
        }
        else
        {
            weaponBiindButtonList[0].sprite = noBind;
        }

        if(m_client.c_attachment2 != null)
        {
            weaponBiindButtonList[1].sprite = m_client.c_attachment2.selectSprite;
        }
        else
        {
            weaponBiindButtonList[1].sprite = noBind;
        }

        if(m_client.c_attachment3 != null)
        {
            weaponBiindButtonList[2].sprite = m_client.c_attachment3.selectSprite;
        }
        else
        {
            weaponBiindButtonList[2].sprite = noBind;
        }

        if(m_client.c_attachment4 != null)
        {
            weaponBiindButtonList[3].sprite = m_client.c_attachment4.selectSprite;
        }
        else
        {
            weaponBiindButtonList[3].sprite = noBind;
        }
    }

}
