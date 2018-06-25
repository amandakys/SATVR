using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class Stage4InstrNav : MonoBehaviour {
	private Text[] instr; 
	private int current; 
	private int numInstr;

	public bool isCuddleMenu;
	public GameObject CameraRig; 
	public GameObject child; 
	public Text continueUI; 

	public Stage2Menu stage2Controller;
	public ScreenController screenController; 
	private Stage3Controller stage3Controller; 
	//	public GameObject instructionLarge; 

	public Raise raiseController; 
	private bool raised; 

	private SmoothPosition smooth; 
	private Animator childAnim; 

	private bool acceptCollisions; 
	private bool collided; 

	private Vector3 childOrigin; 
	private Vector3 targetPosition; 
	private bool childMove; 
	private bool childTurn1;
	private bool childTurn2; 
	private Quaternion towardCamera; 
	private Quaternion toward;

	private bool acceptNext; 

	// Use this for initialization
	void Start () {
		acceptNext = true; 
		current = 1; 
		instr = this.GetComponentsInChildren<Text> ();
		stage3Controller = GetComponentInParent<Stage3Controller>(); 
		numInstr = instr.Length; 
		ResetMenu (); 
		raised = false; 

		if (isCuddleMenu) {
			childTurn1 = false; 
			childTurn2 = false; 
			acceptCollisions = false; 
			collided = false; 
			toward = Quaternion.Euler (0, 0, 0); 
			childMove = true; 
			smooth = child.GetComponent<SmoothPosition> (); 
			childAnim = child.GetComponent<Animator> ();  
			childOrigin = child.transform.position; 

			Vector3 dir = new Vector3 (child.transform.position.x - CameraRig.transform.position.x, 0, child.transform.position.z - CameraRig.transform.position.z); 
			dir = Vector3.Normalize (dir); 
			targetPosition = new Vector3 (CameraRig.transform.position.x, -2, CameraRig.transform.position.z) + 0.5f * dir;
		}
	}

	// Update is called once per frame
	void Update () {
		/*if (OVRInput.GetDown (OVRInput.Button.One)) {
			NextInstr (); 
		}*/

		if (Input.GetKeyDown(KeyCode.A)) {
			Debug.Log ("A");
			current = numInstr - 2; 
		}

		if (Input.GetKeyDown(KeyCode.B)) {
			Debug.Log ("B");
			collided = true; 
		}

		/*if (Input.GetKeyDown (KeyCode.N) || OVRInput.GetDown(OVRInput.Button.One)) {
			Debug.Log ("Stage2InstrNav"); 
			NextInstr (); 
		}*/


		if (isCuddleMenu) {

			if (current == numInstr - 2) {
				//cuddle menu is at second last instr
				continueUI.enabled = false; 
				acceptNext = false; 
				//move child towards user 
				float currentX = CameraRig.transform.position.x; 
				float currentZ = CameraRig.transform.position.z; 

				Vector3 dir = new Vector3 (child.transform.position.x - currentX, 0, child.transform.position.z - currentZ); 
				dir = Vector3.Normalize (dir); 


				if (childMove) {
					childAnim.SetBool ("Walk", true); 
					child.transform.position = Vector3.Lerp (child.transform.position, targetPosition, Time.deltaTime * 0.6f); 
					Debug.Log ("Distance:" + Vector3.Distance (targetPosition, child.transform.position)); 
				} 

				if (Vector3.Distance (targetPosition, child.transform.position) <= 0.05f) {
					childAnim.SetBool ("Walk", false);
					childAnim.SetTrigger ("Sad"); 
					Debug.Log ("stop walking"); 
					acceptCollisions = true; 
					childMove = false;
				}

				if (acceptCollisions && collided) {
					childAnim.SetTrigger ("Happy"); 
					instr [current].enabled = false; 
					instr [current + 1].enabled = true; 
					current++; 
					collided = false; 
					acceptCollisions = false;
					childTurn1 = true; 

				}
			}

			if (current == numInstr - 1) {
				//on final instr
				//walk child back to origin 

				if (childTurn1) {
					Debug.Log ("turn"); 
					child.transform.rotation = Quaternion.Slerp (child.transform.rotation, toward, Time.deltaTime); 
				}

				if (child.transform.rotation.eulerAngles.y <= 0.1f && childTurn1) {
					Debug.Log ("stop turn"); 
					childTurn1 = false; 
					childMove = true; 
				}

				if (childMove) {
					Debug.Log ("walk back"); 
					childAnim.SetBool ("Walk", true); 
					child.transform.position = Vector3.Lerp (child.transform.position, childOrigin, Time.deltaTime * 0.6f); 

				}

				if (Vector3.Distance(childOrigin, child.transform.position) <= 0.1f && childMove) {
					//stop walking back to origin
					Debug.Log("Stop walking"); 
					childAnim.SetBool ("Walk", false); 
					childMove = false;  
					childTurn2 = true; 

				}

				if (childTurn2) {
					Debug.Log ("Turn2"); 
					toward = Quaternion.Euler (0f, 180f, 0f); 
					child.transform.rotation = Quaternion.Slerp (child.transform.rotation, toward, Time.deltaTime); 
				}
				if (child.transform.rotation.eulerAngles.y <= 182.0f && childTurn2) {
					childTurn2 = false; 
					continueUI.enabled = true; 
					acceptNext = true; 
				}




			}

		}

	}

	public void NextInstr() {
		if (acceptNext) {
			if (current < numInstr - 1) {
				//there is a next instruction 
				instr [current].enabled = false; 
				instr [current + 1].enabled = true; 

				current++; 
			} else {
				//current instruction is last instruction  
				if (SceneManager.GetActiveScene ().name.Equals ("Stage2V2")) {
					stage2Controller.toInstrSmall (); 
				} /*else if (SceneManager.GetActiveScene ().name.Equals ("Stage4")) {
					Debug.Log ("Stage4"); 
					raiseController.RaiseWall (); 
					raiseController.RaiseLights (); 
					instructionLarge.SetActive (false); 
				}*/ else if (SceneManager.GetActiveScene ().name.Equals ("Stage3")) {
					stage3Controller.toMenu (); 
					//instructionLarge.gameObject.SetActive (false); 
					this.gameObject.SetActive (false);
					switch (this.gameObject.gameObject.name) {
					case "SadSinging":
						screenController.Sing (); 
						break;
					case "HappySinging": 
						screenController.Sing (); 
						break;
					case "Dance":
						screenController.Dance (); 
						break;
					case "Massage":
						screenController.Massage (); 
						break;
					}
				} else if (SceneManager.GetActiveScene ().name.Equals ("Stage4")) {
					SceneManager.LoadScene ("Stage4V2", LoadSceneMode.Single); 
				} else {
					stage2Controller.gameObject.SetActive (false); 
				}
			}
		}

	}

	public int getCurrentInstr() {
		return current; 
	}

	public int getNumInstr() {
		return numInstr; 
	}

	float distanceToChild(Transform c) {
		Vector2 child2D = new Vector2 (c.position.x, c.position.z);
		Vector2 camera2D = new Vector2 (CameraRig.transform.position.x, CameraRig.transform.position.z); 
		float distance = Vector2.Distance (child2D, camera2D); 
		return distance; 
	}

	public void SetCollided(bool b) {
		if (acceptCollisions) {
			child.GetComponent<Haptics>().Vibrate(VibrationForce.Hard);
			collided = b; 
		}
	}

	public void ResetMenu() {
		for (int i = 1; i < numInstr; i++) {
			instr [i].enabled = false; 
		}

		instr [1].enabled = true; 
		current = 1; 
	}
}
