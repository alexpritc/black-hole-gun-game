using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    public Material pink;
    public Material red;

    private Animator anim;

    private bool isDown;

    public AudioSource ppAudio;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (isDown)
        {
            gameObject.GetComponent<MeshRenderer>().material = pink;
            anim.SetBool("isDown", true);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = red;
            anim.SetBool("isDown", false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9 &&
            other.gameObject.GetComponent<Rigidbody>().mass >= 1)
        {
            isDown = true;

            ppAudio.Play();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 9 &&
            other.gameObject.GetComponent<Rigidbody>().mass >= 1)
        {
            isDown = false;
        }
    }
}
