using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	public GameObject wallPrefab;
	public Transform wallPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("OnTriggerEnter");
		if (other.CompareTag("Bullet"))
		{
			Destroy(other.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("OnTriggerEnter2D");
		if (other.CompareTag("Bullet"))
		{
			Destroy(other.gameObject);
		}
	}

	public void makewall(){
		GameObject wallA1 = Instantiate(wallPrefab, wallPoint.position, wallPoint.rotation);
	}
}
