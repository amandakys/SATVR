using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class OnboardController : MonoBehaviour {
	//private Image[] slides; 
	private Animator anim; 
	public GameObject menu; 
	// Use this for initialization
	void Start () {
		//slides = GetComponentsInChildren<Image> (); 
		anim = this.GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log ("here"); 
			//menu.SetActive (!menu.activeInHierarchy);
			menu.GetComponent<Canvas>().enabled = !menu.GetComponent<Canvas>().enabled; 
		}

		if (OVRInput.GetDown (OVRInput.Button.One)) {
			anim.SetTrigger ("Next");
		}

		if (OVRInput.GetDown (OVRInput.Button.Start)) {
			//menu.SetActive (!menu.activeInHierarchy); 
			menu.GetComponent<Canvas>().enabled = !menu.GetComponent<Canvas>().enabled; 
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Slide2")) {
			menu.GetComponent<Canvas> ().enabled = true; 
		}
	}

	public void LoadPHQ() {
		PlayerPrefs.SetInt ("PHQReturn", 1); 
		SceneManager.LoadScene ("PHQ1", LoadSceneMode.Single); 
	}

	public void Speak() {
		WindowsVoice.speak ("All rooms have a stationary viewing experience. To navigate between rooms, used the game menu accessible via flat button on the left controller. Speech control is also available for accessing menu items and overall navigation. Say “Next Stage” to progress to the next room. Or “Stage 1” to progress directly Stage 1. When text on buttons are bold, this indicates they are the corresponding speech command for that button. If the speaker icon is present, clicking it or saying “Speak” will activate an automated text reader."); 
	}
}
