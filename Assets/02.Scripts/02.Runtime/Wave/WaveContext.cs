using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1. 게임 시작 신호를 받고, 시작 카운트다운이 끝나면 웨이브 시작 신호를 스포너에 전달
/// 2. waveDuration이 끝나면 새로운 웨이브 시작 신호를 스포너에 전달
/// 3. 적 개체가 스폰되면, AliveCount를 증가시킴
/// 4. 적 개체의 Life가 0이 되면 AliveCount를 감소시킴
/// 5. 웨이브가 3단계가 끝날 때까지 게임오버 조건이 되지 않으면 게임 클리어 신호를 전달
/// 6. 웨이브가 3단계가 끝나기 전 어떤 시점에서든 AliveCount가 max수치를 초과해 과부하 조건을 충족하면 게임 오버 신호를 전달
/// </summary>
public class WaveContext : MonoBehaviour
{
    // 게임 매니저
    GameManager gameMgr;
    [SerializeField] GameClock gameClock;
    // 웨이브 관련
    [SerializeField] WaveDataSO waveData;
    public WaveDataSO Data => waveData;
    [SerializeField] EnemyPool enemyPool;
    public EnemyPool EnemyPool => enemyPool;
    public Transform[] enemyRoute;
    [SerializeField] WaveSpawner waveSpawner;
    List<EnemyContext> EnemyReg = new List<EnemyContext>();

    void Awake()
    {
        gameMgr = GameManager.Instance;
        gameClock = gameMgr.gameClock;
    }

    void OnEnable()
    {
        Data.Init();
    }

    void Start()
    {
        TakeRoute();
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
        else if (waveData.WaveIdx >= waveData.MaxWaveIdx && gameMgr.State == GameState.Runtime)
        {
            Debug.Log("Game Clear");
            GameClear();
        }
    }

    void TakeRoute()
    {
        var r = GameObject.FindWithTag("Route");
        var all = r.GetComponentsInChildren<Transform>();

        enemyRoute = new Transform[all.Length - 1];
        for (int i = 1; i < all.Length; ++i)
        {
            enemyRoute[i - 1] = all[i];
        }
    }

    public void CallUpEnemy()
    {
        if (Data.WaveIdx < Data.MaxWaveIdx)
        {
            var go = EnemyPool.Get(Data.WaveIdx);
            var ctx = go.GetComponent<EnemyContext>();

            EnemyReg.Add(ctx);
            ctx.enemyMove.InitRoute(enemyRoute);
        }
    }

    public void RemoveEnemy(EnemyContext ctx)
    {
        if (EnemyReg.Contains(ctx))
            EnemyReg.Remove(ctx);

        Data.EnemyKill();

        EnemyPool.Return(ctx.gameObject);
    }

    public void ClearReg()
    {
        EnemyReg.Clear();
    }

    public void LevelUp()
    {
        Data.LevelUpAndReset();
    }

    void GameClear()
    {
        gameMgr.CallGameClear();
        gameMgr.Pause();
        ClearReg();

        var sceneMgr = FindFirstObjectByType<SceneFlowManager>();
        sceneMgr.LoadToResult();
    }

    void GameOver()
    {
        gameMgr.CallGameOver();
        gameMgr.Pause();
        ClearReg();

        var sceneMgr = FindFirstObjectByType<SceneFlowManager>();
        sceneMgr.LoadToResult();
    }
}