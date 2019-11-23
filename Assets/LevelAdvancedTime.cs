using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelAdvancedTime : MonoBehaviour
{
    // Start is called before the first frame update

    public float time;
    public string level;
    void Start()
    {
        Invoke("advance", time);
    }

    // Update is called once per frame
    void advance(){
        SceneManager.LoadScene(level);
    }
}
