﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AiBehaviour : MonoBehaviour {



	public virtual void setTarget (Transform target){
	}
   
	public virtual void unclaimCover (){
	}
	public virtual bool setHasTarget (bool hasTarget){
		return false;
	}
	public virtual bool getHasTarget (){
		return false;
	}
	public void applyPain(){

	}
	void restoreSpeed(){

	}
    public virtual void removeTarget()
    {

    }

}
