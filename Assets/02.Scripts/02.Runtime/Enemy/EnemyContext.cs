using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EnemyContext는 Enemy를 컨트롤 하기 위한 어댑터이다.
/// </summary>
public class EnemyContext : MonoBehaviour
{
    [SerializeField] WaveContext waveMgr;
    public EnemyTypeSO enemyType;
    public EnemyHP enemyHp;
    public EnemyMove enemyMove;

    public int routeIdx = 4;

    public bool enemyDead = false;

    // 이동 속도, HP, HUD & Hp스케일러
    void Awake()
    {
        waveMgr = FindFirstObjectByType<WaveContext>();
    }

    void OnTriggerEnter(Collider bomb)
    {
        if (!bomb.CompareTag("Bomb")) return;

        enemyHp.OnDamaged();
    }

    public void OnDied()
    {
        if (enemyDead) return;

        enemyDead = true;
        waveMgr.RemoveEnemy(this);
    }
}
