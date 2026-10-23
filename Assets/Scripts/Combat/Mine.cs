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
            //Debug.Log("Force added lmao");
        }
        StartCoroutine(Timer(timeUntilLive));

    }

    // Update is called once per frame
    void Update()
    {
        
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
<<<<<<< Updated upstream
        //if(isLive != false)
        //{
            Instantiate(explosion);
            Debug.Log("I sploded");
=======
        if (isLive != false)
        {
            GameObject proj = Instantiate(explosion);
            Explosion exp = proj.GetComponent<Explosion>();
            exp.AssignOwner(owner);
            //Debug.Log("I sploded");
>>>>>>> Stashed changes
            Destroy(this.gameObject);

        //}
    }
}
