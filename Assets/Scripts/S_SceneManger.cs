using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManger : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Merge Scene");
    }
}
