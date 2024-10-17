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
    public timerController timerController; // timerControllerの参照を追加

    private void Start()
    {
        // 演出開始時はタイマーを停止しておく
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

        // 演出が終わった後にタイマーを開始する
        if (timerController != null)
        {
            timerController.StartTimer();
        }
    }

}
