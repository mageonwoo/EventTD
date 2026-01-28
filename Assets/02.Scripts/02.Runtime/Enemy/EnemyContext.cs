using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EnemyContext는 Enemy를 컨트롤 하기 위한 어댑터이다.
/// </summary>
public class EnemyContext : MonoBehaviour
{
    [SerializeField] WaveManager waveMgr;
    public EnemyTypeSO enemyType;
    public Transform[] enemyRoute;
    public EnemyHP enemyHp;

    public int routeIdx = 4;

    public bool enemyDead = false;

    // 이동 속도, HP, HUD & Hp스케일러
    void Awake()
    {
        waveMgr = FindFirstObjectByType<WaveManager>();

        var r = GameObject.FindWithTag("Route");
        var all = r.GetComponentsInChildren<Transform>();

        enemyRoute = new Transform[all.Length - 1];
        for (int i = 1; i < all.Length; ++i)
        {
            enemyRoute[i - 1] = all[i];
        }
    }

    void OnTriggerEnter(Collider bomb)
    {
        if (!bomb.CompareTag("Bomb")) return;

        enemyHp.OnDamaged();
    }

    public void OnDied()
    {
        if(enemyDead) return;

        enemyDead = true;
        waveMgr.ReportEnemyDead();
    }
}
