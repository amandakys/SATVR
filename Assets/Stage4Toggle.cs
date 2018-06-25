using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Toggle : MonoBehaviour {
	private static Stage4Toggle _instance;
	public int subprotocol; 

	public static Stage4Toggle Instance { get { return _instance; }}


	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
			DontDestroyOnLoad (this.gameObject); 
		}
	}
}