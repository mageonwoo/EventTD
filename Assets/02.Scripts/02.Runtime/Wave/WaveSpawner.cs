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
    [SerializeField] WaveManager waveMgr;
    [SerializeField] GameObject enemyRoot;


    void Awake()
    {
        if (!waveMgr)
            waveMgr = GetComponent<WaveManager>();
    }

    public void SpawnEnemy()
    {
        waveMgr.Data.spawnCoolDown += Time.deltaTime;

        if (waveMgr.Data.Spawned < waveMgr.Data.MaxSpawn)
        {
            if (waveMgr.Data.spawnCoolDown >= 1)
            {
                Instantiate(waveMgr.Data.EnemySO.EnemyPrefab, enemyRoot.transform);
                waveMgr.Data.SpawnCount();
                waveMgr.Data.spawnCoolDown = 0;
            }
        }
        else
            return;
    }

    public void WaveTimer()
    {
        waveMgr.Data.waveTimer += Time.deltaTime;

        if (waveMgr.Data.waveTimer >= waveMgr.Data.WaveDur)
        {
            waveMgr.Data.waveTimer = 0;
            waveMgr.Data.WaveLevelUp();
        }
    }
}