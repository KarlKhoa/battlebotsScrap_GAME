using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BlankBot mPlayerData;

    private Rigidbody rb;

    private BotSpawner botSpawner;

    public int m_playerID;

    private Vector2 moveInput;

    private float playerHealth;
    [SerializeField] private float botGenSpd;
    [SerializeField] private float botRotSpd;

    private bool isMovingForward;
    private bool isMovingBackward;
    private bool isTurningRight;
    private bool isTurningLeft;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        botSpawner = GetComponentInParent<BotSpawner>();
        mPlayerData = botSpawner.playerData;
        

    }
    
    void Start()
    {

        playerHealth = mPlayerData.health;
        botGenSpd = mPlayerData.generalSpeed;
        botRotSpd = mPlayerData.rotationSpeed;
        m_playerID = botSpawner.playerID;
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
            rb.AddForce(transform.forward * botGenSpd);
            isMovingForward = false;
        }
        else if(isMovingBackward == true)
        {
            rb.AddForce(transform.forward * botGenSpd * -1);
            isMovingBackward = false;
        }

        if(isTurningRight == true)
        {
            rb.AddTorque(transform.up * botRotSpd);
            isTurningRight = false;
        }
        else if (isTurningLeft == true)
        {
            rb.AddTorque(transform.up * botRotSpd * -1);
            isTurningLeft = false;
        }
    }

    private void OnMove(InputValue  input) 
    {
        moveInput = input.Get<Vector2>();
    }

    //Checks when a collider come in contact with this objects collider
    private void OnTriggerEnter(Collider other)
    {
      //when it hits, it will check the gameObject this collided with for a baseDamage number and put into the damageDealt variable
      float damageDealt = other.gameObject.GetComponent<Weapon>().baseDamage;
      //check other gameobject for weaponID
      int weaponID = other.gameObject.GetComponent<Weapon>().weaponID;

      //if it isn't empty (and the IDs of the bullet and player are different) it will take that damage variable and apply it to this game object.
      if(damageDealt != null && weaponID != m_playerID)
      {
            Debug.Log("Ow");
            playerHealth -= damageDealt;
      }
      else { Debug.Log("light work no reaction"); }
      //if it is below 0 it will destory the game object
      if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.LastPlayerCheck();
        botSpawner.AddPoints(GameManager.Instance.ScorePoints());
        Destroy(this.gameObject);
    }

}
