using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InstrTTS : MonoBehaviour {
	private Text[] instrs; 
	private Stage2InstrNav instrNav; 
	// Use this for initialization
	void Start () {
		instrs = this.GetComponentsInChildren<Text> (); 
		instrNav = this.GetComponent<Stage2InstrNav> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Speak() {
		WindowsVoice.speak (instrs [instrNav.getCurrentInstr ()].text); 
	}
}
