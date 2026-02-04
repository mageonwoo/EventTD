using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] WaveContext waveMgr;
    [SerializeField] int score;
    [SerializeField] int gold;

    void Awake()
    {
        waveMgr = FindFirstObjectByType<WaveContext>();
        score = 0;
    }

    public int CalculateScore()
    {
        score = 100 * (waveMgr.Data.Kill);
        return score;
    }

    public int CalculateGold()
    {
        gold = 10 * (waveMgr.Data.Kill);
        return gold;
    }
}
