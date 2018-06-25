using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR = UnityEngine.VR;


public class FollowCamera : MonoBehaviour {
	public GameObject playerController; 
	public GameObject child; 
	private OVRCameraRig camera; 
	private static OVRPlugin.Step stepType = OVRPlugin.Step.Render;

	private float childHeight; 
	// Use this for initialization
	void Start () {
		childHeight = child.transform.position.y; 
		camera = playerController.GetComponentInChildren<OVRCameraRig> (); 
		//child.transform.position = new Vector3 (playerController.transform.position.x, childHeight, playerController.transform.position.z); 
	}
	
	// Update is called once per frame
	void Update () {
		OVRPose headPose;
		headPose.position = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.Head);
		headPose.orientation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.Head);
		Vector3 headPosition = OVRPlugin.GetNodePose(OVRPlugin.Node.Head, stepType).ToOVRPose().position;
		child.transform.position = new Vector3 (headPose.position.x, childHeight, headPose.position.z + 3.85f); //new Vector3 (playerController.transform.position.x, childHeight, playerController.transform.position.z); 
		//child.transform.position = headPosition; //headPose.position; new Vector3 (headPose.position.x, childHeight, headPose.position.z); 
		child.transform.rotation = Quaternion.Euler(0,headPose.orientation.eulerAngles.y, 0); 

		//UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.Head);

	}
}
