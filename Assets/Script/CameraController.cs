using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera effectCamera;
    public float transitionDuration = 2.0f;
    public float rotationAngle = 360f; // ��]�p�x
    public timerController timerController; // timerController�̎Q��

    private void Start()
    {
        // ���o�J�n���̓^�C�}�[���~
        if (timerController != null)
        {
            timerController.PauseTimer();
        }

        // �R���[�`���ŃJ�������o���J�n
        StartCoroutine(CameraRotation());
    }

    private IEnumerator CameraRotation()
    {
        // ���o�p�J������L�������ă��C���J�����𖳌���
        mainCamera.enabled = false;
        effectCamera.enabled = true;

        float elapsedTime = 0f;
        Quaternion initialRotation = effectCamera.transform.rotation; // ������]
        Quaternion finalRotation = initialRotation * Quaternion.Euler(rotationAngle, 0, 0); // �ŏI��]

        while (elapsedTime < transitionDuration)
        {
            // ��]�̕��
            effectCamera.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // �t���[�����ƂɍX�V
        }

        // �ŏI�I�ɐ��m�ɏI���ʒu�ɐݒ�
        effectCamera.transform.rotation = finalRotation;

        // ���o�����������烁�C���J�����ɖ߂�
        effectCamera.enabled = false;
        mainCamera.enabled = true;

        // �^�C�}�[���J�n����
        if (timerController != null)
        {
            timerController.StartTimer();
        }
    }
}
