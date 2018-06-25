using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HandsTrigger : MonoBehaviour {
	public TrackHands trackHands; 
	public Text debug; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		debug.text = "onTriggerEnter";
			
		if (otherCollider.name.Equals ("GrabVolumeBig")) {
			debug.text = this.gameObject.name; 
			trackHands.CatchCollisions (this.gameObject.name); 

		}
	}	
}
