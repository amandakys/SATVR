using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PHQ9 : MonoBehaviour {
	public GameObject question;
	public GameObject buttons; 
	public GameObject results;

	private Text[] questions;
	private int currentQ; 
	private int score; 
	public Text scoreText;
	public Text depressionText; 
	public Text previous; 

	// Use this for initialization
	void Start () {
		questions = question.GetComponentsInChildren<Text> (); 
		currentQ = 0; 
		score = 0; 
		question.SetActive (true); 
		buttons.SetActive (true); 
		results.SetActive (false); 
		for (int i = 0; i < 9; i++) {
			questions[i].enabled = false; 
		}
		questions [currentQ].enabled = true; 
	}
	
	// Update is called once per frame
	void Update () {
		if (currentQ == 8) {
			if (OVRInput.GetDown (OVRInput.Button.One) || Input.GetKeyDown (KeyCode.N)) {
				switch (PlayerPrefs.GetInt ("PHQReturn")) {
				case 1: 
					SceneManager.LoadScene ("Stage2V2", LoadSceneMode.Single);
					break;
				case 4:
					SceneManager.LoadScene ("Stage4V2", LoadSceneMode.Single); 
					break;
	
				}
			}
		}
		
	}

	public void NextQuestion() {
		if (currentQ == 8) {
			//end of questionnaire
			question.SetActive (false); 
			buttons.SetActive (false); 

			scoreText.text = score.ToString () + "/27";
			if (score >= 0 && score <= 4) {
				depressionText.text = "No Depression";
			} else if (score >= 5 && score <= 9) { 
				depressionText.text = "Mild Depression";
			} else if (score >= 10 && score <= 14) {
				depressionText.text = "Moderate Depression";
			} else if (score >= 15 && score <= 19) {
				depressionText.text = "Moderately Severe Depression";
			} else if (score >= 20 && score <= 27) {
				depressionText.text = "Severe Depression";
			}

			results.SetActive (true); 
			if (PlayerPrefs.HasKey ("PHQ9Score")) {
				previous.text = "Your previous score was " + PlayerPrefs.GetInt ("PHQ9Score");
			} else {
				previous.text = "";
			}

			PlayerPrefs.SetInt ("PHQ9Score", score); 
		} else {
			questions [currentQ].enabled = false; 
			questions [currentQ + 1].enabled = true; 
			currentQ++;
		}
	}

	public void IncrementScore(int i) {
		Debug.Log ("jere");
		score += i; 
		NextQuestion (); 

	}

	public void Speak() {
		WindowsVoice.speak ("Over the last two weeks, how often have you been bothered by" + questions [currentQ].text);
	}
}
