using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // This script goes on the activator.

    public GameObject cube;
    public GameObject goal;

    public GameObject newPos;
    private GameObject oldPos;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = goal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == cube)
        {
            goal.transform.position = newPos.transform.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == cube) {
            goal.transform.position = oldPos.transform.position;
        }
    }
}
