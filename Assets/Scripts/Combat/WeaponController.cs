using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{

    //private GameObject bulletPrefab; //bullet (all of these labelled bullet do the same as m_bulletScript = weaponID in Gun but I thought doing it this way would help for whatever reason.)

    //holds weapon script of attachment to use the fire function on it
    [SerializeField]
    private Weapon attachmentScript1;
    private Weapon attachmentScript2;
    private Weapon attachmentScript3;
    private Weapon attachmentScript4;
    //private Weapon bulletScript; //bullet

    private BotSpawner botSpawner;

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

    private static int m_weaponID;



    void Awake() 
    {
        botSpawner = GetComponentInParent<BotSpawner>();

    }
    void Start()
    {

        //offsets position from parent 
        Vector3 attachmentPerch = this.transform.position + transform.up * 0.15f;

        attachmentScript1 = BuildAndAttachWeapon(botSpawner.c_attachment1, attachmentPerch + transform.forward * 0.6f, Quaternion.identity);
        attachmentScript2 = BuildAndAttachWeapon(botSpawner.c_attachment2, attachmentPerch + transform.forward * -0.6f, Quaternion.identity);
        attachmentScript3 = BuildAndAttachWeapon(botSpawner.c_attachment3, attachmentPerch + transform.right * 0.6f, Quaternion.identity);
        attachmentScript4 = BuildAndAttachWeapon(botSpawner.c_attachment4, attachmentPerch + transform.right * -0.6f, Quaternion.identity);


    }

    //instantiate weapons at attachment transforms, make their Owner client
    private Weapon BuildAndAttachWeapon(Weapon attachment, Vector3 attachmentOffset, Quaternion attachmentOrientation)
    {
        if(!attachment) return null;
        var newWeapon = Instantiate(attachment, attachmentOffset, attachmentOrientation, this.transform);
        newWeapon.Owner = botSpawner; 
        return newWeapon;
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
            //Instantiate(bulletPrefab, m_attachment1Pos, m_attachment1Rot, this.transform); //successfully makes bullet a child of Bot but does not fix the ID thing
            attachmentScript1?.Fire(m_attachment1Pos, m_attachment1Rot);
            //sets the bool to false and the timer to 0 so the cooldown essentailly resets
            a1_isFireable = false;
            m_cooldownTime1 = 0;
        }
    }

    private void OnFire2(InputValue input)
    {
        if(a2_isFireable == true)
        {
            attachmentScript2?.Fire(m_attachment2Pos, m_attachment2Rot);
            a2_isFireable = false;
            m_cooldownTime2 = 0;
        }
        
    }

    private void OnFire3(InputValue input)
    {
        if(a3_isFireable == true)
        {
            attachmentScript3?.Fire(m_attachment3Pos, m_attachment3Rot);
            a3_isFireable = false;
            m_cooldownTime3 = 0;
        }
        
    }

    private void OnFire4(InputValue input)
    {
        if(a4_isFireable == true)
        {
            attachmentScript4?.Fire(m_attachment4Pos, m_attachment4Rot);
            a4_isFireable = false;
            m_cooldownTime4 = 0;
        }
        
    }


    
}
