[WaveManager.cs]
void MoveToNextPoint(int routeIdx)
{
    switch (routeIdx)
    {
        case 0:
            routeIdx = 1;
            break;
            case 1:
            routeIdx = 2;
            break;
            case 2:
                routeIdx = 3;
            break;
            case 3:
            routeIdx = 0;
            break;
        default:
                routeIdx = 0;
                break;
    }
}

[WaveManager.cs]
스폰 규칙과 신호를 전부 한 곳에서 하는 하드코딩.
추후 OOP로 분해하면서 레거시 코드로 기록을 남기기 위함

using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] EnemyTypeSO enemy;
    [SerializeField] GameObject enemyRoute;
    [SerializeField] int maxEnemyCount = 20;
    [SerializeField] int aliveCount = 0;
    [SerializeField] int spawnCount = 15;
    [SerializeField] float spawnDelay;
    [SerializeField] float coolDown;

    [SerializeField] Transform spawnPos;
    [SerializeField] GameClock gameClock;

    void Start()
    {
        gameClock = FindFirstObjectByType<GameClock>();
    }
    void Update()
    {
        if (gameClock.WaveStart() && GameManager.Instance.State == GameState.Runtime)
            SpawnEnemy();
    }

    void SpawnEnemy()
    {
        spawnDelay += Time.deltaTime;
        coolDown += Time.deltaTime;

        if (coolDown <= spawnCount)
        {
            if (spawnDelay >= 1)
            {
                Instantiate(enemy.Enemy, enemyRoute.transform);
                aliveCount++;
                spawnDelay = 0;
            }
        }
        else if (coolDown > 15 && coolDown < 30)
            return;
        else
            coolDown = 0;

        if (aliveCount > maxEnemyCount)
        {
            Debug.Log("Game Over");
            GameOver();
        }

    }
    // void GameClear()
    // {
    //     GameManager.Instance.CallGameClear();
    //     GameManager.Instance.Pause();
    //     var sceneMgr = FindFirstObjectByType<SceneFlowManager>();
    //     sceneMgr.LoadToResult();
    // }
    void GameOver()
    {
        GameManager.Instance.CallGameOver();
        GameManager.Instance.Pause();

        var sceneMgr = FindFirstObjectByType<SceneFlowManager>();
        sceneMgr.LoadToResult();
    }
}
