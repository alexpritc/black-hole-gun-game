using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowControls : MonoBehaviour
{
    public GameObject desc;
    public GameObject controls;

    private bool isShowing;

    // Start is called before the first frame update
    void Start()
    {
        desc.SetActive(true);
        controls.SetActive(false);

        isShowing = false;
    }

    public void OnClick()
    {
        if (isShowing)
        {
            desc.SetActive(true);
            controls.SetActive(false);

            isShowing = false;
        }
        else {
            desc.SetActive(false);
            controls.SetActive(true);

            isShowing = true;
        }
    }

    

}
