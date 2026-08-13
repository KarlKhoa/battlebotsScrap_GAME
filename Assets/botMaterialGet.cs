using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botMaterialGet : MonoBehaviour
{
    private Client thisClient;
    private MeshRenderer thisMeshRenderer;
    private int listPos = 0;
    // Start is called before the first frame update
    void awake()
    {
        thisClient = GetComponentInParent<Client>();
        thisMeshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        foreach(var client in GameManager.Instance.registeredClients)
        {
            if(client == thisClient)
            {
                thisMeshRenderer.materials = GameManager.Instance.BotMatRegistry(listPos);
            }
            else
            {
                listPos++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
