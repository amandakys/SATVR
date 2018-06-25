using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScreenController : MonoBehaviour {

	private VideoPlayer player;
	public VideoClip[] videos;
	public bool lowered; 

	// Use this for initialization
	void Start () {
		player = this.GetComponentInChildren<VideoPlayer> (); 
		lowered = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (lowered) {
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3 (-0.01f, 0.41f, 3.95f), Time.deltaTime * 0.7f);  
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Sing (); 
		}
	}
		
	public void Massage () {

		player.clip = videos [0];
		player.Play();
	}

	public void Sing () {

		player.clip = videos [1];
		player.Play();
	} 

	public void Dance () {

		player.clip = videos [2];
		player.Play();
	}

	private void Lower() {
		lowered = true; 
	}

	public void StopVideo() {
		player.Stop (); 
	}
}
