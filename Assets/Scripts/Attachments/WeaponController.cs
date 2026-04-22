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
    private Weapon attachmentScript1;
    private Weapon attachmentScript2;
    private Weapon attachmentScript3;
    private Weapon attachmentScript4;

    private Vector2 fireInput;

    private bool fireAttachment1;
    private bool fireAttachment2;
    private bool previouslyFireAttachment2;
    private bool fireAttachment3;
    private bool fireAttachment4;
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
            m_attachment1 = GetComponentInParent<BotCloner>().c_attachment1;
        }

        if( m_attachment2 == null)
        {
            m_attachment2 = GetComponentInParent<BotCloner>().c_attachment2; 
        }

        if( m_attachment3 == null)
        {
            m_attachment3 = GetComponentInParent<BotCloner>().c_attachment3; 
        }

        if( m_attachment4 == null)
        {
            m_attachment4 = GetComponentInParent<BotCloner>().c_attachment4; 
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
       
    }


    //magic, i guess
    private void OnFire1(InputValue input)
    {
        //attachmentScript1.isMyWeapon = true;
        attachmentScript1.Fire(m_attachment1Pos, m_attachment1Rot);
    }

    private void OnFire2(InputValue input)
    {
        attachmentScript2.Fire(m_attachment2Pos, m_attachment2Rot);
    }

    private void OnFire3(InputValue input)
    {
        attachmentScript3.Fire(m_attachment3Pos, m_attachment3Rot);
    }

    private void OnFire4(InputValue input)
    {
        attachmentScript4.Fire(m_attachment4Pos, m_attachment4Rot);
    }


    
}
