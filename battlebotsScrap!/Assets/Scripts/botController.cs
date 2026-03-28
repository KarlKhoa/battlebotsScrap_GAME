using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botController : MonoBehaviour
{
    private Rigidbody rb;

    public float generalSpeed;
    public float rotationSpeed;

    public float maxSpeed;
    public float maxRotation;

    
    public string upInput = "w";
    public string downInput = "s";
    public string leftInput = "a";
    public string rightInput = "d";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(upInput))
        {
            rb.AddForce(transform.forward * generalSpeed);
            //Debug.Log("Moving Forward");
        }
        else if(Input.GetKey(downInput))
        {
            rb.AddForce(transform.forward * -1 * generalSpeed);
            //Debug.Log("Moving Backwards");
        }

        if(Input.GetKey(leftInput))
        {
            rb.AddTorque(transform.up * -1 * rotationSpeed);
            //Debug.Log("Rotating Left");
        }
        else if(Input.GetKey(rightInput))
        {
            rb.AddTorque(transform.up * rotationSpeed);
            //Debug.Log("Rotating Right");
        }
    }

}
