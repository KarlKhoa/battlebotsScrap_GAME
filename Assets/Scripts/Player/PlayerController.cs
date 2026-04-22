using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BlankBot myData;
    
    private Rigidbody rb;

    private Vector2 moveInput;

    private float myHealth;
    private float myGenSpd;
    private float myRotSpd;

    private bool isMovingForward;
    private bool isMovingBackward;
    private bool isTurningRight;
    private bool isTurningLeft;

    public int myID;
    public int playerCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myData = GetComponentInParent<BotCloner>().playerData; //Data generated from BlankBot on the clone

    }
    
    void Start()
    {

        myHealth = myData.health;
        myGenSpd = myData.genSpeed;
        myRotSpd = myData.rotSpeed;
        myID = myData.playerID;

    }

    void Update()
    {
        //checking inputs
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
        //moving player
        if(isMovingForward == true)
        {
            rb.AddForce(transform.forward * myGenSpd);
            isMovingForward = false;
        }
        else if(isMovingBackward == true)
        {
            rb.AddForce(transform.forward * myGenSpd * -1);
            isMovingBackward = false;
        }

        if(isTurningRight == true)
        {
            rb.AddTorque(transform.up * myRotSpd);
            isTurningRight = false;
        }
        else if (isTurningLeft == true)
        {
            rb.AddTorque(transform.up * myRotSpd * -1);
            isTurningLeft = false;
        }
    }

    private void OnMove(InputValue input) 
    {
        moveInput = input.Get<Vector2>();
    }

    //Checks when a collider come in contact with this objects collider
    private void OnTriggerEnter(Collider other)
    {
      //when it hits, it will check the gameObject this collided with for a baseDamage number and put into the damageDealt variable
      float damageDealt = other.gameObject.GetComponent<Weapon>().baseDamage;

      //if it isn't empty it will take that damage variable and apply it to this game object
      if(damageDealt != null)// && myID != other.gameObject.GetComponent<Weapon>().weaponID) // if weaponID does not match myID
      {
        myHealth -= damageDealt;
      }
      //if it is below 0 it will destory the game object (this should be changed to a method)
      if(myHealth <= 0)
      {
        Destroy(this.gameObject);
      }
    }


}
