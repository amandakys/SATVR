using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class PHQSpeechControl : MonoBehaviour {
	public PHQ9 phq; 
	private KeywordRecognizer keywordRecognizer;
	public string[] keywords = new string[] { "one", "two", "three", "zero", "main menu", "stage one", "stage two", "stage three", "stage four" };
	public ConfidenceLevel confidence = ConfidenceLevel.Medium;

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
		case "zero": 
			phq.IncrementScore (0); 
			word = ""; 
			break;
		case "one":
			phq.IncrementScore (1);
			word = ""; 
			break;
		case "two":
			phq.IncrementScore (2); 
			word = ""; 
			break;
		case "three":
			phq.IncrementScore (3); 
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

		}

	}

	void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		word = args.text;
	}
}
