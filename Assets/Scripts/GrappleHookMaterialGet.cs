
using UnityEngine;

public class GrappleHookMaterialGet : MonoBehaviour
{
    //private Client _thisClient;
    private MeshRenderer _thisMeshRenderer;
    
    void Awake()
    {
        //_thisClient = GetComponentInParent<Hook.Owner.OwningClient>();
        _thisMeshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        var thisClient = GetComponentInParent<Client>();
        _thisMeshRenderer.material = GameManager.Instance.PlayerVisuals.GetGrappleMatForClient(thisClient);
    }
}
