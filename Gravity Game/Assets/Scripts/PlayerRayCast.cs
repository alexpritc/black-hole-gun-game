using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static bool hasPlayerGotBlackholeGun = false;

    public GameObject prefab;

    private int groundMask = 8;
    private int buttonMask = 12;

    private RaycastHit hit;

    private Vector3 fwd;

    // Update is called once per frame
    void FixedUpdate()
    {
        fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, fwd, Color.red);

        InteractWithButton();

        if (hasPlayerGotBlackholeGun)
        {
            UseBlackholeGun();
        }
    }

    void InteractWithButton()
    {
        if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.layer == buttonMask)
            {
                Debug.DrawRay(transform.position, fwd * hit.distance, Color.yellow);
                ButtonManager.isLookingAtButton = true;
            }
            else
            {
                ButtonManager.isLookingAtButton = false;
            }
        }
    }

    void UseBlackholeGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.layer == groundMask)
                {
                    Debug.DrawRay(transform.position, fwd * hit.distance, Color.yellow);
                    SpawnBlackhole(hit.point);
                }
            }
        }
    }

    void SpawnBlackhole(Vector3 location)
    {
        if (Blackhole.currentBlackhole == null)
        {
            Blackhole.currentBlackhole = Instantiate(prefab, location, prefab.transform.rotation);
        }
        else
        {
            Destroy(GameObject.Find("Blackhole(Clone)"));
            Blackhole.currentBlackhole = Instantiate(prefab, location, prefab.transform.rotation);
        }
    }
}
