using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class WeaponController : MonoBehaviour
{

    //holds weapon script of attachment to use the fire function on it
    private Weapon attachmentScriptFront;
    private Weapon attachmentScriptBack;
    private Weapon attachmentScriptRight;
    private Weapon attachmentScriptLeft;

    private Client client;

    //variable to hold the cooldown variable from the weapon script
    private float aFrontCooldown;
    private float aBackCooldown;
    private float aRightCooldown;
    private float aLeftCooldown;

    //this is the variable that the timer uses
    private float m_cooldownTime1 = 0;
    private float m_cooldownTime2 = 0;
    private float m_cooldownTime3 = 0;
    private float m_cooldownTime4 = 0;

    private bool front_isFireable;
    private bool back_isFireable;
    private bool right_isFireable;
    private bool left_isFireable;

    private Vector3 m_attachmentFrontPos;
    private Vector3 m_attachmentBackPos;
    private Vector3 m_attachmentRightPos;
    private Vector3 m_attachmentLeftPos;

    private Quaternion m_attachmentFrontRot;
    private Quaternion m_attachmentBackRot;
    private Quaternion m_attachmentRightRot;
    private Quaternion m_attachmentLeftRot;

    public bool isShieldUp;
    public bool didHitShield;



    void Awake() 
    {
        client = GetComponentInParent<Client>();

    }
    void Start()
    {

        //offsets position from parent 
        Vector3 attachmentPerch = this.transform.position + transform.up * 0.3f;

        attachmentScriptFront = BuildAndAttachWeapon(client.c_attachmentFront, attachmentPerch + transform.forward * 0.6f, Quaternion.identity);
        attachmentScriptBack = BuildAndAttachWeapon(client.c_attachmentBack, attachmentPerch + transform.forward * -0.6f, Quaternion.LookRotation(Vector3.back,Vector3.up));
        attachmentScriptRight = BuildAndAttachWeapon(client.c_attachmentRight, attachmentPerch + transform.right * 0.6f, Quaternion.LookRotation(Vector3.right,Vector3.up));
        attachmentScriptLeft = BuildAndAttachWeapon(client.c_attachmentLeft, attachmentPerch + transform.right * -0.6f, Quaternion.LookRotation(Vector3.left,Vector3.up));


    }

    //instantiate weapons at attachment transforms, make their Owner client
    private Weapon BuildAndAttachWeapon(Weapon attachment, Vector3 attachmentOffset, Quaternion attachmentOrientation)
    {
        if(!attachment) return null;
        var newWeapon = Instantiate(attachment, attachmentOffset, attachmentOrientation, this.transform);
        newWeapon.owner = client; 
        return newWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        //repeat in update to keep track of pos/rotation but slightly different offset because otherwise it doesn't work
        AttachmentPosTracker();
    }

    void AttachmentPosTracker()
    {
        m_attachmentFrontPos = this.transform.position + transform.forward * 0.7f + transform.up * 0.15f;
        m_attachmentFrontRot = this.transform.rotation;
        m_attachmentBackPos = this.transform.position + transform.forward * -0.7f + transform.up * 0.15f;
        m_attachmentBackRot = this.transform.rotation;
        m_attachmentRightPos = this.transform.position + transform.right * 0.7f + transform.up * 0.15f;
        m_attachmentRightRot = this.transform.rotation;
        m_attachmentLeftPos = this.transform.position + transform.right * -0.7f + transform.up * 0.15f;
        m_attachmentLeftRot = this.transform.rotation;
    }

    void FixedUpdate()
    {
        //timer to check if the weapon is fireable
        if(aFrontCooldown <= m_cooldownTime1)
        {
            front_isFireable = true;
        }
        else
        {
            m_cooldownTime1 ++;
        }

        if (aBackCooldown <= m_cooldownTime2)
        {
            back_isFireable = true;
        }
        else
        {
            m_cooldownTime2++;
        }

        if (aRightCooldown <= m_cooldownTime3)
        {
            right_isFireable = true;
        }
        else
        {
            m_cooldownTime3++;
        }

        if (aLeftCooldown <= m_cooldownTime4)
        {
            left_isFireable = true;
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
        if(front_isFireable == true)
        {
            //if attachmentScript1 exists, Fire using provided position + rotation
            attachmentScriptFront?.Fire(m_attachmentFrontPos, m_attachmentFrontRot);
            //sets the bool to false and the timer to 0 so the cooldown essentailly resets
            front_isFireable = false;
            m_cooldownTime1 = 0;
        }
    }

    private void OnFire2(InputValue input)
    {
        if(right_isFireable == true)
        {
            attachmentScriptRight?.Fire(m_attachmentRightPos, m_attachmentRightRot);
            right_isFireable = false;
            m_cooldownTime2 = 0;
        }
        
    }

    private void OnFire3(InputValue input)
    {
        if(back_isFireable == true)
        {
            attachmentScriptBack?.Fire(m_attachmentBackPos, m_attachmentBackRot);
            back_isFireable = false;
            m_cooldownTime3 = 0;
        }
        
    }

    private void OnFire4(InputValue input)
    {
        if(left_isFireable == true)
        {
            attachmentScriptLeft?.Fire(m_attachmentLeftPos, m_attachmentLeftRot);
            left_isFireable = false;
            m_cooldownTime4 = 0;
        }
        
    }


    
}
