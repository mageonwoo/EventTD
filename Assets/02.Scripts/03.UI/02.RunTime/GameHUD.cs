using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// 1순위(완료). HUD를 로직에서 분리, 데이터 읽기 전용으로 정리
/// 2순위. 실시간 주기 갱신, 이벤트성 변경 시점 갱신으로 분리
/// </summary>
public class GameHUD : MonoBehaviour
{
    [SerializeField] WaveContext waveMgr;

    [SerializeField] TMP_Text userId;
    [SerializeField] TMP_Text waveIdx;
    [SerializeField] TMP_Text aliveCount;
    [SerializeField] TMP_Text waveRemainedT;

    void Awake()
    {
        if (!waveMgr) waveMgr = FindFirstObjectByType<WaveContext>();
    }

    void Start()
    {
        BriefUserID();
    }

    void Update()
    {
        BriefWaveIdx();
        BriefAlive();
        BriefTime();
    }

    void BriefUserID()
    {
        string id = GameManager.Instance.UserId;

        if (string.IsNullOrEmpty(id))
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
