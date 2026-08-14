using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botMaterialGet : MonoBehaviour
{
    private Client thisClient;
    private MeshRenderer thisMeshRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        thisClient = GetComponentInParent<Client>();
        thisMeshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        thisMeshRenderer.material = GameManager.Instance.GetMaterialForClient(thisClient);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
