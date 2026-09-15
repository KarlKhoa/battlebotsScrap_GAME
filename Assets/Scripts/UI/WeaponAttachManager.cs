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

    public void AttachSlotFront()
    {
        m_client.c_attachmentFront = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }
    public void AttachSlotBack()
    {
        m_client.c_attachmentBack = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }
    public void AttachSlotRight()
    {
        m_client.c_attachmentRight = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }
    public void AttachSlotLeft()
    {
        m_client.c_attachmentLeft = m_selectedWeapon;
        selectManager.UIIsBusy = false;
        menuManager.ToggleWeaponBindingUI(false);
    }

    public void WeaponBindButtonDisplayUpdate()
    {
        if(m_client.c_attachmentFront != null)
        {
            weaponBiindButtonList[0].sprite = m_client.c_attachmentFront.selectIcon;
        }
        else
        {
            weaponBiindButtonList[0].sprite = noBind;
        }

        if(m_client.c_attachmentBack != null)
        {
            weaponBiindButtonList[1].sprite = m_client.c_attachmentBack.selectIcon;
        }
        else
        {
            weaponBiindButtonList[1].sprite = noBind;
        }

        if(m_client.c_attachmentRight != null)
        {
            weaponBiindButtonList[2].sprite = m_client.c_attachmentRight.selectIcon;
        }
        else
        {
            weaponBiindButtonList[2].sprite = noBind;
        }

        if(m_client.c_attachmentLeft != null)
        {
            weaponBiindButtonList[3].sprite = m_client.c_attachmentLeft.selectIcon;
        }
        else
        {
            weaponBiindButtonList[3].sprite = noBind;
        }
    }

}
