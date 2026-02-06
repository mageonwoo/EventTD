using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EnemyContext는 Enemy를 컨트롤 하기 위한 어댑터이다.
/// </summary>
public class EnemyContext : MonoBehaviour
{
    [SerializeField] WaveContext waveCtx;
    public EnemyTypeSO enemyType;
    public EnemyHP enemyHp;
    public EnemyMove enemyMove;

    public bool enemyDead = false;

    // 이동 속도, HP, HUD & Hp스케일러
    void Awake()
    {
        waveCtx = FindFirstObjectByType<WaveContext>();
    }

    void OnTriggerEnter(Collider bomb)
    {
        if (!bomb.CompareTag("Bomb")) return;

        enemyHp.OnDamaged();
    }

    public void OnDied()
    {
        if (enemyDead) return;
        Debug.Log("Send this enemy is dead");

        enemyDead = true;
        waveCtx.RemoveEnemy(this);
    }

    public void ResetState()
    {
        enemyDead = false;
    }
}
