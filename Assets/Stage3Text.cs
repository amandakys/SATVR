using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Text : MonoBehaviour {
	private Stage3Controller controller; 
	public GameObject intro; 
	// Use this for initialization
	void Start () {
		controller = this.GetComponentInChildren<Stage3Controller> (); 
	}
	
	// Update is called once per frame
	void Update () {

		if (OVRInput.GetDown (OVRInput.Button.One) || Input.GetKeyDown (KeyCode.N)) {
			if (intro.activeInHierarchy) {
				intro.SetActive (false); 
			} /*else {
				controller.NextInstr ();  
			}*/
		}
		
	}
}
