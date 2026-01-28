using UnityEngine;
/// <summary>
/// 1. 게임 시작 신호를 받고, 시작 카운트다운이 끝나면 웨이브 시작 신호를 스포너에 전달
/// 2. waveDuration이 끝나면 새로운 웨이브 시작 신호를 스포너에 전달
/// 3. 적 개체가 스폰되면, AliveCount를 증가시킴
/// 4. 적 개체의 Life가 0이 되면 AliveCount를 감소시킴
/// 5. 웨이브가 3단계가 끝날 때까지 게임오버 조건이 되지 않으면 게임 클리어 신호를 전달
/// 6. 웨이브가 3단계가 끝나기 전 어떤 시점에서든 AliveCount가 max수치를 초과해 과부하 조건을 충족하면 게임 오버 신호를 전달
/// </summary>
public class WaveManager : MonoBehaviour
{
    GameManager gameMgr;
    [SerializeField] GameClock gameClock;
    [SerializeField] WaveData waveData;
    public WaveData Data => waveData;
    [SerializeField] WaveSpawner waveSpawner;

    void Start()
    {
        gameMgr = GameManager.Instance;
        gameClock = gameMgr.gameClock;
    }
    void Update()
    {
        if (gameClock.WaveStart() == true && gameMgr.State == GameState.Runtime)
        {
            waveSpawner.WaveTimer(); // 웨이브 시간 오버되면 초기화하고 웨이브 인덱스++
            waveSpawner.SpawnEnemy();
        }

        // 적이 죽으면, aliveCount--;

        if (Data.Alive > waveData.LimitCount && gameMgr.State == GameState.Runtime)
        {
            Debug.Log("Game Over");
            GameOver();
        }
        else if (waveData.WaveIdx >= 3 && gameMgr.State == GameState.Runtime)
        {
            Debug.Log("Game Clear");
            GameClear();
        }
    }

    public void ReportEnemyDead()
    {
        Data.EnemyKill();
    }

    void GameClear()
    {
        gameMgr.CallGameClear();
        gameMgr.Pause();

        var sceneMgr = FindFirstObjectByType<SceneFlowManager>();
        sceneMgr.LoadToResult();
    }

    void GameOver()
    {
        gameMgr.CallGameOver();
        gameMgr.Pause();

        var sceneMgr = FindFirstObjectByType<SceneFlowManager>();
        sceneMgr.LoadToResult();
    }
}