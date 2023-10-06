using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Data;

public class SetSkillID : MonoBehaviour {
	public string toLoad;
	public Button thisButton;
	public int ID2Set;

	// Use this for initialization
	void Start () {
		thisButton.onClick.AddListener (Load);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Load(){
		//load appointed scene
		Player.skillType = ID2Set;
		SceneManager.LoadScene (toLoad);
	}
}
