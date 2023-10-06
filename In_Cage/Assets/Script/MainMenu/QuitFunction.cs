using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitFunction : MonoBehaviour {
	public Button quitButton;

	// Use this for initialization
	void Start () {
		quitButton.onClick.AddListener (quitGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void quitGame(){
		//once click QuitButton, call this function to quit the game
		Debug.Log("Game exit");
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
