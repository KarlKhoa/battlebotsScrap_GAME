using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Projectile
{
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
            rb.AddForce(transform.forward * _projectileSpeed);
            //Debug.Log("Force added lmao");
        }
        StartCoroutine(Timer(timeUntilLive));

    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        IsLive();
    }

    private void IsLive()
    {
        isLive = true;
    }

    public override void Detonate()
    {
        if (isLive != false)
        {
            GameObject proj = Instantiate(explosion, transform.position, transform.rotation);
            Explosion exp = proj.GetComponent<Explosion>();
            exp.AssignOwner(owner);
            //Debug.Log("I sploded");
            Destroy(this.gameObject);
        }
    }
}
