using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class Stage4MenuController : MonoBehaviour {
	// Use this for initialization
	//Stage4Toggle stage4Toggle; 
	public GameObject instructionLarge; 
	public Stage2InstrNav socialise; 
	public Stage2InstrNav optimise; 
	private Stage2Menu stage2menu; 

	void Start () {
		//stage4Toggle = Stage4Toggle.Instance; 
		//Debug.Log ("stage4Toggle: " + stage4Toggle == null);
		stage2menu = GetComponentInParent<Stage2Menu>(); 
		socialise.gameObject.SetActive (false);
		optimise.gameObject.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.O)) {
			Debug.Log ("pressed O"); 
			//stage4Toggle.subprotocol = 1; 
			ChooseProtocol(4); 
			//ChooseProtocol(0); 
		}

		if (Input.GetKeyDown(KeyCode.H)) {
			Debug.Log ("pressed H"); 
			ChooseProtocol(5); 
		}

	}
	/*
	public void ChooseProtocol(int p) {
		stage4Toggle.subprotocol = p; 
		switch (p) {
			case 0: 
			case 1:
				SceneManager.LoadScene ("Stage4BlackOut2", LoadSceneMode.Single); 
				break; 
			case 2: //TODO: zest for life
				break;
			case 3: //TODO: gestalt 
				break;
			case 4: //TODO: outward socialisation 
				break;
			case 5: //TODO: optimal inner working model
				break;
		}
	}*/

	public void ChooseProtocol(int p) {
		//stage4Toggle.subprotocol = p; 
		PlayerPrefs.SetInt ("Stage4Toggle", p); 
		switch (p) {
			case 0: 
				Debug.Log ("switch0"); 
				SceneManager.LoadScene ("Stage4BlackOut2", LoadSceneMode.Single); 
				break;
			case 1:
				Debug.Log ("switch1"); 
				SceneManager.LoadScene ("Stage4BlackOut2", LoadSceneMode.Single); 
				break; 
			case 2: //TODO: zest for life
				SceneManager.LoadScene ("Stage4Mirror2", LoadSceneMode.Single); 
				break;
			case 3: 
				SceneManager.LoadScene("Gestalt", LoadSceneMode.Single); 
				break;
			case 4: //TODO: outward socialisation
				stage2menu.ToInstrLarge (); 
				socialise.gameObject.SetActive (true);
				socialise.ResetMenu (); 
				optimise.gameObject.SetActive (false); 
				break;
			case 5: //TODO: optimal inner working model
				stage2menu.ToInstrLarge (); 
				socialise.gameObject.SetActive (false); 
				optimise.gameObject.SetActive (true); 
				optimise.ResetMenu (); 
				break;
		}
	}

	public void LoadPH9() {
		PlayerPrefs.SetInt ("PHQReturn", 4); 
		SceneManager.LoadScene ("PHQ1", LoadSceneMode.Single);
	}

	public void NextInstr() {
		if (socialise.gameObject.activeInHierarchy) {
			socialise.NextInstr (); 
		} else if (optimise.gameObject.activeInHierarchy) {
			optimise.NextInstr (); 
		} 
	}

	public void Speak() {
		if (socialise.gameObject.activeInHierarchy) {
			socialise.gameObject.GetComponent<InstrTTS> ().Speak(); 
		} else if (optimise.gameObject.activeInHierarchy) {
			optimise.gameObject.GetComponent<InstrTTS> ().Speak(); 
		} 
	}
}
