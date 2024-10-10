using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    // クラスの唯一のインスタンスを保持する静的変数
    public static ScoreScript instance;

    // スコアを表示するためのTextコンポーネント
    public GameObject scoreText;
    private int totalScore = 0;

    // Awakeメソッドでインスタンスの初期化を行う
    void Awake()
    {
        // インスタンスが存在しない場合はこのインスタンスを設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでもインスタンスを保持
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は新しいインスタンスを破棄
        }
    }

    // スコアを更新し、Textコンポーネントに反映するメソッド
    public void ScoreManager(int score)
    {
        totalScore += score;
        UpdateScoreText();
    }

    // スコアをTextコンポーネントに表示するメソッド
    private void UpdateScoreText()
    {
        this.scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + totalScore.ToString();
    }

    //トータルのスコア
    public int GetCurrentScore()
    {
        return totalScore;
    }
}
