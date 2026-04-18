using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{

    private GameObject m_attachment1;
    private GameObject m_attachment2;
    private GameObject m_attachment3;
    private GameObject m_attachment4;

    //holds weapon script of attachemnt to use the fire function on it
    private Weapon attachmentScript1;

    private Vector2 fireInput;

    private bool fireAttachment1;
    private bool fireAttachment2;
    private bool fireAttachment3;
    private bool fireAttachment4;

    void Awake() 
    {
        if( m_attachment1 == null)
        {
            m_attachment1 = GetComponentInParent<BotConstructor>().c_attachment1; //change code in future to add from player data class instead
        }
        Debug.Log(m_attachment1);

        if( m_attachment2 == null)
        {
            m_attachment2 = GetComponentInParent<BotConstructor>().c_attachment2; //change code in future to add from player data class instead
        }
        Debug.Log(m_attachment2);

        if( m_attachment3 == null)
        {
            m_attachment3 = GetComponentInParent<BotConstructor>().c_attachment3; //change code in future to add from player data class instead
        }
        Debug.Log(m_attachment3);

        if( m_attachment4 == null)
        {
            m_attachment4 = GetComponentInParent<BotConstructor>().c_attachment4; //change code in future to add from player data class instead
        }
        Debug.Log(m_attachment4);

    }
    void Start()
    {
        //script instantiates object and offsets it from the parent
        Instantiate(m_attachment1, this.transform.position + transform.forward * 0.7f, new Quaternion(0,0,0,0), this.transform);
        Instantiate(m_attachment2, this.transform.position + transform.forward * -0.7f, new Quaternion(0,0,0,0), this.transform);
        Instantiate(m_attachment3, this.transform.position + transform.right * 0.7f, new Quaternion(0,0,0,0), this.transform);
        Instantiate(m_attachment4, this.transform.position + transform.right * -0.7f, new Quaternion(0,0,0,0), this.transform);

        attachmentScript1 = m_attachment1.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks the input and changes a bool to allow for movement in fixed update
        if(fireInput == new Vector2(0,1))
        {
            fireAttachment1 = true;
        }

        if(fireInput == new Vector2(1,0))
        {
            fireAttachment4 = true;
        }

        if(fireInput == new Vector2(0,-1))
        {
            fireAttachment2 = true;
        }

        if(fireInput == new Vector2(-1,0))
        {
            fireAttachment3 = true;
        }
    }

    void FixedUpdate()
    {
        //executes the input
        if(fireAttachment1 == true)
        {
            //this script is going to be repeated for every other variable
            attachmentScript1.Fire();
            fireAttachment1 = false;
            Debug.Log("Attachment 1 Fired!");
        }
        if(fireAttachment2 == true)
        {
            fireAttachment2 = false;
            Debug.Log("Attachment 2 Fired!");
        }
        if(fireAttachment3 == true)
        {
            fireAttachment3 = false;
            Debug.Log("Attachment 3 Fired!");
        }
        if(fireAttachment4 == true)
        {
            fireAttachment4 = false;
            Debug.Log("Attachment 4 Fired");
        }
    }

    private void OnFire(InputValue input)
    {
        fireInput = input.Get<Vector2>();
    }
}
