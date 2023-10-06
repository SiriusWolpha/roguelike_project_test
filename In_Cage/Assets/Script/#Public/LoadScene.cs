using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	//varibles to bind
	public string toLoad;
	public Button thisButton;

	// Start
	void Start () {
		thisButton.onClick.AddListener (Load);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Load(){
		//load appointed scene
		SceneManager.LoadScene (toLoad);
	}
}
