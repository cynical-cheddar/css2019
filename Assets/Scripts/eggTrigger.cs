using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor")
        {
            this.transform.parent.gameObject.GetComponentInParent<playerControllerScript>().grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "floor")
        {
            this.transform.parent.gameObject.GetComponentInParent<playerControllerScript>().grounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
