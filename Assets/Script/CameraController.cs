using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera effectCamera;
    public float transitionDuration = 4.0f; // ��]�S�̂̎���
    public float zoomRange = 2.0f; // �����Ɗ��̋���
    public float rotationAngle = 360f; // ��]�p�x
    public timerController timerController; // timerController�̎Q��
    public Image fadeImage; // �t�F�[�h�p��Image

    public float fadeDuration = 2.0f; // �t�F�[�h�̎���

    private void Start()
    {
        // �^�C�}�[���~���āA�t�F�[�h�C�����J�n
        if (timerController != null)
        {
            timerController.PauseTimer();
        }

        // �R���[�`���Ńt�F�[�h�C���ƃJ�������o�����ԂɎ��s
        StartCoroutine(FadeInAndStartCamera());
    }

    private IEnumerator FadeInAndStartCamera()
    {
        // �t�F�[�h�C��
        yield return StartCoroutine(FadeIn());

        // �t�F�[�h������������J�������o���J�n
        StartCoroutine(CameraRotationWithZoom());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        Color color = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            // �����x��ω�������
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = color;

            elapsedTime += Time.deltaTime;
            yield return null; // �t���[�����ƂɍX�V
        }

        // �ŏI�I�Ɋ��S�ɓ����ɐݒ�
        color.a = 0f;
        fadeImage.color = color;
    }

    private IEnumerator CameraRotationWithZoom()
    {
        // ���o�p�J������L�������ă��C���J�����𖳌���
        mainCamera.enabled = false;
        effectCamera.enabled = true;

        float elapsedTime = 0f;
        Quaternion initialRotation = effectCamera.transform.rotation;
        Quaternion finalRotation = initialRotation * Quaternion.Euler(0, rotationAngle, 0); // �����]

        Vector3 initialPosition = effectCamera.transform.position;
        Vector3 centerPosition = initialPosition + effectCamera.transform.forward * zoomRange; // ���̈ʒu

        while (elapsedTime < transitionDuration)
        {
            // ��]�̕��
            effectCamera.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, elapsedTime / transitionDuration);

            // �����Ɗ��̕��
            float zoomFactor = Mathf.Sin((elapsedTime / transitionDuration) * Mathf.PI * 2); // -1����1�͈̔͂ŕϓ�
            effectCamera.transform.position = Vector3.Lerp(initialPosition, centerPosition, (zoomFactor + 1) / 2); // 0����1�͈̔͂ɐ��K��

            elapsedTime += Time.deltaTime;
            yield return null; // �t���[�����ƂɍX�V
        }

        // �ŏI�ʒu�Ɖ�]�𐳊m�ɐݒ�
        effectCamera.transform.rotation = finalRotation;
        effectCamera.transform.position = initialPosition;

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
