using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

/// <summary>
/// 1. 이벤트 게임 도전 횟수 코스트 차감. → evtLobby
/// </summary>
public class CostPrint : MonoBehaviour
{
    [SerializeField] GameManager gameMgr;
    [SerializeField] int maxCost;
    [SerializeField] int curCost;
    [SerializeField] public TMP_Text costText;

    void Start()
    {
        gameMgr = FindFirstObjectByType<GameManager>();

        maxCost = gameMgr.MaxCost;
        curCost = gameMgr.CurCost;
        TextPlayerCost();
    }
    public void TextPlayerCost()
    {
        costText.text = $"Cost: {curCost} / {maxCost}";
    }
}