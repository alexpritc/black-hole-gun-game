using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowControls : MonoBehaviour
{
    public GameObject controls;

    private bool isShowing;

    // Start is called before the first frame update
    void Start()
    {
        controls.SetActive(false);

        isShowing = false;
    }

    public void OnClick()
    {
        if (isShowing)
        {
            controls.SetActive(false);

            isShowing = false;
        }
        else {
            controls.SetActive(true);

            isShowing = true;
        }
    }

    

}
