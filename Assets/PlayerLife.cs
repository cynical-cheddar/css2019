using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DeathUI;
     public GameObject squishGib;
    public AudioClip squishSound;
    public void die(){
        Debug.Log("die");
        if(DeathUI != null) Instantiate(DeathUI, transform.position, transform.rotation);
        if(squishGib != null)        Instantiate(squishGib, transform.position, transform.rotation);

        GetComponent<AudioSource>().clip = squishSound;
        GetComponent<AudioSource>().Play();
        GetComponent<Rigidbody>().isKinematic = true;
        transform.parent.GetComponent<playerControllerScript>().enabled = false;
        gameObject.SetActive(false);
    }
}
