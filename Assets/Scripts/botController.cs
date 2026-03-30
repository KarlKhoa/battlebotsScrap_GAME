using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botController : MonoBehaviour
{
    private Rigidbody rb;

    public float generalSpeed;
    public float rotationSpeed;

    //public float maxSpeed;
    //public float maxRotation;

    
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
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

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
            rb.AddForce(transform.forward * generalSpeed);
            forward = false;
        }
        else if(backwards == true)
        {
            rb.AddForce(transform.forward * -1 * generalSpeed);
            backwards = false;
        }

        if(leftTurn == true)
        {
            rb.AddTorque(transform.up * -1 * rotationSpeed);
            leftTurn = false;
        }
        else if(rightTurn == true)
        {
            rb.AddTorque(transform.up * rotationSpeed);
            rightTurn = false;
        }
    }

}
