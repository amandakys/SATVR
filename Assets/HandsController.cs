using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour {
	public GameObject mainMenu; 
	public GameObject instructions; 
	public GameObject leftHand; 
	public GameObject rightHand; 
	public GameObject pointer; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mainMenu.activeInHierarchy || instructions.activeInHierarchy) {
			leftHand.SetActive (true); 
			rightHand.SetActive (true); 
			pointer.SetActive (true); 
		} else {
			leftHand.SetActive (false); 
			rightHand.SetActive (false); 
			pointer.SetActive (false); 
		}
	}
}
