using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackOutController : MonoBehaviour
{
	public Text introText;
	public Text instrText;
	public Text uiText;
	private int pressed;
	private bool fadeInInstr;
	private bool fadeOutInstr;
	private Stage4Toggle stage4Toggle; 

	private Animator textAnim; 

	// Use this for initialization
	void Start ()
	{
		
		switch (PlayerPrefs.GetInt("Stage4Toggle")) {
		case 0:
			introText.text = "Recall a traumatic event from your past you would like to revisit. Focus on how your child self interpreted events and how you would have liked your parental figures to have supported you instead.";
			break; 
		case 1: 
			introText.text = "Reflect on any negative emotions you are currently experiencing. This could include anger, fear, anxiety, depression in relation to family, friends, work, education or social affairs";
			break;
		}
		fadeInInstr = false; 
		fadeOutInstr = false; 

		textAnim = this.GetComponent<Animator> ();
		StartCoroutine (FadeIntro ()); 
	}
	/*
	void Update () 
	{
		if (OVRInput.Get (OVRInput.Button.One)) {
			textAnim.SetTrigger ("Next");
		}
	}*/
		
	// Update is called once per frame
	void Update ()
	{
		if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log ("Space");
			if (instrText.enabled) {
				SceneManager.LoadScene ("Stage4", LoadSceneMode.Single);
			}

			if (introText.gameObject.activeInHierarchy) {
				Debug.Log ("intro");
				introText.enabled = false; 
				uiText.enabled = false; 
				Debug.Log (introText.IsActive ());
				instrText.enabled = true; 
				StartCoroutine (FadeInstr ());
				StartCoroutine (Slow ()); 

			}
				
		}
		/*if (OVRInput.GetDown (OVRInput.Button.One)) {

			if (instrText.gameObject.activeInHierarchy) {
				SceneManager.LoadScene ("Stage4", LoadSceneMode.Single);
			}

			if (introText.gameObject.activeInHierarchy) {
				introText.gameObject.SetActive (false); 
				instrText.gameObject.SetActive (true); 
				StartCoroutine (FadeInstr ());
				StartCoroutine (Slow ()); 

			} 
		}*/


		if (fadeOutInstr) {
			instrText.color = new Color (instrText.color.r, instrText.color.g, instrText.color.b, Mathf.Lerp (instrText.color.a, 0.0f, Time.deltaTime)); 
			//instrText.color.a = Mathf.Lerp (instrText.color.a, 0.0f, Time.deltaTime * 0.5f); 
		}

		if (fadeInInstr) {
			instrText.color = new Color (instrText.color.r, instrText.color.g, instrText.color.b, Mathf.Lerp (instrText.color.a, 1.0f, Time.deltaTime )); 
			//instrText.color.a = Mathf.Lerp (instrText.color.a, 1.0f, Time.deltaTime * 0.5f); 
		}

	}

	IEnumerator FadeInstr ()
	{
		yield return new WaitForSeconds (5); 
		fadeOutInstr = true; 
	}

	IEnumerator Slow ()
	{
		yield return new WaitForSeconds (60); 
		fadeOutInstr = false; 
		fadeInInstr = true; 
	}

	IEnumerator FadeIntro() {
		yield return new WaitForSeconds (20); 
		introText.gameObject.SetActive (false); 
		instrText.gameObject.SetActive (true); 
		instrText.enabled = true; 
		yield return new WaitForSeconds (5); 
		fadeOutInstr = true; 
	}
		
}
