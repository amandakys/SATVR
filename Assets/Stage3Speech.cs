using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Windows.Speech;
using System.Linq;

public class Stage3Speech : MonoBehaviour {
	public Stage3Controller controller; 
	public Stage4TTS tts; 
	private KeywordRecognizer keywordRecognizer;
	public string[] keywords = new string[] { "dance", "sing", "massage", "pledge", "next stage", "stage one", "stage two", "stage three", "stage four", "speak"};
	public ConfidenceLevel confidence = ConfidenceLevel.Low;

	protected string word = "right";

	// Use this for initialization

	void Start()
	{
		if (keywords != null)
		{
			keywordRecognizer = new KeywordRecognizer(keywords, confidence);
			keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
			keywordRecognizer.Start();
		}
	}

	// Update is called once per frame
	void Update () {
		switch (word) {
		case "dance":
			controller.Dance (); 
			word = ""; 
			break;
		case "sing": 
			controller.Sing (); 
			word = ""; 
			break;
		case "massage": 
			controller.Massage ();
			word = ""; 
			break;
		case "pledge": 
			controller.Pledge (); 
			word = ""; 
			break;
		case "next stage":
			SceneManager.LoadScene ("Stage4V2", LoadSceneMode.Single); 
			break;
		case "stage one": 
			SceneManager.LoadScene ("Stage1", LoadSceneMode.Single);
			break; 
		case "stage two": 
			SceneManager.LoadScene ("Stage2V2", LoadSceneMode.Single);
			break; 
		case "stage three":
			SceneManager.LoadScene ("Stage3", LoadSceneMode.Single);
			break; 
		case "stage four":
			SceneManager.LoadScene ("Stage4V2", LoadSceneMode.Single);
			break; 
		case "speak": 
			if (controller.instructionLarge.activeInHierarchy) {
				controller.Speak (); 
				word = "";
			} else {
				tts.Speak (); 
				word = ""; 
			}
			break; 
		}

	}

	void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		word = args.text;
	}
}
