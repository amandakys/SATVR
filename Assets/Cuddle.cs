using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Cuddle : MonoBehaviour {

	public GameObject comeCloser; 
	public GameObject wrapHands;
	public GameObject wasNice; 
	public GameObject menu;
	public GameObject child; 
	//public Text debug; 
	//public Camera camera; 

	private bool collided; 
	private bool acceptCollisions = false; 
	public OVRCameraRig camera; 
	private bool isClose;
	public bool toCuddle; 

	private Animator childAnim; 

	// Use this for initialization
	void Start () {
		toCuddle = false; 
		isClose = false;
		child = this.gameObject;
		childAnim = child.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			CuddleChild (); 
			collided = true; 
			//toCuddle = true;
		}

		if (!toCuddle) {
			comeCloser.SetActive (false); 
			//wasNice.SetActive (false); 
			wrapHands.SetActive (false);
		}
	
		if (distanceToChild () < 1.5f && toCuddle) {
	
			comeCloser.SetActive (false); 
			wasNice.SetActive (false); 
			wrapHands.SetActive (true);
			acceptCollisions = true; 

			//StartCoroutine(CuddleRoutine());
		} else if (toCuddle) {
			wasNice.SetActive (false); 
			comeCloser.SetActive (true); 
			wrapHands.SetActive (false);
			acceptCollisions = false; 
		}

		if (collided && toCuddle) {
			//collided = false; 
			childAnim.SetTrigger ("Cuddle");
			comeCloser.SetActive (false); 
			wrapHands.SetActive (false); 
			wasNice.SetActive (true);
			StartCoroutine (FadeNice ());
			toCuddle = false; 
			collided = false;
			//acceptCollisions = false; 
			//menu.SetActive (true); 
		}
			
	}

	public void CuddleChild () { 
		toCuddle = true; 
		collided = false;
		acceptCollisions = false; 
		childAnim.SetTrigger ("Scared"); 
		menu.SetActive (false); 
		//StartCoroutine(CuddleRoutine()); 
	}

	IEnumerator FadeNice() {
		yield return new WaitForSeconds (5);
		wasNice.SetActive (false); 
		comeCloser.SetActive (false); 
		//toCuddle = false; 
		//collided = false;
		acceptCollisions = false; 
		menu.SetActive (true); 
	}

	float distanceToChild() {
		Vector2 child2D = new Vector2 (child.transform.position.x, child.transform.position.z);
		Vector2 camera2D = new Vector2 (camera.transform.position.x, camera.transform.position.z); 
		float distance = Vector2.Distance (child2D, camera2D); 
		return distance; 
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		//debug.text = "OnTriggerEnter"; 
		if (otherCollider.name.Equals ("GrabVolumeBig") && toCuddle && acceptCollisions) {
			//debug.text = "hit";
			this.GetComponent<Haptics>().Vibrate(VibrationForce.Hard);
			collided = true; 
		}
	}

	public void inCuddle(bool b) {
		toCuddle = b; 
	}
		
}
