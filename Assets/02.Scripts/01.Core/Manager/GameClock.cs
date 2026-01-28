using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    [SerializeField] float startCountDown = 3.0f;
    [SerializeField] bool isCounting = true;
    [SerializeField] bool isRemaining = false; //웨이브 남은 시간 (지울 가능성 높음)
    [SerializeField] bool waveStart = false;

    void Awake()
    {
        GameManager.Instance.SetGameClock(this);
    }
    void Update()
    {
        // Debug.Log($"Clock Updating");
        if (!isCounting) return;//게임 시작 전 카운트다운

        if (true)
        {
            startCountDown -= Time.deltaTime;
        }

        if (startCountDown < -1f)
            isCounting = false;

    }

    void OnDestroy()
    {
        // Debug.Log("[GameClock] Destroying");
        GameManager.Instance.ClearGameClock(this);
    }

    public string GetCountDownText()
    {
        int sec = Mathf.CeilToInt(startCountDown);
        // Debug.Log($"{sec}start message");

        if (sec > 0)
            return sec.ToString();
        if (sec == 0)
        {
            waveStart = true;
            return "Start!";
        }

        return null;
    }

    public bool IsCountDownVisible()
    {
        return startCountDown >= -1;
    }

    public bool WaveStart()
    {
        return waveStart;
    }
}
