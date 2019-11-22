using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AiBehaviour : MonoBehaviour {


    // this in an interface type class.
    // to implement an ai behaviour, make a new script and write at the top:
    // public class newAiBehaviour : AiBehaviour {

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
