using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage4TTS : MonoBehaviour {

	private Text intro; 
	// Use this for initialization
	void Start () { 
		intro = this.GetComponentInChildren<Text> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Speak() {
		WindowsVoice.speak (intro.text); 
	}
}
