using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class move : MonoBehaviour {
	public string direction;
	public Button thisButton;
	public Transform player;

	// Use this for initialization
	void Start () {
		thisButton.onClick.AddListener (MOVE);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MOVE(){
		switch (direction) {
		case "up":
			player.Translate (Vector3.up * Player.MoveSpeed * Time.deltaTime);
			break;
		case "down":
			player.Translate (Vector3.down * Player.MoveSpeed * Time.deltaTime);
			break;
		case "left":
			player.Translate (Vector3.left * Player.MoveSpeed * Time.deltaTime);
			break;
		case "right":
			player.Translate (Vector3.right * Player.MoveSpeed * Time.deltaTime);
			break;
		}
	}
}
