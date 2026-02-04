using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyType")]
public class EnemyTypeSO : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    public GameObject EnemyPrefab => enemyPrefab;

    [SerializeField] int maxHP;
    public int MaxHP => maxHP;

    [SerializeField] int waveLev = 0;
    public int WaveLev => waveLev;
}
