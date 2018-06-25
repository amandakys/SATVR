using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

using UnityEngine.Windows.Speech;
using System.Linq;

public class Stage1Speech : MonoBehaviour {
	public Button yes; 
	public Button no;
	public Animator canvasAnim; 

	private KeywordRecognizer keywordRecognizer;
	public string[] keywords = new string[] { "yes", "no", "next stage", "stage one", "stage two", "stage three", "stage four" };
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
		case "yes":
			if (yes.gameObject.activeInHierarchy) {
				SceneManager.LoadScene ("PHQ1", LoadSceneMode.Single); 
			}
			break;
		case "no":
			canvasAnim.SetTrigger ("next"); 
			break;
	
			/*case "next room":
			if (SceneManager.GetActiveScene().name.Equals("Stage1")) {
				SceneManager.LoadScene ("Stage2V2", LoadSceneMode.Single); 
			} else if (SceneManager.GetActiveScene().name.Equals("Stage2")) {
				SceneManager.LoadScene ("Stage3", LoadSceneMode.Single); 
			} else if (SceneManager.GetActiveScene().name.Equals("Stage3")) {
				SceneManager.LoadScene ("Stage4V2", LoadSceneMode.Single); 
			}
			break;

		case "room one": 
			SceneManager.LoadScene ("Stage1", LoadSceneMode.Single);
			break; 
		case "room two": 
			SceneManager.LoadScene ("Stage2V2", LoadSceneMode.Single);
			break; 
		case "room three":
			SceneManager.LoadScene ("Stage3", LoadSceneMode.Single);
			break; 
		case "room four":
			SceneManager.LoadScene ("Stage4V2", LoadSceneMode.Single);
			break; 
*/
		case "next stage":
			SceneManager.LoadScene ("Stage2V2", LoadSceneMode.Single); 
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
