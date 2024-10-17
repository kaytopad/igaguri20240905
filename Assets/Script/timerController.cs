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
    private bool isPaused = true; // �^�C�}�[�̏�����Ԃ��~�ɐݒ�

    //�^�C�}�[�ꎞ��~�t���O
    private bool isPaused = true;

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        //�ꎞ��~�Ń^�C�}�[�J�E���g�����s���Ȃ�
        if (isPaused)
        {
            return;
        }
=======
        if (isPaused)
        {
            // �^�C�}�[���ꎞ��~���Ȃ�A�������s��Ȃ�
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

    // �^�C�}�[���J�n���郁�\�b�h
    public void StartTimer()
    {
        isPaused = false; // �^�C�}�[���J�n����
    }

    // �^�C�}�[���~���郁�\�b�h
    public void PauseTimer()
    {
        isPaused = true; // �^�C�}�[���~����
    }

    // �^�C�}�[�����Z�b�g���郁�\�b�h
    public void ResetTimer()
    {
        elapsedTime = 0f; // �o�ߎ��Ԃ����Z�b�g
        UpdatetimeText(); // �e�L�X�g���X�V����
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
