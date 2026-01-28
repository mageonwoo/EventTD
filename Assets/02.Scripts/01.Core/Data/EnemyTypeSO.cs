using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyType")]
public class EnemyTypeSO : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int maxHP;

    public GameObject EnemyPrefab => enemyPrefab;
    public int MaxHP => maxHP;
}
