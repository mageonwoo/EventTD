using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    /// <summary>
    /// HP변수는 SO에서 얕게 복사해서 가져온다.
    /// </summary>
    public EnemyContext enemyCtx;
    int curHP;
    [SerializeField] int maxHP;

    void Awake()
    {
        enemyCtx = GetComponent<EnemyContext>();
        maxHP = enemyCtx.enemyType.MaxHP;
        curHP = maxHP;
    }

    public void OnDamaged()
    {
        curHP--;

        if (curHP <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        // gameObject.SetActive(false);
        enemyCtx.OnDied();
        Destroy(gameObject);
    }
}
