using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BulletBehavior : MonoBehaviour {
	//private Vector2 randomDirection; //direction bullet goes
	public float bulletSpeed = 8.0f;
	public float detectRange = 5.0f;
	private Vector2 direction;
	private Transform target;

	// Use this for initialization
	void Start () {
		//randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
		FindPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction * bulletSpeed * Time.deltaTime);
	}

	void FindPlayer(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float closestDistance = Mathf.Infinity;
		//
		if (!player) {
			direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
		}else{
			float distance = Vector2.Distance(transform.position, player.transform.position);
			// update if find a closer enemy
			if (distance < 5f) {
				target = player.transform;
				direction = (target.position - transform.position).normalized;
			} else {
				direction = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f)).normalized;
			}
		}
	}
}
