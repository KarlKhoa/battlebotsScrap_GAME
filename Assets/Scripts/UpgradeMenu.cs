using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeMenu : MonoBehaviour
{
    private List<GameObject> weaponPool;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
