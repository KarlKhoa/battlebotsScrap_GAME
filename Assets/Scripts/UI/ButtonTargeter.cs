using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTargeter : MonoBehaviour
{
    
    [SerializeField] private Image activeSelectUI;
    private Vector3 currentDestination;

    public void ShowTarget(bool state)
    {
        activeSelectUI.gameObject.SetActive(state);
    }

    public void SetTargetPosition(Vector3 position)
    {
        currentDestination = position;
    }

    public void SetTargetColour(Color colour)
    {

    }

    // Update is called once per frame
    void Update()
    {
        activeSelectUI.transform.position = Vector3.Lerp(activeSelectUI.transform.position, currentDestination, 15 * Time.deltaTime);
    }
}
