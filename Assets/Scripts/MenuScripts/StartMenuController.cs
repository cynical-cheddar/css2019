using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public string firstScene;
    public string DebugScene;

   public void PlayGame()
    {
        SceneManager.LoadScene(firstScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void DebugGame()
    {
        Debug.Log("Debug mode");
        SceneManager.LoadScene(DebugScene);
    }
}
