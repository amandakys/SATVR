using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
public class CuddleTrigger : MonoBehaviour {
	public Text debug; 
	public Stage2InstrNav cuddleNav; 
	public Raise raiseController; 

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		debug.text = "OnTriggerEnter"; 
		if (otherCollider.name.Equals ("GrabVolumeBig")) {
			debug.text = "hit";
			cuddleNav.SetCollided (true);  

			if (SceneManager.GetActiveScene ().name.Equals ("Stage4")) {
				debug.text = "raised";
						raiseController.RaiseWall (); 
						raiseController.RaiseLights (); 
						//instructionLarge.SetActive (false); 
			}
		}
	}
}
