using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCameraReactor : AiBehaviour
{

    public Transform detectedPlayer;
    public AudioClip detectedSound;
    public AudioSource detectorAudiosource;
    // This is called when a detector has seen you.
    // How should we react?
	public override void setTarget (Transform target){
        detectedPlayer = target;
        if(detectorAudiosource != null && detectedSound != null){
            detectorAudiosource.clip = detectedSound;
            detectorAudiosource.Play();
        }

	}
   

}
