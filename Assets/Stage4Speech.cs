using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class Stage4Speech : MonoBehaviour {
	public Stage4MenuController controller; 
	public Stage4TTS tts; 
	private KeywordRecognizer keywordRecognizer;
	public string[] keywords = new string[] { "Type A", "Type B", "Type C", "Type D", "Type E", "Type F", "next stage", "stage one", "stage two", "stage three", "stage four", "speak" };
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
		case "Type A":
			controller.ChooseProtocol (0); 
			word = ""; 
			break;
		case "Type B": 
			controller.ChooseProtocol (1);  
			word = ""; 
			break;
		case "Type C": 
			controller.ChooseProtocol (2); 
			word = ""; 
			break;
		case "Type D":
			controller.ChooseProtocol (3); 
			word = ""; 
			break;
		case "Type E":
			controller.ChooseProtocol (4); 
			word = ""; 
			break; 
		case "Type F":
			controller.ChooseProtocol (5); 
			word = ""; 
			break;
		case "next stage":
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
				//instructions are up 
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
