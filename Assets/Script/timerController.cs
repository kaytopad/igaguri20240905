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

    //�^�C�}�[�ꎞ��~�t���O
    private bool isPaused = true;

    // Update is called once per frame
    void Update()
    {
        //�ꎞ��~�Ń^�C�}�[�J�E���g�����s���Ȃ�
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

    //�^�C�}�[���J�n�ɂ���
    public void StartTimer()
    {
        isPaused = false;
    }
    //�^�C�}�[�̈ꎞ��~
    public void PausedTimer()
    {
        isPaused = true;
    }
}
