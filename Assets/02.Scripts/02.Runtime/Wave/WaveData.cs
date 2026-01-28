using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 웨이브 관련 상태 수치 보관
/// 1. 적의 에셋은 무엇을 사용하는가.
/// 2. 한 판의 웨이브 수는 얼마인가.
/// 3. 적 수가 얼마를 초과하면 게임오버인가.
/// 4. 한 웨이브에 소환될 적의 숫자는 몇인가.
/// 5. 얼마의 간격으로 적이 소환될 것인가.
/// 6. 한 웨이브의 시간은 얼마인가.
/// </summary>
public class WaveData : MonoBehaviour
{
    [SerializeField] EnemyTypeSO enemySO;
    public EnemyTypeSO EnemySO => enemySO;

    [SerializeField] int waveIdx = 0;
    public int WaveIdx => waveIdx;

    [SerializeField] int limitEnemyCount = 20;
    public int LimitCount => limitEnemyCount;

    [SerializeField] int aliveEnemy = 0;
    public int Alive => aliveEnemy;

    [SerializeField] int spawnedEnemy = 0;
    public int Spawned => spawnedEnemy;

    [SerializeField] int maxSpawnCount = 15;
    public int MaxSpawn => maxSpawnCount;

    [SerializeField] public float spawnCoolDown = 1f;

    [SerializeField] public float waveTimer = 0f;
    [SerializeField] float waveDuration = 30f;
    public float WaveDur => waveDuration;

    [SerializeField] int killCount = 0;
    public int Kill => killCount;
    public void WaveLevelUp()
    {
        SpawnCleaner();
        waveIdx++;
    }

    public void SpawnCount()
    {
        spawnedEnemy++;
        aliveEnemy++;
    }

    public void EnemyKill()
    {
        killCount++;
        
        aliveEnemy--;
        if(aliveEnemy < 0)
        aliveEnemy =0;
    }

    public void SpawnCleaner()
    {
        spawnedEnemy = 0;
    }


}