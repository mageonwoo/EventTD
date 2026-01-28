using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    public static SceneFlowManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void OnClickToLobby()
    {
        GameManager.Instance.CallGameTitle();
        SceneManager.LoadScene("evtLobby");
    }

    public void OnClickToGame()
    {
        SceneManager.LoadScene("evtGame");
    }

    public void LoadToResult()
    {
        SceneManager.LoadScene("evtResult", LoadSceneMode.Additive);
    }
}