using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BlankBot mPlayerData;
    private Rigidbody rb;

    private Vector2 moveInput;

    
    [SerializeField] private float botGenSpd;
    [SerializeField] private float botRotSpd;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mPlayerData = GetComponentInParent<BotConstructor>().playerData;

    }
    
    void Start()
    {
        botGenSpd = mPlayerData.generalSpeed;
        botRotSpd = mPlayerData.rotationSpeed;

    }


    void FixedUpdate()
    {
        if(moveInput == new Vector2(0,1))
        {
            rb.AddForce(transform.forward * botGenSpd);
            //Debug.Log("Moving Forward");
        }
        else if(moveInput == new Vector2(0,-1))
        {
            rb.AddForce(transform.forward * botGenSpd * -1);
            //Debug.Log("Moving Backwards");
        }

        if(moveInput == new Vector2(1,0))
        {
            rb.AddTorque(transform.up * botRotSpd);
            //Debug.Log("Turning Right");
        }
        else if (moveInput == new Vector2(-1,0))
        {
            rb.AddTorque(transform.up * botRotSpd * -1);
            //Debug.Log("Turning Left");
        }
    }

    private void OnMove(InputValue  input) 
    {
        moveInput = input.Get<Vector2>();
    }

}
