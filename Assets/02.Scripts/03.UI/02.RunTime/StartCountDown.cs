using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCountDown : MonoBehaviour
{
    [SerializeField] GameClock gameClock;
    [SerializeField] TMP_Text startCounting;
    //TMP_Text remainedToNextWave;
    // Start is called before the first frame update
    void Start()
    {
        gameClock = GameManager.Instance.gameClock;
    }

    // Update is called once per frame
    void Update()
    {
        bool visible = gameClock.IsCountDownVisible();
        startCounting.gameObject.SetActive(visible);

        if (!visible) return;
        startCounting.text = gameClock.GetCountDownText();
    }
}
