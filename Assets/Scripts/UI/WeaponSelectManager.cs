using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectManager : MonoBehaviour
{
    private MenuManager menuManager;
    public List<GameObject> weaponPool;

    [SerializeField] private GameObject weapon1;
    [SerializeField] private GameObject weapon2;
    [SerializeField] private GameObject weapon3;
    [SerializeField] private GameObject weapon4;
    [SerializeField] private GameObject weapon5;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GetComponentInParent<MenuManager>();
        CreateWeaponPool();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateWeaponPool()
    {
            for(int i = 0; i < GameManager.Instance.WeaponsRegistry.AvailableWeapons.Count + 1; i++)
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
    
    private void SelectWeapon(GameObject weapon)
    {
        if(weapon != null)
        {
            menuManager.GetSelectedWeapon(weapon);
            menuManager.WeaponAttachOnOff();
            menuManager.WeaponSelectOnOff();
        }
        else
        {
            Debug.Log("oops no weapon");
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
}
