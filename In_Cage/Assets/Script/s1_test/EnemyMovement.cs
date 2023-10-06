using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // 敌人的移动速度
    public float minChangeTime = 1f; // 最小改变方向时间
    public float maxChangeTime = 3f; // 最大改变方向时间

    private Vector2 targetPosition; // 目标位置
    private float changeDirectionTimer; // 改变方向计时器

    private void Start()
    {
        // 初始时设置一个随机目标位置
        SetRandomTargetPosition();

        // 初始化计时器
        changeDirectionTimer = Random.Range(minChangeTime, maxChangeTime);
    }

    private void Update()
    {
        // 移动向目标位置
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 如果到达目标位置，设置新的目标位置
        if ((Vector2)transform.position == targetPosition)
        {
            SetRandomTargetPosition();
            changeDirectionTimer = Random.Range(minChangeTime, maxChangeTime);
        }

        // 更新计时器，当计时器达到0时，设置新的目标位置
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0f)
        {
            SetRandomTargetPosition();
            changeDirectionTimer = Random.Range(minChangeTime, maxChangeTime);
        }
    }

    void SetRandomTargetPosition()
    {
        // 随机生成新的目标位置
        targetPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
    }
}
*/
