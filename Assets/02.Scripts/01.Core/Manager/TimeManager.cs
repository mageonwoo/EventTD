using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetTimeManager(this);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            AddTimeScale(1);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            AddTimeScale(-1);
        }
    }

    void OnDestroy()
    {
        Debug.Log("[TimeManager] Destroying");
        GameManager.Instance.ClearTimeManager(this);
    }

    public void AddTimeScale(float delta)
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale + delta, 0f, 10f);
        Debug.Log($"TimeScale = {Time.timeScale}");
    }

    public void PauseTimeScale()
    {
        Time.timeScale = 0;
        Debug.Log($"TimeScale = {Time.timeScale} Pause Success");
    }

    public void GameRestart()
    {
        Time.timeScale = 1;
        Debug.Log($"TimeScale = {Time.timeScale} Restart Success");
    }
}