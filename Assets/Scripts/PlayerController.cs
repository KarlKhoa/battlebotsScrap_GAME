using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputs.IPlayerActions
{
    private BlankBot playerData;
    private PlayerInput playerInput;
    private PlayerInputs playerInputs;
    private Rigidbody rb;


    [SerializeField] private float botGenSpd;
    [SerializeField] private float botRotSpd;
    [SerializeField] private Vector3 movement;

    private Vector2 moveInput;


    public void MoveBot(Vector3 forwardBack)
    {
        rb.velocity = forwardBack * botGenSpd * Time.fixedDeltaTime;

        //turn
        //transform.Rotate(transform.up, botRotSpd * moveInput.x * Time.deltaTime);
    }


    private void Awake()
    {
        // if(rb is null)
        // {
        //     Debug.LogError("RigidBody is NULL");
        // }
        // playerInput = GetComponent<PlayerInput>();
        // if (playerInput is null)
        // {
        //     Debug.LogError("Player Input is NULL");
        // }

        // playerInputs = new PlayerInputs();


    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        botGenSpd = GetComponentInParent<BotConstructor>().playerData.generalSpeed;

        //botRotationSpeed = playerData.GetComponentInParent<PlayerData>().botData.rotationSpeed;
    }

    void Update()
    {

        //move forwards + backwards (legacy)
        movement = new Vector3(0, 0 ,Input.GetAxis("Vertical")).normalized;

    }

    void FixedUpdate()
    {
        MoveBot(movement);
    }

    // public void OnMove(InputValue value)
    // {
    //     //store value recieved from input
    //     moveInput = value.Get<Vector2>();
    // }

    // public void OnLook(InputValue value)
    // {
    //     //store value recieved from input
    //     lookAmnt = value.Get<Vector2>();
    // }

    public void OnMove(InputAction.CallbackContext contxt)
    {
        //Vector2 moveInput = contxt.ReadValue<Vector2>();
        //rb.AddForce(new Vector3 (moveInput.x, 0, moveInput.y) * botGenSpd * Time.deltaTime);
    }

    public void OnFire(InputAction.CallbackContext contxt)
    {
        //
    }

}
