using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TrackHands : MonoBehaviour {
	public OVRCameraRig camera; 
	public Animator childAnim; 
	private Vector3 head;
	private Vector3 rightHand; 
	private Vector3 leftHand; 
	private bool isAbove; 
	private bool isRaised; 
	public Text debug;
	public Text debug1; 
	public Text debug2; 

	public bool startTracking;
	private bool dance; 
	private bool dancing; 
	private int collisionCount; 
	private bool nextCollision; //false is left, true is right; 


	private float lastCollision; 
	private bool noMotion; 

	// Use this for initialization
	void Start () {
		isRaised = false; 
		noMotion = false; 
		
	}

	// Update is called once per frame
	void Update () {
		//detecting hand raise 

		head = UnityEngine.XR.InputTracking.GetLocalPosition (UnityEngine.XR.XRNode.Head);
		rightHand = UnityEngine.XR.InputTracking.GetLocalPosition (UnityEngine.XR.XRNode.RightHand);
		leftHand = UnityEngine.XR.InputTracking.GetLocalPosition (UnityEngine.XR.XRNode.LeftHand);

		if (rightHand.y >= head.y) {
			if (!isRaised) {
				childAnim.SetTrigger ("Raise0"); 
//				childAnim.SetBool ("Raised", true); 
				isRaised = true; 
				Debug.Log ("raised"); 
			}
		} else {
			if (isRaised) {
				childAnim.SetTrigger ("Lower"); 
				//childAnim.SetBool ("Raised", false); 
				isRaised = false; 
				Debug.Log ("lowered"); 
			}
		}

		//detecting hand motion for dancing 
		if (dance) {
			debug.text = "dance"; 
			childAnim.SetTrigger ("Dance"); 
			dance = false; 
			dancing = true; 
		}

		noMotion = (Time.time - lastCollision) > 2f; 

		if (dancing && noMotion) {
			debug.text = "noMotion true"; 
			ResetMotionTracking ();
			dancing = false; 
		}

		if (noMotion) {
			collisionCount = 0; 
		}



		/*
		if (OVRInput.GetUp (OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetUp (OVRInput.Button.SecondaryHandTrigger)) {
			ResetMotionTracking (); 
			debug.text = "StoppedTracking";
		}

		if (OVRInput.GetDown (OVRInput.Button.PrimaryHandTrigger) && OVRInput.GetDown (OVRInput.Button.SecondaryHandTrigger)) {
			startTracking = true; 
			debug.text = "StartTracking";
		}
	
		if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)) {
			//while both triggers are held down 
			startTracking = true; 
			debug.text = "holding";
			if (dance) {
				debug.text = "dance"; 
				childAnim.SetTrigger ("Dance"); 
				dance = false; 
			}

		}*/
	
	
	}

	public void ResetMotionTracking() {
		collisionCount = 0; 
		//startTracking = false; 
		childAnim.SetTrigger ("Idle");
	}

	public void CatchCollisions(string colliderName) {
		if (!dancing) {
			lastCollision = Time.time;
			switch (colliderName) {
			case "RightCollider":
				if (collisionCount == 0) {
					debug.text = "first R";
					//this is first collision
					//next collision is left; 
					nextCollision = false; 
					collisionCount++; 
				} else if (collisionCount == 3) {
					//final collision
					debug.text = "final R";
					if (nextCollision == true) {
						//accept collision
						dance = true; 
					}
				} else {
					debug.text = "R collision";
					//only accept collision if is it on the correct side. 
					if (nextCollision == true) {
						collisionCount++; 
						nextCollision = false; 
					}
				}
				break;
			case "LeftCollider": 	
				if (collisionCount == 0) {
					debug.text = "first L";
					//this is first collision
					//next collision is right; 
					nextCollision = true; 
					collisionCount++; 
				} else if (collisionCount == 3) {
					//final collision
					debug.text = "final L";
					if (nextCollision == false) {
						//accept collision
						dance = true; 
					}
				} else {
					//only accept collision if is it on the correct side. 
					debug.text = "L collision";
					if (nextCollision == false) {
						collisionCount++; 
						nextCollision = true; 
					}
				}
				break;
			}
		} else {
			//already dancing, collisions must continue 
			lastCollision = Time.time; 
			debug.text = "else dance"; 
		}
	}
}
