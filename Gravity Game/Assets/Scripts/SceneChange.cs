using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Game End")
        {
            SceneManager.LoadScene(sceneName);
            Blackhole.currentBlackhole = null;
        }
    }
}
