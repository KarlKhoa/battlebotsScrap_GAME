using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BlankBot _mPlayerData;

    private Material _playerMaterial;

    private Rigidbody _rb;

    private Client _client;
    private MeshRenderer _thisMeshRenderer;

    public Client Owner => _client;

    public bool IsAlive => playerHealth > 0;
    public bool hurtWasSuccessful;

    private Vector2 _moveInput;

    [SerializeField] private float playerHealth;
    [SerializeField] private float botGenSpd;
    [SerializeField] private float botRotSpd;

    private bool _isMovingForward;
    private bool _isMovingBackward;
    private bool _isTurningRight;
    private bool _isTurningLeft;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _client = GetComponentInParent<Client>();
        _mPlayerData = _client.playerData;
        _playerMaterial = GetComponent<MeshRenderer>().material;

    }
    
    void Start()
    {

        playerHealth = _mPlayerData.health;
        botGenSpd = _mPlayerData.generalSpeed;
        botRotSpd = _mPlayerData.rotationSpeed;
    }

    void Update()
    {
        //checking inputs
        if(_moveInput == new Vector2(0,1))
        {
            _isMovingForward = true;
            _isMovingBackward = false;
        }

        if(_moveInput == new Vector2(0,-1))
        {
            _isMovingBackward = true;
            _isMovingForward = false;
        }

        if(_moveInput == new Vector2(1,0))
        {
            _isTurningRight = true;
            _isTurningLeft = false;
        }

        if(_moveInput == new Vector2(-1,0))
        {
            _isTurningLeft = true;
            _isTurningRight = false;
        }
    }

    void FixedUpdate()
    {

        //Debug.Log($"fwd{isMovingForward} bck{isMovingBackward} tl{isTurningLeft} tr{isTurningRight}");

        //moving player
        if(_isMovingForward == true)
        {
            _rb.AddForce(transform.forward * botGenSpd);
            _isMovingForward = false;
        }
        else if(_isMovingBackward == true)
        {
            _rb.AddForce(transform.forward * botGenSpd * -1);
            _isMovingBackward = false;
        }

        if(_isTurningRight == true)
        {
            _rb.AddTorque(transform.up * botRotSpd);
            _isTurningRight = false;
        }
        else if (_isTurningLeft == true)
        {
            _rb.AddTorque(transform.up * botRotSpd * -1);
            _isTurningLeft = false;
        }
    }

    private void OnMove(InputValue input) 
    {
    
        _moveInput = input.Get<Vector2>();
        //Debug.Log(moveInput);
    }

    //Checks when a collider come in contact with this objects collider

    public void Hurt(float damage)
    {
        var weaponController = GetComponent<WeaponController>();
        if (GameManager.hasGameStartedYet == true)
        {
            if (weaponController.isShieldUp == false)
            {
                
                if (weaponController.didHitShield == false)
                {
                    playerHealth = playerHealth - damage;
                    DoPlayerFlash(Color.red, 0.2f);
                    hurtWasSuccessful = true;
                    if (playerHealth <= 0)
                    {
                        Die();
                    }
                }
                else
                {
                    damage = damage * 0.5f;
                    playerHealth = playerHealth - damage;
                    DoPlayerFlash(Color.yellow, 0.2f);
                    hurtWasSuccessful = true;
                    Debug.Log(Owner + "'s Shield partially blocked damage!");  
                    if (playerHealth <= 0)
                    {
                        Die();
                    } 
                }
            }
            else
            {
                DoPlayerFlash(Color.white, 0.2f);
                hurtWasSuccessful = false;
                Debug.Log(Owner + "'s Shield fully blocked damage!");
            }
        }
        else
        {
            Debug.Log("Cannot hurt players before the start of the game!");
            return;
        }
    }

    private void DoPlayerFlash(Color flashColour, float duration)
    {
        StopCoroutine("FlashPlayer");
        var coroutine = FlashPlayer(flashColour, duration);
        StartCoroutine(coroutine);
    }

    IEnumerator FlashPlayer (Color flashColour, float duration)
    {
        //set material to red
        _playerMaterial.SetColor("_Fresnel_Tint", flashColour);

        var remainingTime = duration;

        //start a timer
        //each frame, reduce the timer and reduce the redness of the material slightly

        while(remainingTime > 0)
        {
            yield return new WaitForEndOfFrame();
            remainingTime -= Time.deltaTime;
            _playerMaterial.SetColor("_Fresnel_Tint", Color.Lerp(flashColour, Color.black, 1 - (remainingTime / duration)));
        }

        //end
    }

    //used by Grapple
    public void JumpToPosition(Vector3 targetPos)
    {
        _rb.velocity = new Vector3(100,0,0);
    }

    public void Die(bool isLastDeath = false)
    {
        _client.AddPoints(GameManager.Instance.ScorePoints());
        Destroy(gameObject);
        GameManager.Instance.OnPlayerDeath(this);
    }

    public void FirstDieToStart()
    {
        Destroy(gameObject);
    }

}
