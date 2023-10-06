using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class U_BulletBehavior : MonoBehaviour {
	private Transform target; //the nearest enemy
	private Vector2 direction; //direction bullet goes
	private float bulletSpeed = Player.bulletSpeed;

	// Use this for initialization
	void Start () {
		FindClosestEnemy();//find the enemy if an instantiate is created
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction * bulletSpeed * Time.deltaTime);//move
	}

	void FindClosestEnemy(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float closestDistance = Mathf.Infinity;
		//
		if (enemies.Length == 0) {
			Vector2 d = new Vector2 (-1.0f, 0f);
			direction = d.normalized;
		}
		//use foreach loop to check
		foreach (GameObject enemy in enemies){
			float distance = Vector2.Distance(transform.position, enemy.transform.position);
			// update if find a closer enemy
			if (distance < closestDistance){
				closestDistance = distance;
				target = enemy.transform;
				direction = (target.position - transform.position).normalized;
			}
		}
	}
}
