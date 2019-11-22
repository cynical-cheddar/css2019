using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public string firstScene;

   public void PlayGame()
    {
        SceneManager.LoadScene(firstScene);
    }

    public void Quitgame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
