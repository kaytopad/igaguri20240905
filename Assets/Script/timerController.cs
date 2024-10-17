using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerController : MonoBehaviour
{
    public GameObject timeText;
    public string nextSceneName;
    public float transitionTime = 10f;

    private float elapsedTime = 0f;

    //タイマー一時停止フラグ
    private bool isPaused = true;

    // Update is called once per frame
    void Update()
    {
        //一時停止でタイマーカウントを実行しない
        if (isPaused)
        {
            return;
        }
        elapsedTime += Time.deltaTime;

        UpdatetimeText();

        if (elapsedTime >= transitionTime)
        {
            GameManager.Instance.EndGame();
        }

    }

    private void UpdatetimeText()
    {
        this.timeText.GetComponent<TextMeshProUGUI>().text = "Time:" + elapsedTime.ToString("F2") + " Sec";
    }

    //タイマーを開始にする
    public void StartTimer()
    {
        isPaused = false;
    }
    //タイマーの一時停止
    public void PausedTimer()
    {
        isPaused = true;
    }
}
