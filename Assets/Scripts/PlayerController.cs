using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BlankBot mPlayerData;

    private Rigidbody rb;

    private Client client;

    public Client owner => client;

    public bool IsAlive => playerHealth > 0;
    public bool hurtWasSuccessful;

    private Vector2 moveInput;

    [SerializeField] private float playerHealth;
    [SerializeField] private float botGenSpd;
    [SerializeField] private float botRotSpd;

    private bool isMovingForward;
    private bool isMovingBackward;
    private bool isTurningRight;
    private bool isTurningLeft;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        client = GetComponentInParent<Client>();
        mPlayerData = client.playerData;
        

    }
    
    void Start()
    {

        playerHealth = mPlayerData.health;
        botGenSpd = mPlayerData.generalSpeed;
        botRotSpd = mPlayerData.rotationSpeed;
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

        //Debug.Log($"fwd{isMovingForward} bck{isMovingBackward} tl{isTurningLeft} tr{isTurningRight}");

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

    private void OnMove(InputValue input) 
    {
    
        moveInput = input.Get<Vector2>();
    }

    //Checks when a collider come in contact with this objects collider

    public void Hurt(float damage)
    {
        var weaponController = GetComponent<WeaponController>();

        if (weaponController.isShieldUp == false)
        {
            playerHealth = playerHealth - damage;
            hurtWasSuccessful = true;
            if (playerHealth <= 0)
            {
                Die();
            }
        }
        else 
        {
            hurtWasSuccessful = false;
            Debug.Log(owner + "'s Shield blocked damage!");  
        }
    }

    public void Die(bool isLastDeath = false)
    {
        client.AddPoints(GameManager.Instance.ScorePoints());
        Destroy(gameObject);
        GameManager.Instance.OnPlayerDeath(this);
    }

    public void FirstDieToStart()
    {
        Destroy(gameObject);
    }

}
