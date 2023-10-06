using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
using Data;

public class Enemy5PrivateScript : MonoBehaviour {
	public GameObject toCreat1;
	public GameObject toCreat2;
	public GameObject toCreat3;
	public GameObject toCreat4;
	public float creatBreak;
	public int e_hp;
	private float nextCreatTime;

	// Use this for initialization
	void Start () {
		Global.onBossFight = true;
		nextCreatTime = Time.time + creatBreak;
		Global.bossHp = e_hp;
	}
	
	// Update is called once per frame
	void Update () {
		Global.bossHp = e_hp;
		if (Global.onBossFight) {
			if (e_hp <= 0) {
				Destroy (gameObject);
			}
		}
		if (Time.time > nextCreatTime) {
			int what = Generate.randint (1, 6);
			if (what == 1 || what == 2) {
				Instantiate (toCreat1, gameObject.transform.position, gameObject.transform.rotation);
			} else if (what == 3 || what == 4) {
				Instantiate (toCreat2, gameObject.transform.position, gameObject.transform.rotation);
			} else if (what == 5) {
				Instantiate (toCreat3, gameObject.transform.position, gameObject.transform.rotation);
			} else {
				Instantiate (toCreat4, gameObject.transform.position, gameObject.transform.rotation);
			}
			nextCreatTime = Time.time + creatBreak;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (Global.onBossFight) {
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
}
