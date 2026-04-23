using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//bugs: can't fire while moving
public class WeaponController : MonoBehaviour
{

    private GameObject m_attachment1;
    private GameObject m_attachment2;
    private GameObject m_attachment3;
    private GameObject m_attachment4;

    //holds weapon script of attachment to use the fire function on it
    [SerializeField]
    private Weapon attachmentScript1;
    private Weapon attachmentScript2;
    private Weapon attachmentScript3;
    private Weapon attachmentScript4;

    //variable to hold the cooldown variable from the weapon script
    private float a1Cooldown;
    private float a2Cooldown;
    private float a3Cooldown;
    private float a4Cooldown;

    //this is the variable that the timer uses
    private float m_cooldownTime1 = 0;
    private float m_cooldownTime2 = 0;
    private float m_cooldownTime3 = 0;
    private float m_cooldownTime4 = 0;

    private bool a1_isFireable;
    private bool a2_isFireable;
    private bool a3_isFireable;
    private bool a4_isFireable;

    private Vector3 m_attachment1Pos;
    private Vector3 m_attachment2Pos;
    private Vector3 m_attachment3Pos;
    private Vector3 m_attachment4Pos;
    private Quaternion m_attachment1Rot;
    private Quaternion m_attachment2Rot;
    private Quaternion m_attachment3Rot;
    private Quaternion m_attachment4Rot;


    void Awake() 
    {

        //grab gameobject from parent (change to be more elegant- from playerdata? in future)
        if( m_attachment1 == null)
        {
            m_attachment1 = GetComponentInParent<BotSpawner>().c_attachment1;
        }

        if( m_attachment2 == null)
        {
            m_attachment2 = GetComponentInParent<BotSpawner>().c_attachment2; 
        }

        if( m_attachment3 == null)
        {
            m_attachment3 = GetComponentInParent<BotSpawner>().c_attachment3; 
        }

        if( m_attachment4 == null)
        {
            m_attachment4 = GetComponentInParent<BotSpawner>().c_attachment4; 
        }

    }
    void Start()
    {
        //make these into functions later

        //offsets position from parent 
        Vector3 attachmentPerch = this.transform.position + transform.up * 0.15f;
        m_attachment1Pos = attachmentPerch + transform.forward * 0.6f;
        m_attachment2Pos = attachmentPerch + transform.forward * -0.6f;
        m_attachment3Pos = attachmentPerch + transform.right * 0.6f;
        m_attachment4Pos = attachmentPerch + transform.right * -0.6f;

        // set rotation
        m_attachment1Rot = new Quaternion(0,90,0,0);
        m_attachment2Rot = new Quaternion(0,0,0,0);
        m_attachment3Rot = new Quaternion(0,0,0,0);
        m_attachment4Rot = new Quaternion(0,0,0,0);

        //instantiate using above offets
        Instantiate(m_attachment1, m_attachment1Pos, m_attachment1Rot, this.transform);
        Instantiate(m_attachment2, m_attachment2Pos, m_attachment2Rot, this.transform);
        Instantiate(m_attachment3, m_attachment3Pos, m_attachment3Rot, this.transform);
        Instantiate(m_attachment4, m_attachment4Pos, m_attachment3Rot, this.transform);

        //gets the script of the weapon attached so the functions on it are available to this script to be used when firing the weapons
        attachmentScript1 = m_attachment1.GetComponent<Weapon>();
        attachmentScript2 = m_attachment2.GetComponent<Weapon>();
        attachmentScript3 = m_attachment3.GetComponent<Weapon>();
        attachmentScript4 = m_attachment4.GetComponent<Weapon>(); 

        //gets the cooldown variable from the weapon attached
        a1Cooldown = attachmentScript1.cooldownTime;
        a2Cooldown = attachmentScript2.cooldownTime;
        a3Cooldown = attachmentScript3.cooldownTime;
        a4Cooldown = attachmentScript4.cooldownTime;

    }

    // Update is called once per frame
    void Update()
    {
        //repeat in update to keep track of pos/rotation but slightly different offset because otherwise it doesn't work
        m_attachment1Pos =  this.transform.position + transform.forward * 0.7f + transform.up * 0.15f;
        m_attachment1Rot = this.transform.rotation;
    }

    void FixedUpdate()
    {
        //timer to check if the weapon is fireable
        if(a1Cooldown <= m_cooldownTime1)
        {
            a1_isFireable = true;
        }
        else
        {
            m_cooldownTime1 ++;
        }

        if (a2Cooldown <= m_cooldownTime2)
        {
            a2_isFireable = true;
        }
        else
        {
            m_cooldownTime2++;
        }

        if (a3Cooldown <= m_cooldownTime3)
        {
            a3_isFireable = true;
        }
        else
        {
            m_cooldownTime3++;
        }

        if (a4Cooldown <= m_cooldownTime4)
        {
            a4_isFireable = true;
        }
        else
        {
            m_cooldownTime4++;
        }
    }


    //magic, i guess
    private void OnFire1(InputValue input)
    {
        //before firing it checks if the weapon is fireable
        if(a1_isFireable == true)
        {
            attachmentScript1.Fire(m_attachment1Pos, m_attachment1Rot);
            //sets the bool to false and the timer to 0 so the cooldown essentailly resets
            a1_isFireable = false;
            m_cooldownTime1 = 0;
        }
    }

    private void OnFire2(InputValue input)
    {
        if(a2_isFireable == true)
        {
            attachmentScript2.Fire(m_attachment2Pos, m_attachment2Rot);
            a2_isFireable = false;
            m_cooldownTime2 = 0;
        }
        
    }

    private void OnFire3(InputValue input)
    {
        if(a3_isFireable == true)
        {
            attachmentScript3.Fire(m_attachment3Pos, m_attachment3Rot);
            a3_isFireable = false;
            m_cooldownTime3 = 0;
        }
        
    }

    private void OnFire4(InputValue input)
    {
        if(a4_isFireable == true)
        {
            attachmentScript4.Fire(m_attachment4Pos, m_attachment4Rot);
            a4_isFireable = false;
            m_cooldownTime4 = 0;
        }
        
    }


    
}
