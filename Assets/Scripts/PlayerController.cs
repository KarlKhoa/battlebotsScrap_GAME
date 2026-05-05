using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BlankBot mPlayerData;

    private Rigidbody rb;

    private BotSpawner botSpawner;

    public BotSpawner Owner => botSpawner;

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
        botSpawner = GetComponentInParent<BotSpawner>();
        mPlayerData = botSpawner.playerData;
        

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
        playerHealth = playerHealth - damage;
        if(playerHealth <= 0)
        {
            Die();
        }
    }

    public void Die(bool isLastDeath = false)
    {
        if(isLastDeath)
        {
            GameManager.Instance.LastPlayerCheck(true);
            botSpawner.AddPoints(GameManager.Instance.ScorePoints());
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.Instance.LastPlayerCheck();
            botSpawner.AddPoints(GameManager.Instance.ScorePoints());
            Destroy(this.gameObject);
        }
        
    }

}
