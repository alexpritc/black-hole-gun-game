using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;

    public void ButtonClicked()
    {
        SceneManager.LoadScene(sceneName);
        Blackhole.currentBlackhole = null;

        if (sceneName == "Controls" || sceneName == "Menu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Game End")
        {
            SceneManager.LoadScene(sceneName);
            Blackhole.currentBlackhole = null;


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
