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
    [SerializeField] WaveContext waveCtx;
    [SerializeField] GameObject enemyRoot;
    [SerializeField] EnemyPool enemyPool;


    void Awake()
    {
        if (!waveCtx)
            waveCtx = GetComponent<WaveContext>();
        if (!enemyPool)
            enemyPool = FindFirstObjectByType<EnemyPool>();
    }

    public void SpawnEnemy()
    {
        waveCtx.Data.spawnCoolDown += Time.deltaTime;

        if (waveCtx.Data.Spawned < waveCtx.Data.MaxSpawn)
        {
            if (waveCtx.Data.spawnCoolDown >= 1)
            {
                waveCtx.CallUpEnemy();
                waveCtx.Data.SpawnCount();
                waveCtx.Data.spawnCoolDown = 0;
            }
        }
        else
            return;
    }

    public void WaveTimer()
    {
        waveCtx.Data.waveTimer += Time.deltaTime;

        if (waveCtx.Data.waveTimer >= waveCtx.Data.WaveDur)
        {
            waveCtx.LevelUp();
        }
    }
}