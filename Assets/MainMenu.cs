using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class MainMenu : MonoBehaviour {
	public GameObject phq;
	public GameObject menu; 
	public OVRPlayerController camera;
	public ControllerSelection.OVRPointerVisualizer pointer; 
	private Canvas other; 
	//private Button[] buttons; 

	// Use this for initialization
	void Start () {
		other = pointer.targetCanvas; 
		/*buttons = this.GetComponentsInChildren<Button> (); 
		switch (SceneManager.GetActiveScene ().name) {
		case "Stage1":
			buttons [0].colors.normalColor = new Color (94f, 255f, 115f, 139f);
			break;
		case "Stage2V2": 
			buttons [1].colors.normalColor = new Color (94f, 255f, 115f, 139f);
			break;
		case "Stage3": 
			buttons [2].colors.normalColor = new Color (94f, 255f, 115f, 139f);
			break; 
		case "Stage4": 
			buttons [3].colors.normalColor = new Color (94f, 255f, 115f, 139f);
			break;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if (!SceneManager.GetActiveScene ().name.Equals ("MainMenu")) {
			if (OVRInput.GetDown (OVRInput.Button.Start) || Input.GetKeyDown (KeyCode.Space)) {
				Debug.Log ("here"); 
				SetMenuPosition (); 
				menu.SetActive (!menu.activeInHierarchy);
				if (menu.activeInHierarchy) {
					pointer.targetCanvas = this.GetComponent<Canvas> ();
				} else {
					pointer.targetCanvas = other; 
				}

			}

			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				LoadScene (1); 
			}
		}
	}

	public void LoadScene(int i) {
		switch (i) {
		case 1:
			Debug.Log ("loadscen1"); 
			SceneManager.LoadScene ("Stage1", LoadSceneMode.Single); 
			break;
		case 2:
			SceneManager.LoadScene ("Stage2V2", LoadSceneMode.Single); 
			break;
		case 3: 
			SceneManager.LoadScene ("Stage3", LoadSceneMode.Single); 
			break;
		case 4: 
			SceneManager.LoadScene ("Stage4V2", LoadSceneMode.Single); 
			break;
		}
	}

	public void LoadPHQ() {
		phq.SetActive (true); 
		this.gameObject.SetActive (false); 
	}

	private void SetMenuPosition() {
		menu.transform.position = camera.transform.position; 
		menu.transform.position += new Vector3 (0f, -0.2f, 2.0f);
	}
}
