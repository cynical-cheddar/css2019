using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuController : MonoBehaviour
{
    public string mainMenuSceneName;
    public string lvl0Name;
    public string lvl1Name;
    public string lvl2Name;
    public string lvl3Name;
    public string lvl4Name;

    public void BackToMain()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void lvl0Button()
    {
        SceneManager.LoadScene(lvl0Name);
    }
    public void lvl1Button()
    {
        SceneManager.LoadScene(lvl1Name);
    }
    public void lvl2Button()
    {
        SceneManager.LoadScene(lvl2Name);
    }
    public void lvl3Button()
    {
        SceneManager.LoadScene(lvl3Name);
    }
    public void lvl4Button()
    {
        SceneManager.LoadScene(lvl4Name);
    }
}
