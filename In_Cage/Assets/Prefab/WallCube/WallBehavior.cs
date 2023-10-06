using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour {
	private Vector3 orgPos;

	void Start(){
		orgPos = transform.position;
	}

	void Update(){
		Vector3 curPos = transform.position;
		Vector3 deltaPos = curPos - orgPos;
		if (deltaPos.magnitude > 0.1f) {
			transform.position = orgPos;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//Check : if bullet hit the wall, destroy the bullet
		if (other.CompareTag("U_Bullet_small")||other.CompareTag("U_Bullet_middle")||other.CompareTag("U_Bullet_large")||
			other.CompareTag("E_Bullet_small")||other.CompareTag("E_Bullet_large")||other.CompareTag("E_Close")||
			other.CompareTag("U_Close_1")||other.CompareTag("U_Close_2")
		){
			Destroy(other.gameObject);
		}
	}
}
