using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCameraReactor : AiBehaviour
{

    public LensFlare flare;
    public float flareIntensitySeen = 1f;
    float originalFlareIntensity = 0.4f;
    public Transform detectedPlayer;
    public AudioClip detectedSound;
    public AudioSource detectorAudiosource;

    public GameObject cameraHeadRotator;
    public bool headTracksPlayerOnDetection = false;
    public float timeUntilSquishySquishy = 4f;
    public bool squishTimerActivated = false;
    public float cooldown = 4f;

    Quaternion originalRot;
    // This is called when a detector has seen you.
    // How should we react?

    void Start(){
        if(cameraHeadRotator != null){
            originalRot = cameraHeadRotator.transform.rotation;
        }
        if(flare != null){
            originalFlareIntensity = flare.brightness;
        }
        
    }
	public override void setTarget (Transform target){
        detectedPlayer = target;
        if(detectorAudiosource != null && detectedSound != null){
            detectorAudiosource.clip = detectedSound;
            detectorAudiosource.Play();
        }
        if(flare != null){
            flare.brightness = flareIntensitySeen;
        }
        startSquishTimer();

	}

    void Update(){
        if(squishTimerActivated){
            if(headTracksPlayerOnDetection && cameraHeadRotator != null){
                cameraHeadRotator.transform.LookAt(detectedPlayer);


            }
            // check that the player is still in vision each frame:
            GetComponent<EnemyVisionAi>().getPlayersInRange();
            GetComponent<EnemyVisionAi>().getPlayersInVision();
            if(GetComponent<EnemyVisionAi>().playersInVision.Count >= 1){
                cooldown -= Time.deltaTime;
            }
            // if you cannot be seen
            else{
                squishTimerActivated = false;
                GetComponent<EnemyVisionAi>().playerSeen = false;
                GetComponent<EnemyVisionAi>().clearLists();
            }
            if(cooldown <= 0){

                // DO THE BIG SQUISH
                squishPlayer();
            }
        }
        else{
            cameraHeadRotator.transform.rotation = originalRot;
             if(flare != null){
                 flare.brightness = originalFlareIntensity;
             }
        }
    }

    void squishPlayer(){

    }

    void startSquishTimer(){
        cooldown = timeUntilSquishySquishy;
        squishTimerActivated = true;
    }
   

}
