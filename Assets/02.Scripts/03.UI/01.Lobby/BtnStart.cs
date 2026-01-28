using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnStart : MonoBehaviour
{
    [SerializeField] Button btnStart;

    void Awake()
    {
        btnStart = GetComponent<Button>();
    }
    void Start()
    {
        var gameMgr = FindFirstObjectByType<GameManager>();
        btnStart.onClick.AddListener(gameMgr.GameStart);
    }
}
