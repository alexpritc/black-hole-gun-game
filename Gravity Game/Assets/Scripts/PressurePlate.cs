using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject lift;

    public Material pink;
    public Material red;

    private Animator liftAnim;

    private bool isDown;

    public AudioSource ppAudio;

    // Start is called before the first frame update
    void Start()
    {
        liftAnim = lift.GetComponent<Animator>();
    }

    void Update()
    {
        if (isDown)
        {
            gameObject.GetComponent<MeshRenderer>().material = pink;
            liftAnim.SetBool("isDown", true);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = red;
            liftAnim.SetBool("isDown", false);
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
