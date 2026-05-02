using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_select_manager : MonoBehaviour
{
    public List<GameObject> weaponPool;

    // Start is called before the first frame update
    void Start()
    {
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
    }
    public void Weapon1Selected()
    {
        Debug.Log("Weapon 1 Selected!");
    }
}
