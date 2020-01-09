using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public static GameObject currentBlackhole;

    public LayerMask moveableObjectMask;

    private float pullDistance = 10f;
    private float maxMass = 3f;
    private float force = 500f;

    private bool isPulling;

    private Collider[] hitColliders;

    public AudioSource blackholeAudio;
    public AudioSource sparkAudio;

    private void Start()
    {
        blackholeAudio.Play();
    }

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
                sparkAudio.Play();
            }
            else
            {
                sparkAudio.Pause();
            }
        }
    }

    void PullObjectsInRadius()
    {
        // Are the objects' mass values small enough to be pulled?
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

