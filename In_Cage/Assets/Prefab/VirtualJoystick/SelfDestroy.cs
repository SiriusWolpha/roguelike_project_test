using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class SelfDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Global.usingJoystick) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
