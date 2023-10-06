using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class HpPotionBehavior : MonoBehaviour {
	private int recPoint;

	// Use this for initialization
	void Start () {
		string jsonFile = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "hpPotion.json"));
		JObject jobj = JObject.Parse (jsonFile);
		recPoint = (int)jobj["recoveryPoint"];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")){
			Player.hp = GetMin.Int (Player.Maxhp, Player.hp + recPoint);
			Destroy(gameObject);
		}
	}
}
