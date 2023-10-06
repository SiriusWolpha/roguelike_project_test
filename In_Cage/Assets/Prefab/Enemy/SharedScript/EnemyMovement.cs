using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Service;

public class EnemyMovement : MonoBehaviour {
	public float moveSpeed = 3f; // enemy move speed
	public float minChangeTime = 1f; 
	public float maxChangeTime = 3f;

	public GameObject itemPrefab1;
	public GameObject itemPrefab2;
	public GameObject itemPrefab3;

	private Vector2 targetPosition; // where to go
	private float changeDirectionTimer;

	public int e_hp;

	private void Start()
	{
		SetRandomTargetPosition();

		changeDirectionTimer = Random.Range(minChangeTime, maxChangeTime);
	}

	private void Update()
	{
		if (e_hp <= 0) {
			int ans = Generate.randint (0, 20);
			//ans : 0~14-nothing, 15~16-hpPotion, 17~18-energyPotion, 19~20-coin
			if (ans == 15 || ans == 16) {
				Instantiate (itemPrefab1, transform.position, transform.rotation);
			} else if (ans == 17 || ans == 18) {
				Instantiate (itemPrefab2, transform.position, transform.rotation);
			} else if (ans == 19 || ans == 20) {
				Instantiate (itemPrefab3, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}
		// move to the generated position
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

		if ((Vector2)transform.position == targetPosition)
		{
			SetRandomTargetPosition();
			changeDirectionTimer = Random.Range(minChangeTime, maxChangeTime);
		}
			
		changeDirectionTimer -= Time.deltaTime;
		if (changeDirectionTimer <= 0f)
		{
			SetRandomTargetPosition();
			changeDirectionTimer = Random.Range(minChangeTime, maxChangeTime);
		}
	}

	void SetRandomTargetPosition()
	{
		targetPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
	}

	//----take damage-------------------------------------------------------
	void OnTriggerEnter2D(Collider2D other){
		//Check : if bullet hit the wall, destroy the bullet
		if (other.CompareTag ("U_Bullet_small")) {
			Destroy (other.gameObject);
			e_hp -= Damage.u_bullet_small;
		}
		if (other.CompareTag ("U_Bullet_middle")) {
			Destroy (other.gameObject);
			e_hp -= Damage.u_bullet_middle;
		}
		if (other.CompareTag ("U_Bullet_large")) {
			Destroy (other.gameObject);
			e_hp -= Damage.u_bullet_large;
		}
		if (other.CompareTag ("U_Close_1")) {
			//Destroy(other.gameObject);
			e_hp -= Damage.u_close_1;
		}
		if (other.CompareTag ("U_Close_2")) {
			//Destroy(other.gameObject);
			e_hp -= Damage.u_close_2;
		}
	}
}
