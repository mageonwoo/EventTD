using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
/// <summary>
/// 1. 포탄이 활성화 될 위치를 정한다.
/// 2. 포탄 오브젝트 풀에서 하나 가져와 활성화시킨다.
/// 3. 범위 내 가장 가까운 적을 찾는다.
/// 4. 적을 향해 발사한다.
/// </summary>
public class TowerShooter : MonoBehaviour
{
    [SerializeField] Transform shootPos;
    [SerializeField] BombPool bombPool;
    [SerializeField] public Transform enemyPos;
    public Transform EnemyPos => enemyPos;

    float time;
    float coolTime = 1;

    Collider coll;
    [SerializeField] List<GameObject> listEnemy = new();

    void Awake()
    {
        bombPool = FindFirstObjectByType<BombPool>();
        coll = GetComponent<Collider>();
    }
    void Start()
    {
        Shoot();
    }

    void Update()
    {
        if (listEnemy == null) return;

        IfEnemyDie();

        time += Time.deltaTime;
        if (time > coolTime)
        {
            Shoot();
            time = 0;
        }

        float minDist = Mathf.Infinity;
        Transform nearest = null;

        foreach (var go in listEnemy)
        {
            float dist = (go.transform.position - this.transform.position).sqrMagnitude;

            if (dist < minDist)
            {
                minDist = dist;
                nearest = go.transform;
            }
        }

        if (enemyPos != null) return;

        enemyPos = nearest;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;

        listEnemy.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;

        listEnemy.Remove(other.gameObject);
    }

    void Shoot()
    {
        bombPool.Get(shootPos.position, shootPos.rotation);
    }

    void IfEnemyDie()
    {
        for (int i = listEnemy.Count - 1; i >= 0; i--)
        {
            if (listEnemy[i] == null) listEnemy.RemoveAt(i);
        }
    }
}
