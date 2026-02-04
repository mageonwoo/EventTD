using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolBrid : MonoBehaviour
{
    EnemyTypeSO enemyType;
    public int enemyLev;

    void Awake()
    {
        if (enemyType != null)
        {
            enemyLev = enemyType.WaveLev;
        }
    }
}
