using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Projectile
{
    [SerializeField] private float _baseDamage;
    [SerializeField] private float launchSpeed;
    [SerializeField] private float timeUntilLive;
    [SerializeField] private GameObject explosion;

    private Rigidbody rb;
    private bool isLive;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        if (rb != null)
        {
            rb.AddForce(transform.forward * launchSpeed);
        }
        StartCoroutine(Timer(5, isLive));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer(float time, bool trigger)
    {
        new WaitForSeconds(time);
        trigger = true;
        yield return true;
    }

    public override void Detonate()
    {
        if(isLive != false)
        {
            Instantiate(explosion);
            Debug.Log("I sploded");
            Destroy(this.gameObject);

        }
    }
}
