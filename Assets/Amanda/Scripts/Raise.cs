using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raise : MonoBehaviour {

	public Light spotlight1;
	public Light spotlight2; 
	public Light pointlight1;
	public Light pointlight2; 
	public GameObject wall; 
	private bool raiseLights; 
	private bool raiseWall; 
	private bool dimSpots; 


	// Use this for initialization
	void Start () {
		raiseLights = false; 
		raiseWall = false; 
		dimSpots = false; 
		//StartCoroutine (Raise ());

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
			RaiseLights (); 
			RaiseWall (); 
		}
		if (raiseLights) {
			pointlight1.intensity = Mathf.Lerp (pointlight1.intensity, 1.0f, Time.deltaTime * 0.1f); 
			pointlight2.intensity = Mathf.Lerp (pointlight2.intensity, 1.0f, Time.deltaTime * 0.1f); 
	
		}

		if (raiseWall) {
			Vector3 newPos = new Vector3 (wall.transform.position.x, 6.5f, wall.transform.position.z); 
			wall.transform.position = Vector3.Lerp (wall.transform.position, newPos, Time.deltaTime * 0.1f); 
			//wall.transform.position.y = Mathf.Lerp (wall.transform.position.y, 274.0f, Time.deltaTime * 0.5f);
		}

		if (dimSpots) {
			spotlight1.intensity = Mathf.Lerp (spotlight1.intensity, 0.0f, Time.deltaTime * 0.3f);
			spotlight2.intensity = Mathf.Lerp (spotlight2.intensity, 0.0f, Time.deltaTime * 0.3f);
		}
	}

	IEnumerator RaiseCoroutine () {
		yield return new WaitForSeconds (10); 
		Debug.Log ("Raise lights"); 
		raiseLights = true; 

		yield return new WaitForSeconds(5);
		Debug.Log ("Dim Spots");
		dimSpots = true; 

		yield return new WaitForSeconds (10);
		Debug.Log("Raise Wall");
		raiseWall = true; 
	}

	public void RaiseWall() {
		raiseWall = true; 
	}

	public void RaiseLights() {
		raiseLights = true; 
		dimSpots = true; 
	}
}
