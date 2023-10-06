using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shot : MonoBehaviour {
	public GameObject bulletPrefab; // 子弹的预制体
    public Transform firePoint; // 发射子弹的位置
	//public GameObject wallPrefab;
	//public Transform[] wallPoints;
    public float bulletSpeed = 10f; // 子弹速度
	public float fireRate = 0.2f;

	public float maxHp = 100f;
	public float damage = 4f;
	public Text hpText;
	private float hp;

	private float nextFireTime;
	private int tm = 0;

	private void Start(){
		nextFireTime = Time.time;
	}

	private void OnCollisionEnter(Collision other){
		Debug.Log ("碰撞发生");
		if (other.collider.tag == "Enemy") {
			TakeDmamge (damage);
			UpdateUI ();
		}
	}

    private void Update()
    {
		if (Input.GetKey(KeyCode.Space)&&Time.time >= nextFireTime)
        {
			nextFireTime = Time.time + fireRate;
            Shoot();
			/*
			GameObject wallA1 = Instantiate(wallPrefab, wallPoint.position, wallPoint.rotation);
			GameObject wallA2 = Instantiate(wallPrefab, wallPoint.position, wallPoint.rotation);
			GameObject wallA3 = Instantiate(wallPrefab, wallPoint.position, wallPoint.rotation);
			GameObject wallA4 = Instantiate(wallPrefab, wallPoint.position, wallPoint.rotation);
			GameObject wallA5 = Instantiate(wallPrefab, wallPoint.position, wallPoint.rotation);
			*/
			/*
			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
			foreach(GameObject wall in walls){
				
				GameObject wP = wall.GetComponent<Wall>().wallPrefab;
				Transform wPt = wall.GetComponent<Wall> ().wallPoint;
				Instantiate(wP, wPt.position, wPt.rotation);

				//Wall thisWall = wall.GetComponent<Wall>();
				//thisWall.makewall ();
				//wall.GetComponent<Wall>().makewall();
				if (wall != null) {
					Wall thisWall = wall.GetComponent<Wall> ();
					if (thisWall != null) {
						thisWall.makewall ();
					} else {
						Debug.Log ("Error type 1 : wall.GetComponent<Wall>() is null");
					}
				} else {
					Debug.Log ("Error type 2 : GameObject wall not found");
				}
			}
			*/
			/*
			foreach (Transform wallPoint in wallPoints) {
				Instantiate (wallPrefab, wallPoint.position, wallPoint.rotation);
			}
			*/
        }
		UpdateUI ();
    }

	
	void UpdateUI(){
		if (hpText != null) {
			hpText.text = tm.ToString ();
		}
	}
	void TakeDmamge(float dmg){
		hp -= dmg;
		if (hp < 0) {
			hp = 0;
		}
	}

    void Shoot()
    {
        // 创建子弹实例
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		tm += 1;
		/*
        // 获取子弹的刚体组件
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // 设置子弹的速度
        rb.velocity = firePoint.up * bulletSpeed;

		firePoint.Translate(rb.velocity * Time.deltaTime);
		*/
        // 销毁子弹2秒后，以防止场景中子弹过多
        Destroy(bullet, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 当玩家的子弹击中敌人时
        if (other.CompareTag("Enemy"))
        {
            // 销毁敌人对象
            //Destroy(other.gameObject);
			Debug.Log("case 1");
        }
    }
}
