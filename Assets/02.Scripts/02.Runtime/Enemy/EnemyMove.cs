using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform prevPos;
    // [SerializeField] EnemyContext enemyCtx;
    // [SerializeField] WaveContext waveCtx;
    [SerializeField] Rigidbody rb;
    float moveSpeed = 2.0f;
    float minDist = 0.05f;
    Transform[] route;
    [SerializeField] int routeIdx;

    /// <summary>
    /// Start 호출 시점에 다른 로직들과 사이클 혼선 문제로 NRE가 발생할 수 있다.
    /// 그래서 Init으로 스폰될 때 초기화를 하는 것으로 오류 발생 가능성을 제거한다.
    /// </summary>
    // void Start()
    // {
    //     prevPos = route[0];
    //     transform.position = prevPos.position;
    //     routeIdx = 0;
    // }

    void Update()
    {
        if (route == null) return;
        if (routeIdx > route.Length) return;
        Vector3 targetPos = route[routeIdx].position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // 도착판정 float 수치
        float dist = Vector3.Distance(transform.position, targetPos);
        if (dist <= minDist)
        {
            routeIdx++;
            if (routeIdx >= route.Length)
                routeIdx = 0;
        }
        // if문으로 최소거리를 만족하면 다음 웨이포인트로 가도록 routeIdx를 증가시켜 targetPos를 바꿔준다.
    }

    /// <summary>
    /// WaveSpawner에서 적을 스폰시켜 활성화 시킬 때 WaveCtx가 가지고 있는 Route정보를 주입시켜
    /// Start지점에서 발생할 수 있는 NRE가능성을 제거한다.
    /// </summary>
    /// <param name="enemyRoute"></param>
    public void InitRoute(Transform[] enemyRoute)
    {
        this.route = enemyRoute;

        if (this.route != null && this.route.Length > 0)
        {
            this.routeIdx = 0;
            this.prevPos = route[0];
            this.transform.position = this.prevPos.position;
        }
    }
}