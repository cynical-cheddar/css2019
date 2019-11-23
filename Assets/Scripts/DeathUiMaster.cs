using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathUiMaster : MonoBehaviour
{
    // Start is called before the first frame update


    public string mainMenuLevelName = "";
    public void retartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit(){
        SceneManager.LoadScene(mainMenuLevelName);
    }
}
