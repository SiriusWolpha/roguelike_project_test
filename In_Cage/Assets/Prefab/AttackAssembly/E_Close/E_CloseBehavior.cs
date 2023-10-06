using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
using Data;

public class E_CloseBehavior : MonoBehaviour {
	private float creatTime;
	public float attackRadius = 0.8f;

	// Use this for initialization
	void Start () {
		creatTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		float distance = Vector3.Distance(transform.position, player.transform.position);
		if (distance < attackRadius) {
			TakeDamage.p (Damage.e_close);
			Destroy (gameObject);
		}
		if (Time.time - creatTime > 0.5f) {
			Destroy (gameObject);
		}
	}
}
