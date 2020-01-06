using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //public GameObject startingPosition;

    private AudioSource cubeHit;
    private AudioClip clip;

    void Start()
    {
        //transform.position = startingPosition.transform.position;
        cubeHit = GetComponent<AudioSource>();
        clip = cubeHit.clip;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Plane")
    //    {
    //        transform.position = startingPosition.transform.position;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (cubeHit.isPlaying) {
            cubeHit.Pause();
        }

        float audioLevel = collision.relativeVelocity.magnitude / 10.0f;
        cubeHit.PlayOneShot(clip, audioLevel);
    }
}
