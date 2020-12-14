using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Rotate Skybox
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("First Battle");
    }

    public void ShowControls()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
