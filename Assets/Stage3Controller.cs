using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage3Controller : MonoBehaviour {
	public GameObject buttons; 
	private int count; 

	public GameObject instructionLarge; 
	public Stage2InstrNav happySinging; 
	public Stage2InstrNav sadSinging; 
	public Stage2InstrNav dance;
	public Stage2InstrNav massage; 
	public Stage2InstrNav pledge; 
	public ControllerSelection.OVRPointerVisualizer pointer;
	public MainMenu menu;
	public GameObject stage3Menu; 
	public Canvas baseCanvas;
	public Canvas instructionCanvas;
	public GameObject intro; 
	public ScreenController screen; 
	// Use this for initialization
	void Start () {
		//screen.transform.position = new Vector3 (-0.01, 0.41, 3.95); 
		//lowerScreen = false; 
		count = 0; 
		intro.SetActive (true); 
		instructionLarge.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (OVRInput.GetDown (OVRInput.Button.One) || Input.GetKeyDown (KeyCode.N)) {
			if (intro.activeInHierarchy) {
				intro.SetActive (false); 
			} else {
				NextInstr ();  
			}
		}*/
			
		if (!menu.gameObject.activeInHierarchy) {
			//instructionLarge.gameObject.GetComponent<Button> ().enabled = true;
			if (instructionLarge.activeInHierarchy) {
				pointer.targetCanvas = instructionCanvas; 
			} else {
				pointer.targetCanvas = baseCanvas; 
			}
		} else {
			//instructionLarge.gameObject.GetComponent<Button> ().enabled = false;
			pointer.targetCanvas = menu.gameObject.GetComponent<Canvas> (); 
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			Pledge (); 
		}


		if (Input.GetKeyDown (KeyCode.S)) {
			Sing (); 
		}
			

	}

	public void Sing() {
		if (count % 2 == 0) {
			screen.StopVideo (); 
			intro.SetActive (false);
			toInstructions (); 
			happySinging.gameObject.SetActive (true);
			happySinging.ResetMenu (); 
			sadSinging.gameObject.SetActive (false); 

		} else {
			screen.StopVideo (); 
			intro.SetActive (false);
			toInstructions(); 
			sadSinging.gameObject.SetActive (true);
			sadSinging.ResetMenu (); 
			happySinging.gameObject.SetActive (false); 

		}

		dance.gameObject.SetActive (false);
		massage.gameObject.SetActive (false); 
		pledge.gameObject.SetActive (false); 
	}

	public void Dance() {
		screen.StopVideo (); 
		intro.SetActive (false);
		toInstructions ();  
		dance.gameObject.SetActive (true); 
		dance.ResetMenu (); 

		massage.gameObject.SetActive (false); 
		pledge.gameObject.SetActive (false); 
		happySinging.gameObject.SetActive (false); 
		sadSinging.gameObject.SetActive (false); 

	}

	public void Massage() {
		screen.StopVideo (); 
		intro.SetActive (false);
		toInstructions (); 
		massage.gameObject.SetActive (true); 
		massage.ResetMenu (); 

		dance.gameObject.SetActive (false); 
		pledge.gameObject.SetActive (false); 
		happySinging.gameObject.SetActive (false); 
		sadSinging.gameObject.SetActive (false); 
	}

	public void Pledge() {
		screen.StopVideo (); 
		intro.SetActive (false);
		toInstructions (); 
		pledge.gameObject.SetActive (true);
		pledge.ResetMenu (); 

		dance.gameObject.SetActive (false); 
		massage.gameObject.SetActive (false);  
		happySinging.gameObject.SetActive (false); 
		sadSinging.gameObject.SetActive (false); 
	}

	public void toMenu() {
		stage3Menu.SetActive (true); 
		instructionLarge.SetActive (false); 

	}

	public void toInstructions() {
		instructionLarge.SetActive (true); 
		stage3Menu.SetActive (false); 
	}

	public void NextInstr() {

		if (happySinging.gameObject.activeInHierarchy) {
			happySinging.GetComponent<Stage2InstrNav> ().NextInstr (); 
		} else if (sadSinging.gameObject.activeInHierarchy) {
			sadSinging.GetComponent<Stage2InstrNav> ().NextInstr (); 
		} else if (dance.gameObject.activeInHierarchy) {
			dance.GetComponent<Stage2InstrNav> ().NextInstr (); 
		} else if (massage.gameObject.activeInHierarchy) {
			massage.GetComponent<Stage2InstrNav> ().NextInstr (); 
		} else if (pledge.gameObject.activeInHierarchy) {
			pledge.GetComponent<Stage2InstrNav> ().NextInstr (); 
		}

	}

	public void Speak() {
		if (happySinging.gameObject.activeInHierarchy) {
			happySinging.GetComponent<InstrTTS> ().Speak (); 
		} else if (sadSinging.gameObject.activeInHierarchy) {
			sadSinging.GetComponent<InstrTTS> ().Speak (); 
		} else if (dance.gameObject.activeInHierarchy) {
			dance.GetComponent<InstrTTS> ().Speak (); 
		} else if (massage.gameObject.activeInHierarchy) {
			massage.GetComponent<InstrTTS> ().Speak (); 
		} else if (pledge.gameObject.activeInHierarchy) {
			pledge.GetComponent<InstrTTS> ().Speak (); 
		}
	}

}
