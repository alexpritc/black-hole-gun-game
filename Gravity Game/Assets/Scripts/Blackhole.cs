using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public static GameObject currentBlackhole;

    public LayerMask moveableObjectMask;

    private float pullDistance = 5f;
    private float maxMass = 3f;
    private float force = 500f;

    private bool isPulling;

    private Collider[] hitColliders;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && PlayerRayCast.hasPlayerGotBlackholeGun)
        {
            if (currentBlackhole != null)
            {
                GameObject destroyThisBlackhole = GameObject.Find("Blackhole(Clone)");
                Destroy(destroyThisBlackhole);
                currentBlackhole = null;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentBlackhole != null)
        {
            FindCollidersWithinRadius();

            if (hitColliders != null)
            {
                PullObjectsInRadius();
            }
        }
    }

    void PullObjectsInRadius()
    {
        // Are the objects small enough to be pulled?
        // Yes - pull them.
        // No - do nothing.

        foreach (Collider hit in hitColliders)
        {
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();

            if (rb.mass <= maxMass)
            {
                Vector3 forceDirection = currentBlackhole.transform.position - rb.gameObject.transform.position;
                rb.AddForce(forceDirection * force * Time.deltaTime, ForceMode.Force);
            }
        }
    }

    void FindCollidersWithinRadius()
    {
        hitColliders = Physics.OverlapSphere(currentBlackhole.transform.position, pullDistance, moveableObjectMask);
    }
}

