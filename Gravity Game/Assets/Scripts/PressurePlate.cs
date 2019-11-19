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
            liftAnim.SetBool("liftDown", true);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = red;
            liftAnim.SetBool("liftDown", false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9 && 
            other.gameObject.GetComponent<Rigidbody>().mass >= 1)
        {
            isDown = true;
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
