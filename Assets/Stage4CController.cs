using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4CController : MonoBehaviour {
	public Animator childAnim; 
	private Stage2InstrNav instr; 
	private bool dance; 

	// Use this for initialization
	void Start () {
		dance = false; 
		instr = this.GetComponentInChildren<Stage2InstrNav> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (!dance && instr.getCurrentInstr () == 4) {
			childAnim.SetTrigger ("Dance"); 
			dance = true; 
			Debug.Log ("dance"); 
		} 

		if (dance && instr.getCurrentInstr () == 5) {
			childAnim.SetTrigger ("Idle"); 
			dance = false; 
			Debug.Log ("idle"); 
		}
	}
}
