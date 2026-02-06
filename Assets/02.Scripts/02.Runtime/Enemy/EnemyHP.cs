using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    /// <summary>
    /// HP변수는 SO에서 얕게 복사해서 가져온다.
    /// </summary>
    public EnemyContext enemyCtx;
    public int curHP;
    [SerializeField] int maxHP;

    void Awake()
    {
        enemyCtx = GetComponent<EnemyContext>();
        maxHP = enemyCtx.enemyType.MaxHP;
        curHP = maxHP;
    }

    public void HPReset()
    {
        curHP = maxHP;
    }

    public void OnDamaged()
    {
        // Debug.Log("OnDamaged");
        if (enemyCtx.enemyDead)
        {
            Debug.Log("this enemy already dead");
            return;
        }

        curHP--;

        if (curHP <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (enemyCtx.enemyDead) return;

        enemyCtx.OnDied();
    }
}
