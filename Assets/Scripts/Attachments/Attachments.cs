using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachments : MonoBehaviour
{
    
    private bool activated;

    public AttachmentType attachmentType = new AttachmentType();

    public enum AttachmentType
    {
        Passive,
        Activate,
        Shoot
    }

    void Update()
    {
        if(activated == true)
        {
            
        }
    }

    void Activate()
    {

    }

}