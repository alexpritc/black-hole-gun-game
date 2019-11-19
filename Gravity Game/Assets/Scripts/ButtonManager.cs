using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static bool isLookingAtButton;

    public GameObject[] spawnPoints;
    public GameObject prefab;

    private int numberOfTimesPressed = 0;

    // Update is called once per frame
    void Update()
    {
        if (isLookingAtButton && Input.GetKeyUp(KeyCode.E))
        {
            if (Blackhole.currentBlackhole == null)
            {
                Blackhole.currentBlackhole = Instantiate(prefab, spawnPoints[numberOfTimesPressed].transform.position, prefab.transform.rotation);
            }
            else
            {
                Destroy(GameObject.Find("Blackhole(Clone)"));
                Blackhole.currentBlackhole = Instantiate(prefab, spawnPoints[numberOfTimesPressed].transform.position, prefab.transform.rotation);
            }

            numberOfTimesPressed++;

            if (numberOfTimesPressed == 3)
            {
                numberOfTimesPressed = 0;
            }
        }
    }
}
