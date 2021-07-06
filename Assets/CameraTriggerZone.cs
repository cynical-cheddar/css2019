using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerZone : MonoBehaviour
{
    public CameraLocationMaster cameraLocationMaster;
    public GameObject correspondingCamera;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            cameraLocationMaster.enableCamera(correspondingCamera);
        }
    }
}
