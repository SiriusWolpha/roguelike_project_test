using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class Init4All : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Player.InitSet ();
		Damage.InitSet ();
		Global.levelCount = 0;
		//.... and other init options
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
