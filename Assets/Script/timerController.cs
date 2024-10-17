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
    private bool isPaused = true; // タイマーの初期状態を停止に設定

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            // タイマーが一時停止中なら、処理を行わない
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
        this.timeText.GetComponent<TextMeshProUGUI>().text = "Time: " + elapsedTime.ToString("F2") + " Sec";
    }

    // タイマーを開始するメソッド
    public void StartTimer()
    {
        isPaused = false; // タイマーを開始する
    }

    // タイマーを停止するメソッド
    public void PauseTimer()
    {
        isPaused = true; // タイマーを停止する
    }

    // タイマーをリセットするメソッド
    public void ResetTimer()
    {
        elapsedTime = 0f; // 経過時間をリセット
        UpdatetimeText(); // テキストも更新する
    }
}
