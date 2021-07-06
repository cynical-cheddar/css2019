using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCameraReactor : AiBehaviour
{

    public Transform detectedPlayer;
    public AudioClip detectedSound;
    public AudioSource detectorAudiosource;

    public GameObject cameraHead;
    public bool headTracksPlayerOnDetection = false;
    public float timeUntilSquishySquishy = 4f;
    public bool squishTimerActivated = false;
    public float cooldown = 4f;
    // This is called when a detector has seen you.
    // How should we react?
	public override void setTarget (Transform target){
        detectedPlayer = target;
        if(detectorAudiosource != null && detectedSound != null){
            detectorAudiosource.clip = detectedSound;
            detectorAudiosource.Play();
        }
        startSquishTimer();

	}

    void Update(){
        if(squishTimerActivated){
            if(headTracksPlayerOnDetection){
                cameraHead.transform.LookAt(GameObject.FindWithTag("Player").transform);
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
    }

    void squishPlayer(){

    }

    void startSquishTimer(){
        cooldown = timeUntilSquishySquishy;
        squishTimerActivated = true;
    }
   

}
