using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera effectCamera;
    public float transitionDuration = 2.0f;
    public Vector3 startPosition = new Vector3(0, 1, -10);
    public Vector3 endPosition = new Vector3(0, 5, -10);
    public timerController timerController; // timerController�̎Q�Ƃ�ǉ�

    private void Start()
    {
        // ���o�J�n���̓^�C�}�[���~���Ă���
        if (timerController != null)
        {
            timerController.PauseTimer();
        }

        StartCoroutine(CameraTransition());
    }

    private IEnumerator CameraTransition()
    {
        mainCamera.enabled = false;
        effectCamera.enabled = true;

        effectCamera.transform.position = startPosition;

        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            effectCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        effectCamera.transform.position = endPosition;

        effectCamera.enabled = false;
        mainCamera.enabled = true;

        // ���o���I�������Ƀ^�C�}�[���J�n����
        if (timerController != null)
        {
            timerController.StartTimer();
        }
    }

}
