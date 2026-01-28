using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform prevPos;
    [SerializeField] EnemyContext enemyCxt;
    [SerializeField] Rigidbody rb;
    float moveSpeed = 2.0f;
    float minDist = 0.05f;
    [SerializeField] int routeIdx;
    void Start()
    {
        prevPos = enemyCxt.enemyRoute[0];
        transform.position = prevPos.position;
        routeIdx = 0;
    }

    void Update()
    {
        var enemyRoute = enemyCxt.enemyRoute;
        if (routeIdx > enemyRoute.Length)
            return;
        Vector3 targetPos = enemyRoute[routeIdx].position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // 도착판정 float 수치
        float dist = Vector3.Distance(transform.position, targetPos);
        if (dist <= minDist)
        {
            routeIdx++;
            if (routeIdx >= enemyRoute.Length)
                routeIdx = 0;
        }
        // if문으로 최소거리를 만족하면 다음 웨이포인트로 가도록 routeIdx를 증가시켜 targetPos를 바꿔준다.
    }
}