using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMenu : MonoBehaviour {

	public GameObject menu;
	public GameObject extras; 
	public GameObject child; 

	// Use this for initialization
	void Start () {
		menu.transform.position = new Vector3(child.transform.position.x, -0.6f, child.transform.position.z); 
	}

	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown (OVRInput.Button.Start)) {
			menu.SetActive (!menu.activeInHierarchy);
		}

		menu.transform.position = new Vector3(child.transform.position.x, -0.6f, child.transform.position.z); 
		menu.transform.rotation = child.transform.rotation;
		menu.transform.Rotate (new Vector3 (0, 180, 0));

		extras.transform.position = new Vector3(child.transform.position.x, -0.6f, child.transform.position.z); 
		extras.transform.rotation = child.transform.rotation;
		extras.transform.Rotate (new Vector3 (0, 180, 0));

		/*if (Input.GetButtonDown(OVRInput.Button.Start))
		{
			menu.SetActive (!activeState);
			activeState = !activeState; 
		}*/
	}

}
