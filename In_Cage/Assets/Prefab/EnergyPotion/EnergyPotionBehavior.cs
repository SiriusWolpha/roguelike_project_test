using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class EnergyPotionBehavior : MonoBehaviour {
	private int recPoint;

	void Start () {
		string jsonFile = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "energyPotion.json"));
		JObject jobj = JObject.Parse (jsonFile);
		recPoint = (int)jobj["recoveryPoint"];
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")){
			Player.energy = GetMin.Int (Player.MaxEnergy, Player.energy + recPoint);
			Destroy(gameObject);
		}
	}
}
