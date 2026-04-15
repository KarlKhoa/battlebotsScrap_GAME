using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    private GameObject m_attachment1;
    private GameObject m_attachment2;
    private GameObject m_attachment3;
    private GameObject m_attachment4;


    void Awake() 
    {
        if( m_attachment1 == null)
        {
            m_attachment1 = GetComponentInParent<BotConstructor>().c_attachment1; //change code in future to add from player data class instead
        }
        Debug.Log(m_attachment1);

    }
    void Start()
    {
        //script instantiates object and offsets it from the parent, need to do this 3 more times but in different directions
        Instantiate(m_attachment1, this.transform.position + transform.forward * 0.7f, new Quaternion(0,0,0,0), this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
