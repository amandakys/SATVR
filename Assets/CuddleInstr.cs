using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CuddleInstr : MonoBehaviour {
	public OVRPlayerController controller; 
	public Stage2Menu menuController; 
	public Text[] instrs; 
	public Text[] UIInstrs; 
	public GameObject child; 
	public GameObject camera; 
	public Text continueUI; 

	private int current; 
	private bool UIenabled; 

	private bool acceptCollisions; 
	private bool collided; 

	// Use this for initialization
	void Start () {
		current = 0; 
		UIenabled = false; 

		for (int i = 0; i < UIInstrs.Length; i++) {
			UIInstrs [i].enabled = false; 
		}
		for (int i = 0; i < instrs.Length; i++) {
			instrs [i].gameObject.SetActive (true); 
			instrs [i].enabled = false; 
		}
		instrs [0].enabled = true; 
	}
	
	// Update is called once per frame
	void Update () {
		/*if (OVRInput.GetDown (OVRInput.Button.One)) {
			if (!UIenabled) {
				NextInstr (); 
			}
		}*/

		if (UIenabled) {
			//enable joystick control

			SetControllerActive (true);
			Vector3 startPos = controller.transform.position; 

			if (UIInstrs [0].enabled) {
				if (!OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).Equals(new Vector2(0.0f, 0.0f))) {
					//player has moved
					UIInstrs [0].enabled = false; 
					UIInstrs [1].enabled = true; 
				}
			} else if (UIInstrs [1].enabled) {
				if (distanceToChild () < 1.5f) {
					UIInstrs [1].enabled = false; 
					UIInstrs [2].enabled = true; 
				}
			} else if (UIInstrs [2].enabled) {
				collided = false; 
				acceptCollisions = true; 
			} else if (UIInstrs [3].enabled) {
				if (OVRInput.GetDown (OVRInput.Button.One)) {
					UIenabled = false; 
					menuController.toInstrSmall (); 
					SetControllerActive (false); 
				}
			}
		}

		if (UIenabled && collided) {
			UIInstrs [2].enabled = false; 
			UIInstrs [3].enabled = true; 
			continueUI.enabled = true; 
			collided = false; 
			acceptCollisions = false; 

		}
	}

	public void NextInstr() {
		if (current + 1 == instrs.Length - 1 && !UIenabled) {
			//next instr is last instr
			instrs [current].enabled = false; 
			instrs [current + 1].enabled = true; 
			UIenabled = true; 
			UIInstrs [0].enabled = true; 
			continueUI.enabled = false; 

		} else if (current + 1 != instrs.Length) {
			//there is a next instruction 
			instrs [current].enabled = false; 
			instrs [current + 1].enabled = true; 
			current++; 
		} else {
			//current instruction is last instruction 
		}
	}
	
	float distanceToChild() {
		Vector2 child2D = new Vector2 (child.transform.position.x, child.transform.position.z);
		Vector2 camera2D = new Vector2 (camera.transform.position.x, camera.transform.position.z); 
		float distance = Vector2.Distance (child2D, camera2D); 
		return distance; 
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		//debug.text = "OnTriggerEnter"; 
		if (otherCollider.name.Equals ("GrabVolumeBig") && acceptCollisions) {
			//debug.text = "hit";
			this.GetComponent<Haptics>().Vibrate(VibrationForce.Hard);
			collided = true; 
		}
	}

	void SetControllerActive(bool b) {
		controller.GetComponent<CharacterController> ().enabled = b; 
		controller.GetComponent<OVRPlayerController> ().enabled = b; 
		controller.GetComponent<OVRSceneSampleController> ().enabled = b; 
	}

}
