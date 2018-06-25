using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Windows.Speech;
using System.Linq;

public class SpeechControl : MonoBehaviour {
	public ScreenController screenController; 
	public Stage2Menu stage2Menu; 
	private Stage2InstructionController controller; 
	public Animator childAnim; 
	public Cuddle cuddle; 
	private KeywordRecognizer keywordRecognizer;
	public string[] keywords = new string[] { "happy", "sad", "scared", "cuddle", "next stage", "stage one", "stage two", "stage three", "stage four", "speak" };
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
		controller = stage2Menu.GetComponentInChildren<Stage2InstructionController> (); 
	}
	
	// Update is called once per frame
	void Update () {
		switch (word) {
		case "happy":
			controller.Happy (); 
			childAnim.SetTrigger ("Happy");
			word = "";
			break;
		case "sad": 
			controller.Sad ();  
			childAnim.SetTrigger ("Sad");
			word = "";
			break; 
		case "cuddle":
			controller.Cuddle (); 
			word = "";
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
			SceneManager.LoadScene ("Stage3", LoadSceneMode.Single); 
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
			if (stage2Menu.instrLarge.activeInHierarchy) {
				controller.Speak ();
				word = "";
			} else {
				stage2Menu.instrSmall.GetComponent<Stage4TTS> ().Speak (); 
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
