﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquisherCollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider){

        if(collider.gameObject.tag == "Player"){
            collider.gameObject.GetComponent<PlayerLife>().die();
        }
    }
}
