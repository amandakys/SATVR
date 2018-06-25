using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Instr : MonoBehaviour {
	public Stage2InstrNav pastTrauma; 
	public Stage2InstrNav currentTrauma; 
	public GameObject child;
	private Animator childAnim; 
	private CuddleTrigger cuddleTrigger; 
	public Raise raiseController; 

	// Use this for initialization
	void Start () {

		childAnim = child.GetComponent<Animator> (); 
		cuddleTrigger = child.GetComponent<CuddleTrigger> (); 
		switch (PlayerPrefs.GetInt ("Stage4Toggle")) {
		case 0: 
			pastTrauma.gameObject.SetActive (true); 
			currentTrauma.gameObject.SetActive (false); 
			cuddleTrigger.cuddleNav = pastTrauma; 

			break; 
		case 1: 
			currentTrauma.gameObject.SetActive (true); 
			pastTrauma.gameObject.SetActive (false); 
			cuddleTrigger.cuddleNav = currentTrauma; 
			break; 
		}

		childAnim.SetTrigger ("Scared"); 
		/*
		if (currentTrauma.getCurrentInstr () == currentTrauma.getNumInstr () - 2 || pastTrauma.getCurrentInstr () == pastTrauma.getNumInstr ()) {
			raiseController.RaiseLights (); 
			raiseController.RaiseWall (); 
		}*/


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N) || OVRInput.GetDown (OVRInput.Button.One)) {
			NextInstr ();
		}


		if (currentTrauma.getCurrentInstr () == currentTrauma.getNumInstr () - 2 || pastTrauma.getCurrentInstr () == pastTrauma.getNumInstr ()) {
			raiseController.RaiseLights (); 
			raiseController.RaiseWall (); 
		}
	}

	public void NextInstr() {
		if (pastTrauma.gameObject.activeInHierarchy) {
			pastTrauma.NextInstr (); 
		} else if (currentTrauma.gameObject.activeInHierarchy) {
			currentTrauma.NextInstr (); 
		}
	}

	public void Speak() {
		if (pastTrauma.gameObject.activeInHierarchy) {
			pastTrauma.gameObject.GetComponent<InstrTTS> ().Speak(); 
		} else if (currentTrauma.gameObject.activeInHierarchy) {
			currentTrauma.gameObject.GetComponent<InstrTTS>().Speak (); 
		}
	}
}
