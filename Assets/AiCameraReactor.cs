using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCameraReactor : AiBehaviour
{

    public GameObject skySquisher;
    public float speed = 5f;
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
                startSquishTimer();
        if(detectorAudiosource != null && detectedSound != null){
            detectorAudiosource.clip = detectedSound;
            detectorAudiosource.Play();
        }
        if(flare != null){
           // flare.brightness = flareIntensitySeen;
           StartCoroutine(lerpFlareBrightness(originalFlareIntensity, flareIntensitySeen, 1f));
        }

	}

    IEnumerator lerpFlareBrightness(float start, float end, float time){
       float ElapsedTime = 0f;
       float cur = start;
        while (ElapsedTime <= time)
        { // until one second passed

            ElapsedTime += Time.deltaTime;
            cur = Mathf.Lerp(start, end, (ElapsedTime/ time)); // lerp from A to B in one second
            flare.brightness = cur;
            yield return null; // wait for next frame
        } 
        
    }

    void Update(){
        if(squishTimerActivated){
            if(headTracksPlayerOnDetection && cameraHeadRotator != null){
                cameraHeadRotator.transform.LookAt(detectedPlayer);
               // var step = speed * Time.deltaTime;

                // Rotate our transform a step closer to the target's.
                
               // cameraHeadRotator.transform.rotation = Quaternion.RotateTowards(cameraHeadRotator.transform.rotation, detectedPlayer.rotation, step);

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
                                squishTimerActivated = false;
                GetComponent<EnemyVisionAi>().playerSeen = false;
                GetComponent<EnemyVisionAi>().clearLists();
            }
        }
        else{
            cameraHeadRotator.transform.rotation = Quaternion.Lerp(cameraHeadRotator.transform.rotation, originalRot, 2f);
             if(flare != null){
                 StartCoroutine(lerpFlareBrightness(flareIntensitySeen, originalFlareIntensity, 1f));
             }
        }
    }

    void squishPlayer(){
        Instantiate(skySquisher, detectedPlayer.position, transform.rotation);
    }

    void startSquishTimer(){
        cooldown = timeUntilSquishySquishy;
        squishTimerActivated = true;
    }
   

}
