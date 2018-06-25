using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2InstructionController : MonoBehaviour {
	public GameObject happy; 
	public GameObject sad; 
	public GameObject cuddle; 
	public Stage2Menu menuController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (OVRInput.GetDown (OVRInput.Button.One)) {
			NextInstr (); 
		}*/

		if (Input.GetKeyDown (KeyCode.H)) {
			Happy (); 
		}

/*		if (Input.GetKeyDown (KeyCode.N)) {
			NextInstr (); 
		}*/
	}

	public void Happy() {
		menuController.ToInstrLarge (); 
		happy.SetActive (true); 
		sad.SetActive (false); 
		cuddle.SetActive (false); 
		happy.GetComponent<Stage2InstrNav> ().ResetMenu (); 
	}

	public void Sad() {
		menuController.ToInstrLarge (); 
		happy.SetActive (false); 
		sad.SetActive (true);
		cuddle.SetActive (false);
		sad.GetComponent<Stage2InstrNav> ().ResetMenu (); 
	}

	public void Cuddle() {
		menuController.ToInstrLarge (); 
		happy.SetActive (false); 
		sad.SetActive (false); 
		cuddle.SetActive (true);
		cuddle.GetComponent<Stage2InstrNav> ().ResetMenu (); 
	}

	public void NextInstr() {
		if (happy.activeInHierarchy) {
			happy.GetComponent<Stage2InstrNav> ().NextInstr (); 
		} else if (sad.activeInHierarchy) {
			sad.GetComponent<Stage2InstrNav> ().NextInstr (); 
		} else if (cuddle.activeInHierarchy) {
			cuddle.GetComponent<Stage2InstrNav> ().NextInstr (); 
		}
	}

	public void Speak() {
		if (happy.activeInHierarchy) {
			happy.GetComponent<InstrTTS> ().Speak(); 
		} else if (sad.activeInHierarchy) {
			sad.GetComponent<InstrTTS> ().Speak (); 
		} else if (cuddle.activeInHierarchy) {
			cuddle.GetComponent<InstrTTS> ().Speak (); 
		}
	}
}
