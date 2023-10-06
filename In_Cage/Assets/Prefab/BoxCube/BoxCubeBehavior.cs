using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
using Data;

public class BoxCubeBehavior : MonoBehaviour {
	private Vector3 orgPos;
	public GameObject itemPrefab1;
	public GameObject itemPrefab2;
	public GameObject itemPrefab3;

	// Use this for initialization
	void Start () {
		orgPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curPos = transform.position;
		Vector3 deltaPos = curPos - orgPos;
		if (deltaPos.magnitude > 0.1f) {
			transform.position = orgPos;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("U_Bullet_small")||other.CompareTag("U_Bullet_middle")||other.CompareTag("U_Bullet_large")||
			other.CompareTag("E_Bullet_small")||other.CompareTag("E_Bullet_large")||other.CompareTag("E_Close")||
			other.CompareTag("U_Close_1")||other.CompareTag("U_Close_2")
		){
			int ans = Generate.randint (0, 20);
			//ans : 0~14-nothing, 15~16-hpPotion, 17~18-energyPotion, 19~20-coin
			if (ans == 15 || ans == 16) {
				Instantiate (itemPrefab1, transform.position, transform.rotation);
			} else if (ans == 17 || ans == 18) {
				Instantiate (itemPrefab2, transform.position, transform.rotation);
			} else if (ans == 19 || ans == 20) {
				Instantiate (itemPrefab3, transform.position, transform.rotation);
			}
			Destroy(other.gameObject);
			Destroy (gameObject);
		}
	}
}
