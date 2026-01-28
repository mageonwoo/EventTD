using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] WaveManager waveMgr;

    [SerializeField] TMP_Text userId;
    [SerializeField] TMP_Text waveIdx;
    [SerializeField] TMP_Text aliveCount;
    [SerializeField] TMP_Text waveRemainedT;

    void Awake()
    {
        if (!waveMgr) waveMgr = FindFirstObjectByType<WaveManager>();
    }

    void Update()
    {
        BriefUserID();
        BriefWaveIdx();
        BriefAlive();
        BriefTime();
    }
    
    void BriefUserID()
    {
        string id = GameManager.Instance.UserId;

        if(id == null)
            userId.text = "Guest";
        else
            userId.text = $"UID: {id}";
    }

    void BriefWaveIdx()
    {
        if (waveMgr.Data.WaveIdx > 2)
            waveIdx.text = $"Wave: 3 / 3";
        else
            waveIdx.text = $"Wave: {waveMgr.Data.WaveIdx + 1} / 3";
    }

    void BriefAlive()
    {
        aliveCount.text = $"Enemy: {waveMgr.Data.Alive} / 20";
    }

    void BriefTime()
    {
        var time = waveMgr.Data.WaveDur - waveMgr.Data.waveTimer;

        int sec = Mathf.CeilToInt(time);
        
        if (sec > 0)
            waveRemainedT.text = $"Time: {sec}s / 30s";
            else
            waveRemainedT.text = "Time: 0s / 30s";
    }
}
