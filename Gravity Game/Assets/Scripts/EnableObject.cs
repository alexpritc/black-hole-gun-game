using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToEnable02;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "TriggerNextButton")
        {
            objectToEnable.SetActive(true);
        }
        if (other.name == "TriggerNextButton02")
        {
            objectToEnable02.SetActive(true);
        }
    } 
    
}
