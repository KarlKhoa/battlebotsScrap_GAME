using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//bugs: does not recognise owner
public class Grapple : Weapon
{
    public Projectile projectile;

    public float grappleRange = 10f;
    public float grappleDelay;

    public LayerMask canBeGrappled;

    private Vector3 hookPoint;

    private float cooldownTime = 2.0f;
    private bool isCooldownOver = true;

    private bool isGrappling;


    public override void Fire(Vector3 pos, Quaternion rot)
    {
        //if (isCooldownOver)
        //{
        //    var hook = Instantiate(projectile.gameObject, pos, rot); //iterates a hook at position of grapple in WeaponController
        //    hook.GetComponent<Projectile>().owner = owner; //makes hook's Owner same as our client

        //    StartCoroutine(ResetTimer());
        //}
        //else { return; }

        if (!isCooldownOver) return;
        isGrappling = true;

        //send out raycast forward from our firing position to the end of our range
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grappleRange, canBeGrappled)) //if we hit something that is grappleable
        {
            hookPoint = hit.point;
            Invoke(nameof(DragPlayerToHook), grappleDelay);
        }
        else
        {
            hookPoint = pos + transform.forward * grappleRange;
            Invoke(nameof(StopGrapple), grappleDelay);
        }
    }

    private IEnumerator ResetTimer()
    {
        //Debug.Log("Resetting" + this + " cooldown...");
        isCooldownOver = false;
        yield return new WaitForSeconds(cooldownTime);
        isCooldownOver = true;
        //Debug.Log(this + "is ready!");
    }

    void FixedUpdate()
    {
        canBeGrappled = LayerMask.GetMask("Grappleable");
    }

    private void DragPlayerToHook()
    {
        var playerController = GetComponentInParent<PlayerController>();
        playerController.JumpToPosition(hookPoint);
        Invoke(nameof(StopGrapple), 1f);
    }

    private void StopGrapple()
    {
        isGrappling = false;
        StartCoroutine(ResetTimer());
    }
}
