using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Stage4ChildManager : MonoBehaviour {
	public GameObject childText; 
	private Animator childAnim; 
	private Animator childTextAnim; 

	// Use this for initialization
	void Start () {

		childAnim = this.GetComponent<Animator> ();
		childTextAnim = childText.GetComponent<Animator> (); 
		StartCoroutine (AnimateChild ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator AnimateChild() {
		yield return new WaitForSeconds (6); 
		childAnim.SetTrigger ("Sad");
		childTextAnim.SetTrigger ("Sad"); 

		yield return new WaitForSeconds (6); 
		childAnim.SetTrigger ("Idle");
		childTextAnim.SetTrigger ("Idle"); 

		yield return new WaitForSeconds (6); 
		childAnim.SetTrigger ("Happy");
		childTextAnim.SetTrigger ("Happy"); 

		yield return new WaitForSeconds (6); 
		childAnim.SetTrigger ("Flip");
		childText.SetActive (false); 


	}
}
