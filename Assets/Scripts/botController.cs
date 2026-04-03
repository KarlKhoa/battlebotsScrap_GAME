using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botController : MonoBehaviour
{
    public GameObject playerBot;

    private Rigidbody rb;
    private float botGeneralSpeed;
    private float botRotationSpeed;
    
    public string upInput = "w";
    public string downInput = "s";
    public string leftInput = "a";
    public string rightInput = "d";

    private bool forward;
    private bool backwards;
    private bool leftTurn;
    private bool rightTurn;
    
    void Start()
    {
        rb = playerBot.GetComponent<Rigidbody>();

        botGeneralSpeed = playerBot.GetComponentInParent<playerBot>().botData.generalSpeed;

        botRotationSpeed = playerBot.GetComponentInParent<playerBot>().botData.rotationSpeed;
    }

    void Update()
    {
        if(Input.GetKey(upInput))
        {
            forward = true;
        }
        else if(Input.GetKey(downInput))
        {
            backwards = true;
        }

        if(Input.GetKey(leftInput))
        {
            leftTurn = true;
        }
        else if(Input.GetKey(rightInput))
        {
            rightTurn = true;
        }
    }

    void FixedUpdate()
    {
        if(forward == true)
        {
            rb.AddForce(transform.forward * botGeneralSpeed);
            forward = false;
        }
        else if(backwards == true)
        {
            rb.AddForce(transform.forward * -1 * botGeneralSpeed);
            backwards = false;
        }

        if(leftTurn == true)
        {
            rb.AddTorque(transform.up * -1 * botRotationSpeed);
            leftTurn = false;
        }
        else if(rightTurn == true)
        {
            rb.AddTorque(transform.up * botRotationSpeed);
            rightTurn = false;
        }
    }

}
