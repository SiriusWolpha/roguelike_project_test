using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c2d : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void onCollisionEnter2D(Collider2D other){
		Debug.Log("collision!");
		if (other.CompareTag ("Player")) {
			Debug.Log ("碰撞发生");
		}
	}
}
