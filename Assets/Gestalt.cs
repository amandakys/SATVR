using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Gestalt : MonoBehaviour {
	public AlphaControl vase;
	public AlphaControl faces; 
	private bool isVase; 
	public Animator childAnim; 
	public Stage2Menu gestaltIntro; 

	// Use this for initialization
	void Start () {
		isVase = true; 
		childAnim.SetTrigger ("Sad"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {

			Switch (); 
			/*Debug.Log ("spacedown"); 
			if (isVase) {
				toFaces (); 

			} else {
				toVase (); 
				 
			}*/
		}
		
	}

	void toVase() {
		vase.ChangeAlpha (255); 
		faces.ChangeAlpha (0); 
		isVase = true; 

	}

	void toFaces() {
		vase.ChangeAlpha (0); 
		faces.ChangeAlpha (255); 
		isVase = false; 
	}

	public void Switch() {
		if (!gestaltIntro.gameObject.activeInHierarchy) {
			vase.gameObject.SetActive (!vase.gameObject.activeInHierarchy); 
			if (vase.gameObject.activeInHierarchy) {
				childAnim.SetTrigger ("Sad"); 
			} else {
				childAnim.SetTrigger ("Happy"); 
			}
		}
	}
}
