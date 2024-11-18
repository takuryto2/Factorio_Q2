using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MenuManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
