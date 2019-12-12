using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject startingPosition;

    void Start()
    {
        transform.position = startingPosition.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            transform.position = startingPosition.transform.position;
        }
    }
}
