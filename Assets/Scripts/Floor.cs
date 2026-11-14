using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private bool active;
    
    [SerializeField] private GameObject controllerGuide;

    void Awake()
    {
        floorGuideToggle(active);
    }

    public void floorGuideToggle(bool state)
    {
        controllerGuide.SetActive(state);
    }
}
