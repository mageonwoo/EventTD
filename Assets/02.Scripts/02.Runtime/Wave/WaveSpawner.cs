using UnityEngine;
/// <summary>
/// 1. 웨이브 시작 신호 받음
/// 2. 스폰 지점에서 적 스폰 시작
/// 3. 1초마다 한 개체씩 생성
/// 4. 15초까지 웨이브당 총 15기의 적 스폰 후, 다음 웨이브까지 스폰 중지하고 대기
/// 5. 웨이브 시간이 다 차게되면 다음 웨이브를 시작.
/// 5. 다음 웨이브가 시작되면 다시 스폰 시작.
/// 6. 3.부터 반복
/// </summary>
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] WaveContext waveCxt;
    [SerializeField] GameObject enemyRoot;
    [SerializeField] EnemyPool enemyPool;


    void Awake()
    {
        if (!waveCxt)
            waveCxt = GetComponent<WaveContext>();
        if (!enemyPool)
            enemyPool = FindFirstObjectByType<EnemyPool>();
    }

    public void SpawnEnemy()
    {
        waveCxt.Data.spawnCoolDown += Time.deltaTime;

        if (waveCxt.Data.Spawned < waveCxt.Data.MaxSpawn)
        {
            if (waveCxt.Data.spawnCoolDown >= 1)
            {
                enemyPool.Get(waveCxt.Data.WaveIdx);
                waveCxt.Data.SpawnCount();
                waveCxt.Data.spawnCoolDown = 0;
            }
        }
        else
            return;
    }

    public void WaveTimer()
    {
        waveCxt.Data.waveTimer += Time.deltaTime;

        if (waveCxt.Data.waveTimer >= waveCxt.Data.WaveDur)
        {
            waveCxt.LevelUp();
        }
    }
}