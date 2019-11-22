using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLocationMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> cameras;
    GameObject activeCamera;

    void Start()
    {
        
    }

    public void shakeActiveCamera(){

    }
    void disableAllCameras(){
        foreach (GameObject cam in cameras){
            cam.SetActive(false);
        }
    }
    public void enableCamera(GameObject camera){
        disableAllCameras();
        camera.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
