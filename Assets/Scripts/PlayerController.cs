using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerData playerData;
    private Rigidbody rb;


    public float botGeneralSpeed = 5;
    public float botRotationSpeed = 3;
    
    // public string upInput = "w";
    // public string downInput = "s";
    // public string leftInput = "a";
    // public string rightInput = "d";

    // private bool forward;
    // private bool backwards;
    // private bool leftTurn;
    // private bool rightTurn;

    private Vector2 moveAmnt;
    private Vector2 lookAmnt;

    private Vector2 moveAction;



    private void Awake()
    {
        rb = playerData.GetComponent<Rigidbody>();
    }
    
    void Start()
    {

        //botGeneralSpeed = playerData.GetComponentInParent<PlayerData>().botData.generalSpeed;

        //botRotationSpeed = playerData.GetComponentInParent<PlayerData>().botData.rotationSpeed;
    }

    void Update()
    {
        // if(Input.GetKey(upInput))
        // {
        //     forward = true;
        // }
        // else if(Input.GetKey(downInput))
        // {
        //     backwards = true;
        // }

        // if(Input.GetKey(leftInput))
        // {
        //     leftTurn = true;
        // }
        // else if(Input.GetKey(rightInput))
        // {
        //     rightTurn = true;
        // }
    }

    void FixedUpdate()
    {

        // if(forward == true)
        // {
        //     rb.AddForce(transform.forward * botGeneralSpeed);
        //     forward = false;
        // }
        // else if(backwards == true)
        // {
        //     rb.AddForce(transform.forward * -1 * botGeneralSpeed);
        //     backwards = false;
        // }

        // if(leftTurn == true)
        // {
        //     rb.AddTorque(transform.up * -1 * botRotationSpeed);
        //     leftTurn = false;
        // }
        // else if(rightTurn == true)
        // {
        //     rb.AddTorque(transform.up * botRotationSpeed);
        //     rightTurn = false;
        // }
    }


    // public void OnMove(InputValue value)
    // {
    //     moveAmnt = value.Get<Vector2>();
    // }

    // public void OnLook(InputValue value)
    // {
    //     lookAmnt = value.Get<Vector2>();
    // }

    public void OnMove(InputAction.CallbackContext contxt)
    {
        moveAmnt = contxt.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext contxt)
    {
        lookAmnt = contxt.ReadValue<Vector2>();
    }

}
