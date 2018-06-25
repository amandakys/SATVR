using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaControl : MonoBehaviour {
	private Image[] images;  
	private int targetAlpha; 
	// Use this for initialization
	void Start () {
		images = this.GetComponentsInChildren<Image> (); 
		targetAlpha = 255; 
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < images.Length; i++) {
			//Debug.Log (this.gameObject.name + ": " + targetAlpha); 
			images [i].color = new Color (images [i].color.r, images [i].color.g, images [i].color.b, Mathf.Lerp (images [i].color.a, targetAlpha, Time.deltaTime)); 
		}
	}

	public void ChangeAlpha(int a) {
		targetAlpha = a; 
	}
}
