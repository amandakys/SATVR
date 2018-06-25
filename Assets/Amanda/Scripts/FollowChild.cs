using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChild : MonoBehaviour {
	public GameObject child; 
	public GameObject CameraRig;
	private Vector3 offset; 

	private float prevX; 
	private float prevZ; 

	private float currentX; 
	private float currentZ; 

	private float deltaX; 
	private float deltaZ; 

	private Animator childAnim; 
	private SmoothPosition smooth; 
	private Vector3 targetPosition; 

	private float currentDistanceToChild; 

	// Use this for initialization
	void Start () {
		childAnim = child.GetComponent<Animator> ();
		smooth = this.GetComponent<SmoothPosition> ();
		prevX = CameraRig.transform.position.x; 
		prevZ = CameraRig.transform.position.z; 

		//offset = new Vector3 (child.transform.position.x - prevX, 0, child.transform.position.z - prevZ);
		//offset = child.transform.position - CameraRig.transform.position; 
		//Vector2 offset2D = Vector2 (offset.x, offset.z); 
		InvokeRepeating("FollowCamera", 5.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 camera2D = new Vector3 (CameraRig.transform.position.x, -2, CameraRig.transform.position.z);
		child.transform.LookAt (camera2D);

		currentDistanceToChild = distanceToChild (); 
		if (currentDistanceToChild <= 3 + 0.2) {

			//if (!childAnim.GetCurrentAnimatorStateInfo(0).IsName ("Base.Idle")) {
				childAnim.SetBool("Walk", false);
			//}
		}

	}

	void FollowCamera () {

		currentX = CameraRig.transform.position.x; 
		currentZ = CameraRig.transform.position.z; 

		Vector3 dir = new Vector3 (child.transform.position.x - currentX,0, child.transform.position.z - currentZ); 
		dir = Vector3.Normalize (dir); 

		if (currentX != prevX || currentZ != prevZ) {
			Debug.Log (currentDistanceToChild);
			//currentDistanceToChild = distanceToChild ();
			if (currentDistanceToChild >= 4 - 0.1) {
				childAnim.SetBool ("Walk", true); 
				targetPosition = new Vector3 (CameraRig.transform.position.x, -2, CameraRig.transform.position.z) + 3 * dir; //new Vector3 (child.transform.position.x + deltaX, child.transform.position.y, child.transform.position.z + deltaZ);//child.transform.position + offset;
				Debug.Log("Distance:" + Vector3.Distance(targetPosition, CameraRig.transform.position)); 
				smooth.targetPosition = targetPosition;

			} 
		}
	}

	float distanceToChild() {
		Vector2 child2D = new Vector2 (child.transform.position.x, child.transform.position.z);
		Vector2 camera2D = new Vector2 (CameraRig.transform.position.x, CameraRig.transform.position.z); 
		float distance = Vector2.Distance (child2D, camera2D); 
		return distance; 
	}
}
