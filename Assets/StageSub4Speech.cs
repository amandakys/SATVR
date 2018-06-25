using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class StageSub4Speech : MonoBehaviour {
	public Stage4Instr controller; 
	public InstrTTS tts; 
	private KeywordRecognizer keywordRecognizer;
	public string[] keywords = new string[] { "next stage", "stage one", "stage two", "stage three", "stage four", "speak" };
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
			if (controller == null) {
				tts.Speak (); 
				word = ""; 
			} else if (tts == null) {
				controller.Speak (); 
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
