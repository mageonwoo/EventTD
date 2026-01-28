using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 매니저에서 상태를 관리하고 씬과 대응하게 한다.
/// </summary>
public enum GameState { Title, Runtime, Clear, Over }
public class GameManager : MonoBehaviour
{
    [SerializeField] GameState gameState = GameState.Title;
    public GameState State => gameState;

    public static GameManager Instance;

    [SerializeField] const int maxCost = 3;
    public int MaxCost => maxCost;
    [SerializeField] int curCost;
    public int CurCost => curCost;
    [SerializeField] bool firstTry = false;
    [SerializeField] TimeManager timeManager;
    [SerializeField] public GameClock gameClock;
    [SerializeField] string userIdValue;
    public string UserId => userIdValue;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitFirstCost();
    }
    void InitFirstCost()
    {
        if (!firstTry)
        {
            Debug.Log("코스트 초기화");
            curCost = maxCost;
            firstTry = true;
        }
    }

    public void SetTimeManager(TimeManager tm)
    {
        timeManager = tm;
    }

    public void ClearTimeManager(TimeManager tm)
    {
        if (timeManager == tm)
            timeManager = null;
    }

    public void SetGameClock(GameClock gc)
    {
        gameClock = gc;
    }

    public void ClearGameClock(GameClock gc)
    {
        if (gameClock == gc)
            gameClock = null;
    }

    public void ConfirmID(string id)
    {
        userIdValue = id;
    }

    public void GameStart()
    {
        if (curCost <= 0) return;

        PayCost();
        CallGameStart();

        var scene = FindFirstObjectByType<SceneFlowManager>();
        scene.OnClickToGame();

    }

    public void CallGameTitle()
    {
        Debug.Log($"{gameState} Changing");
        gameState = GameState.Title;
        timeManager.GameRestart();
        Debug.Log($"Called {gameState}");
    }

    public void CallGameStart()
    {
        Debug.Log($"{gameState} Changing");
        gameState = GameState.Runtime;
        Debug.Log($"Called {gameState}");
    }

    public void CallGameClear()
    {
        Debug.Log($"{gameState} Changing");
        gameState = GameState.Clear;
        Debug.Log($"Called {gameState}");
    }

    public void CallGameOver()
    {
        Debug.Log($"{gameState} Changing");
        gameState = GameState.Over;
        Debug.Log($"Called {gameState}");
    }

    public void Pause()
    {
        timeManager.PauseTimeScale();
    }

    public void Restart()
    {
        timeManager.GameRestart();
    }

    // 이벤트 처리를 하는 것은 지금 단계에서 굉장히 비효율적이고 오만한 판단이다.
    void PayCost()
    {
        curCost--;
    }

}
