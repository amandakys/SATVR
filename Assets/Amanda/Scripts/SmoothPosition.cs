using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothPosition : MonoBehaviour {

	public Vector3 targetPosition;
	public float smoothFactor = 2;

	// Use this for initialization
	void Start () {
		targetPosition = this.gameObject.transform.position; 

	}

	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.Lerp(transform.position, targetPosition, 0.3f * Time.deltaTime * smoothFactor);
	}
}
