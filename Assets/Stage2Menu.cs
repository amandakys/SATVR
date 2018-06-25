using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Menu : MonoBehaviour {
	public GameObject child; 
	public GameObject instrLarge; 
	public GameObject instrSmall; 
	public GameObject buttons; 
	private Stage2InstructionController controller; 
	private Stage4MenuController stage4controller; 
	private Stage2InstrNav instr; 
	// Use this for initialization
	void Start () {
		//this.GetComponent<RectTransform>().position = new Vector3 (child.transform.position.x + 0.01f, 0.3f, child.transform.position.z);
		/*instrSmall.SetActive (true); 
		buttons.SetActive (true); 
		instrLarge.SetActive (false); */
		controller = GetComponentInChildren<Stage2InstructionController> (); 
		stage4controller = GetComponentInChildren<Stage4MenuController> (); 

		if (SceneManager.GetActiveScene ().name.Equals ("Gestalt") || SceneManager.GetActiveScene ().name.Equals("Stage4Mirror2")) {
			instr = this.GetComponentInChildren<Stage2InstrNav> ();
		} 
		//this.transform.position = new Vector3 (child.transform.position.x + 0.01f, 0.3f, child.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			Debug.Log ("C"); 
			ToInstrLarge (); 
			controller.Cuddle (); 
		}

		if (OVRInput.GetDown (OVRInput.Button.One) || Input.GetKeyDown (KeyCode.N)) {
			if (SceneManager.GetActiveScene ().name.Equals ("Gestalt") || SceneManager.GetActiveScene ().name.Equals ("Stage4Mirror2")) {
				instr.NextInstr (); 
			} else if (SceneManager.GetActiveScene ().name.Equals ("Stage4V2")) {
				stage4controller.NextInstr (); 
			} else {
				controller.NextInstr (); 
			}
		}
		
	}

	public void ToInstrLarge () {
		instrLarge.SetActive (true); 
		instrSmall.SetActive (false); 
		buttons.SetActive (false); 
	}

	public void toInstrSmall() {
		
		instrSmall.SetActive (true); 
		buttons.SetActive (true); 
		instrLarge.SetActive (false); 
		child.GetComponent<Animator> ().SetTrigger ("Idle"); 
	}
		
}
