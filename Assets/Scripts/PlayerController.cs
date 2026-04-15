using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BlankBot mPlayerData;
    private float playerHealth;
    private Rigidbody rb;

    private Vector2 moveInput;

    
    [SerializeField] private float botGenSpd;
    [SerializeField] private float botRotSpd;

    private bool isMovingForward;
    private bool isMovingBackward;
    private bool isTurningRight;
    private bool isTurningLeft;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mPlayerData = GetComponentInParent<BotConstructor>().playerData;

    }
    
    void Start()
    {

        playerHealth = mPlayerData.health;
        botGenSpd = mPlayerData.generalSpeed;
        botRotSpd = mPlayerData.rotationSpeed;

    }

    void Update()
    {
        
        if(moveInput == new Vector2(0,1))
        {
            isMovingForward = true;
            isMovingBackward = false;
        }

        if(moveInput == new Vector2(0,-1))
        {
            isMovingBackward = true;
            isMovingForward = false;
        }

        if(moveInput == new Vector2(1,0))
        {
            isTurningRight = true;
            isTurningLeft = false;
        }

        if(moveInput == new Vector2(-1,0))
        {
            isTurningLeft = true;
            isTurningRight = false;
        }
    }

    void FixedUpdate()
    {
        if(isMovingForward == true)
        {
            rb.AddForce(transform.forward * botGenSpd);
            isMovingForward = false;
            //Debug.Log("Moving Forward");
        }
        else if(isMovingBackward == true)
        {
            rb.AddForce(transform.forward * botGenSpd * -1);
            isMovingBackward = false;
            //Debug.Log("Moving Backwards");
        }

        if(isTurningRight == true)
        {
            rb.AddTorque(transform.up * botRotSpd);
            isTurningRight = false;
            //Debug.Log("Turning Right");
        }
        else if (isTurningLeft == true)
        {
            rb.AddTorque(transform.up * botRotSpd * -1);
            isTurningLeft = false;
            //Debug.Log("Turning Left");
        }
    }

    private void OnMove(InputValue  input) 
    {
        moveInput = input.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
      float damageDealt = other.gameObject.GetComponent<Weapon>().baseDamage;
      if(damageDealt != null)
      {
        playerHealth = playerHealth - damageDealt;
        Debug.Log(playerHealth);
      }
      if(playerHealth <= 0)
      {
        Destroy(this.gameObject);
      }
    }


}
