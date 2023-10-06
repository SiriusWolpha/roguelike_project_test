using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Close_1Behavior : MonoBehaviour {
	private float creatTime;

	// Use this for initialization
	void Start () {
		creatTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - creatTime > 5.0f) {
			Destroy (gameObject);
		}
	}
}
