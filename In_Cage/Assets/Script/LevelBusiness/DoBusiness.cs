using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Service;
using UnityEngine.UI;

public class DoBusiness : MonoBehaviour {
	public int id;
	public int cost;
	public Button thisButton;

	// Use this for initialization
	void Start () {
		thisButton.onClick.AddListener (Buy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Buy(){
		if (Player.coins >= cost) {
			Player.coins -= cost;
			if (id == 1 || id == 2 || id == 3 || id == 4 || id == 5) {
				Player.weaponType = Player.playerWeapon1 = id;
			} else if (id == 6) {
				Player.hp = GetMin.Int (Player.Maxhp, Player.hp + 3);
			} else {
				Player.energy = GetMin.Int (Player.MaxEnergy, Player.energy + 30);
			}
		}
	}
}
