using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

public class TreasureChestBehavior : MonoBehaviour {
	private Vector3 orgPos;
	public GameObject itemPrefab1;
	public GameObject itemPrefab2;
	public GameObject itemPrefab3;
	public GameObject itemPrefab4;

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
			other.CompareTag("U_Close_1")||other.CompareTag("U_Close_2")
		){
			int ans = Generate.randint (1, 8);
			if (ans == 1 || ans == 2) {
				Instantiate (itemPrefab1, transform.position, transform.rotation);
			} else if (ans == 3 || ans == 4) {
				Instantiate (itemPrefab2, transform.position, transform.rotation);
			} else if (ans == 5 || ans == 6) {
				Instantiate (itemPrefab3, transform.position, transform.rotation);
			} else {
				Instantiate (itemPrefab4, transform.position, transform.rotation);
			}
			Destroy(other.gameObject);
			Destroy (gameObject);
		}
	}
}
