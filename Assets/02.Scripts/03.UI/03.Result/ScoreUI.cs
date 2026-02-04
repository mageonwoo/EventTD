using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] GameManager gameMgr;
    [SerializeField] WaveContext waveMgr;
    [SerializeField] ScoreCalculator scoreCalc;

    [SerializeField] Image scoreScreen;
    [SerializeField] TMP_Text userId;
    [SerializeField] TMP_Text waveIdx;
    [SerializeField] TMP_Text killCount;
    [SerializeField] TMP_Text aliveCount;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text gold;

    [SerializeField] Image loserScreen;

    void Awake()
    {
        gameMgr = FindFirstObjectByType<GameManager>();
        waveMgr = FindFirstObjectByType<WaveContext>();
        scoreCalc = GetComponent<ScoreCalculator>();
    }
    void Start()
    {
        if (GameManager.Instance.State == GameState.Clear)
        {
            scoreScreen.gameObject.SetActive(true);
            loserScreen.gameObject.SetActive(false);
            
            PrintAll();
        }
        else if (GameManager.Instance.State == GameState.Over)
        {
            scoreScreen.gameObject.SetActive(false);
            loserScreen.gameObject.SetActive(true);
        }
    }

    void PrintAll()
    {
        Debug.Log("Update Score");
        PrintUserID();
        PrintWaveIdx();
        PrintAlive();
        PrintKilled();
        PrintScore();
        PrintGold();
    }

    void PrintUserID()
    {
        userId.text = $"{gameMgr.UserId}";
    }

    void PrintWaveIdx()
    {
        waveIdx.text = $"{waveMgr.Data.WaveIdx}";
    }

    void PrintAlive()
    {
        aliveCount.text = $"{waveMgr.Data.Alive}";
    }

    void PrintKilled()
    {
        killCount.text = $"{waveMgr.Data.Kill}";
    }

    void PrintScore()
    {
        //스코어계산기로 가져온다.
        score.text = $"{scoreCalc.CalculateScore()}";
    }

    void PrintGold()
    {
        gold.text = $"{scoreCalc.CalculateGold()}";
    }
}
