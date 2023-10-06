using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class EnemyAttack : MonoBehaviour {
	private Vector2 direction;
	private Transform target;
	public GameObject attack;
	public float attackBreak;
	private float nextAttackTime;

	// Use this for initialization
	void Start () {
		nextAttackTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		float distance = Vector2.Distance(transform.position, player.transform.position);
		if (!Global.onBossFight) {
			if (distance < 5f) {
				if (Time.time >= nextAttackTime) {
					nextAttackTime = Time.time + attackBreak;
					Instantiate (attack, gameObject.transform.position, gameObject.transform.rotation);
				}
			}
		} else {
			if (distance < 10f) {
				if (Time.time >= nextAttackTime) {
					nextAttackTime = Time.time + attackBreak;
					Instantiate (attack, gameObject.transform.position, gameObject.transform.rotation);
				}
			}
		}
	}
}
