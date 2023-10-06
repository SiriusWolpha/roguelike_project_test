using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	/*
    public float bulletSpeed = 10f; // 子弹速度

    private Transform target; // 最近的敌人的Transform
	private Transform target2;
    private Vector2 moveDirection; // 子弹的移动方向
    private GameObject _enemy;

    private void Start()
    {
        // 在开始时寻找最近的敌人
        FindNearestEnemy();
		FindWall ();
    }

    private void Update()
    {
        if (target != null)
        {
            // 计算子弹的移动方向向量
            moveDirection = (target.position - transform.position).normalized;

            // 移动子弹
            transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);

            // 如果子弹到达了目标敌人，销毁子弹
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
				bulletSpeed = 0f;
                Destroy(gameObject);
                Destroy(_enemy);
            }
			if (target2 != null) {
				if (Vector2.Distance (transform.position, target2.position) < 0.1f) {
					Destroy (gameObject);
				}
			}
        }
        else
        {
            // 如果没有目标敌人，销毁子弹
            Destroy(gameObject, 2f);
			//Destroy(gameObject);
            float nearestDistance = float.MaxValue;
            transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
        }
    }

    void FindNearestEnemy()
    {
        // 查找场景中所有敌人的Transform
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            // 初始化最近距离为无限大
            float nearestDistance = float.MaxValue;

            foreach (GameObject enemy in enemies)
            {
                // 计算子弹到敌人的距离
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                // 如果当前敌人更近，则更新目标
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    target = enemy.transform;
                    _enemy = enemy;
                }
            }
        }
    }

	void FindWall()
	{
		// 查找场景中所有敌人的Transform
		GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

		if (walls.Length > 0)
		{
			// 初始化最近距离为无限大
			float nearestDistance2 = float.MaxValue;

			foreach (GameObject wall in walls)
			{
				// 计算子弹到敌人的距离
				float distance2 = Vector2.Distance(transform.position, wall.transform.position);

				// 如果当前敌人更近，则更新目标
				if (distance2 < nearestDistance2)
				{
					nearestDistance2 = distance2;
					target2 = wall.transform;
				}
			}
		}
	}

	private void Update()
	{
		// 子弹每帧检测与敌人的距离
		if (target != null)
		{
			// 计算子弹的移动方向向量
			moveDirection = (target.position - transform.position).normalized;

			// 移动子弹
			transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);

			// 如果子弹到达了目标敌人，销毁子弹
			if (Vector2.Distance(transform.position, target.position) < 0.1f)
			{
				//bulletSpeed = 0f;
				Destroy(gameObject);
				Destroy(_enemy);
			}
			if (target2 != null) {
				if (Vector2.Distance (transform.position, target2.position) < 0.1f) {
					Destroy (gameObject);
				}
			}
		}
		else
		{
			// 如果没有目标敌人，销毁子弹
			Destroy(gameObject, 2f);
			//Destroy(gameObject);
			float nearestDistance = float.MaxValue;
			transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
		}
		CheckDistanceToEnemy();
	}

	void CheckDistanceToEnemy()
	{
		// 获取场景中所有标签为"Enemy"的敌人
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		// 遍历所有敌人，检测与子弹的距离
		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);

			// 如果与敌人的距离小于0.1，则销毁子弹并更新敌人的计数器
			if (distance < 0.1f)
			{
				Destroy(gameObject); // 销毁子弹
				//enemy.GetComponent<EnemyScript>().IncrementCounter(); // 更新敌人的计数器
				Destroy(enemy);
				break; // 一颗子弹只能命中一个敌人，所以可以提前结束循环
			}
		}
	}
	*/
	/*
	private Transform target; // 最近的敌人的引用
	public float bulletSpeed = 10f; // 子弹飞行速度
	public float detectionRange = 5f; // 检测敌人的范围
	private bool isFlying = false; // 子弹是否在飞行中
	private GameObject __enemy__;

	void Start()
	{
		// 在Start中查找最近的敌人
		FindClosestEnemy();
	}

	void Update()
	{
		if (isFlying)
		{
			// 子弹飞行向目标方向
			if (target != null)
			{
				Vector3 direction = (target.position - transform.position).normalized;
				transform.Translate(direction * bulletSpeed * Time.deltaTime);

				// 检测与敌人的距离
				float distance = Vector3.Distance(transform.position, target.position);

				if (distance < 0.1f)
				{
					// 销毁子弹并更新敌人的计数器
					Destroy(gameObject);
					//target.GetComponent<EnemyScript>().IncrementCounter();
					Destroy(__enemy__);
				}
			}
			else
			{
				// 如果敌人被销毁，也销毁子弹
				Destroy(gameObject);
			}
		}
	}

	void FindClosestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float closestDistance = Mathf.Infinity;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);

			// 如果距离小于检测范围并且更近，则更新目标为当前敌人
			if (distance < detectionRange && distance < closestDistance)
			{
				closestDistance = distance;
				target = enemy.transform;
				__enemy__ = enemy;
			}
		}

		if (target != null)
		{
			isFlying = true; // 开始飞行向敌人
		}
	}
	*/
	/*
	private Transform target; // 最近的敌人的引用
	private Vector3 direction; // 子弹飞行方向
	public float bulletSpeed = 10f; // 子弹飞行速度
	public float detectionRange = 5f; // 检测敌人的范围
	private bool isFlying = false; // 子弹是否在飞行中
	private bool hasHitEnemy = false; // 是否已击中敌人

	void Start()
	{
		// 在Start中查找最近的敌人和计算飞行方向
		FindClosestEnemy();
	}

	void Update()
	{
		if (isFlying)
		{
			// 子弹飞行朝方向
			transform.Translate(direction * bulletSpeed * Time.deltaTime);

			if (!hasHitEnemy)
			{
				// 检测与周围所有敌人的距离
				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

				foreach (GameObject enemy in enemies)
				{
					float distance = Vector3.Distance(transform.position, enemy.transform.position);

					if (distance < 0.2f)
					{
						// 销毁敌人和子弹
						Destroy(enemy);
						Destroy(gameObject);
						break;
					}
				}
			}
		}
	}

	void FindClosestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float closestDistance = Mathf.Infinity;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);

			// 如果距离小于检测范围并且更近，则更新目标为当前敌人
			if (distance < detectionRange && distance < closestDistance)
			{
				closestDistance = distance;
				target = enemy.transform;
				direction = (target.position - transform.position).normalized;
			}
		}

		if (target != null)
		{
			isFlying = true; // 开始飞行向敌人
		}
	}
	*/
	/*
	private Transform target; // 最近的敌人的引用
	private Vector3 direction; // 子弹飞行方向
	public float bulletSpeed = 10f; // 子弹飞行速度
	public float detectionRange = 5f; // 检测敌人的范围
	public float enemyDestroyRange = 0.2f; // 敌人销毁范围
	public float wallDestroyRange = 0.1f; // 墙壁销毁范围

	private bool isFlying = false; // 子弹是否在飞行中

	void Start()
	{
		FindClosestEnemy();
	}

	void Update()
	{
		if (isFlying)
		{
			// 子弹飞行朝方向
			transform.Translate(direction * bulletSpeed * Time.deltaTime);

			// 检测与周围所有敌人的距离
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject enemy in enemies)
			{
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

				if (distanceToEnemy < enemyDestroyRange)
				{
					// 销毁敌人和子弹
					Destroy(enemy);
					Destroy(gameObject);
					break;
				}
			}

			// 检测与周围所有墙的距离
			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
			foreach (GameObject wall in walls)
			{
				float distanceToWall = Vector3.Distance(transform.position, wall.transform.position);

				if (distanceToWall < wallDestroyRange)
				{
					// 销毁子弹
					Destroy(gameObject);
					break;
				}
			}
		}
	}

	void FindClosestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float closestDistance = Mathf.Infinity;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);

			// 如果距离小于检测范围并且更近，则更新目标为当前敌人
			if (distance < detectionRange && distance < closestDistance)
			{
				closestDistance = distance;
				target = enemy.transform;
				direction = (target.position - transform.position).normalized;
				isFlying = true; // 开始飞行向敌人
			}
		}

		if (target == null)
		{
			// 当地图中没有敌人时，随机朝一个方向飞行
			direction = Random.insideUnitCircle.normalized;
			isFlying = true;
		}
	}
	*/
	/*
	private Transform target; // 最近的敌人的引用
	private Vector3 direction; // 子弹飞行方向
	public float bulletSpeed = 10f; // 子弹飞行速度
	//public float detectionRange = 25000f; // 检测敌人的范围
	private bool isFlying = false; // 子弹是否在飞行中

	private Vector3 randomDirection; // 随机方向
	private float randomDirectionTimer = 0f; // 随机方向计时器

	void Start()
	{
		FindClosestEnemy();
		SetRandomDirection();
	}

	void Update()
	{
		if (isFlying)
		{
			// 子弹飞行朝方向
			transform.Translate(direction * bulletSpeed * Time.deltaTime);

			// 检测与周围所有敌人的距离
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

			foreach (GameObject enemy in enemies)
			{
				float distance = Vector3.Distance(transform.position, enemy.transform.position);

				if (distance < 0.2f)
				{
					// 销毁敌人和子弹
					Destroy(enemy);
					Destroy(gameObject);
					break;
				}
			}

			// 检测与墙的距离
			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

			foreach (GameObject wall in walls)
			{
				float distance = Vector3.Distance(transform.position, wall.transform.position);

				if (distance < 0.1f)
				{
					// 销毁子弹
					Destroy(gameObject);
					break;
				}
			}
		}
		else
		{
			// 如果没有敌人，每3秒生成一个随机方向
			randomDirectionTimer += Time.deltaTime;
			if (randomDirectionTimer >= 6f)
			{
				SetRandomDirection();
			}
			transform.Translate(randomDirection * bulletSpeed * Time.deltaTime);
		}
	}

	void FindClosestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float closestDistance = Mathf.Infinity;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);

			// 如果距离小于检测范围并且更近，则更新目标为当前敌人
			if (/distance < detectionRange && /distance < closestDistance)
			{
				closestDistance = distance;
				target = enemy.transform;
				direction = (target.position - transform.position).normalized;
			}
		}

		if (target != null)
		{
			isFlying = true; // 开始飞行向敌人
		}
	}

	void SetRandomDirection()
	{
		randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
		randomDirectionTimer = 0f;
	}*/
	private Transform target; // 最近的敌人的引用
	private Vector2 direction; // 子弹飞行方向
	public float bulletSpeed = 10f; // 子弹飞行速度
	public float detectionRange = 5f; // 检测敌人的范围
	private bool isFlying = false; // 子弹是否在飞行中

	private Vector2 randomDirection; // 随机方向
	private float randomDirectionTimer = 0f; // 随机方向计时器

	void Start()
	{
		FindClosestEnemy();
		SetRandomDirection();
	}

	void Update()
	{
		if (isFlying)
		{
			// 子弹飞行朝方向
			transform.Translate(direction * bulletSpeed * Time.deltaTime);

			// 检测与周围所有敌人的距离
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

			foreach (GameObject enemy in enemies)
			{
				float distance = Vector2.Distance(transform.position, enemy.transform.position);

				if (distance < 0.2f)
				{
					// 销毁敌人和子弹
					Destroy(enemy);
					Destroy(gameObject);
					break;
				}
			}

			// 检测与墙的距离
			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

			foreach (GameObject wall in walls)
			{
				float distance = Vector2.Distance(transform.position, wall.transform.position);

				if (distance < 0.1f)
				{
					// 销毁子弹
					Destroy(gameObject);
					break;
				}
			}
		}
		else
		{
			// 如果没有敌人，每3秒生成一个随机方向
			randomDirectionTimer += Time.deltaTime;
			if (randomDirectionTimer >= 3f)
			{
				SetRandomDirection();
			}
			transform.Translate(randomDirection * bulletSpeed * Time.deltaTime);
		}
	}

	void FindClosestEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float closestDistance = Mathf.Infinity;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector2.Distance(transform.position, enemy.transform.position);

			// 如果距离小于检测范围并且更近，则更新目标为当前敌人
			if (/*distance < detectionRange &&*/ distance < closestDistance)
			{
				closestDistance = distance;
				target = enemy.transform;
				direction = (target.position - transform.position).normalized;
			}
		}

		if (target != null)
		{
			isFlying = true; // 开始飞行向敌人
		}
	}

	void SetRandomDirection()
	{
		randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
		randomDirectionTimer = 0f;
	}
}
