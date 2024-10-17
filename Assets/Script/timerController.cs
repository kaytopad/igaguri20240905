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

    //タイマー一時停止フラグ
    private bool isPaused = true;

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        //一時停止でタイマーカウントを実行しない
        if (isPaused)
        {
            return;
        }
=======
        if (isPaused)
        {
            // タイマーが一時停止中なら、処理を行わない
            return;
        }

>>>>>>> 580bfc4d6d17be014a1acf5a8fb6878f1882c3d1
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
