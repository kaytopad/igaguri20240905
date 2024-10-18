using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera effectCamera;
    public float transitionDuration = 2.0f;
    public float rotationAngle = 360f; // 回転角度
    public timerController timerController; // timerControllerの参照

    private void Start()
    {
        // 演出開始時はタイマーを停止
        if (timerController != null)
        {
            timerController.PauseTimer();
        }

        // コルーチンでカメラ演出を開始
        StartCoroutine(CameraRotation());
    }

    private IEnumerator CameraRotation()
    {
        // 演出用カメラを有効化してメインカメラを無効化
        mainCamera.enabled = false;
        effectCamera.enabled = true;

        float elapsedTime = 0f;
        Quaternion initialRotation = effectCamera.transform.rotation; // 初期回転
        Quaternion finalRotation = initialRotation * Quaternion.Euler(rotationAngle, 0, 0); // 最終回転

        while (elapsedTime < transitionDuration)
        {
            // 回転の補間
            effectCamera.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // フレームごとに更新
        }

        // 最終的に正確に終了位置に設定
        effectCamera.transform.rotation = finalRotation;

        // 演出が完了したらメインカメラに戻す
        effectCamera.enabled = false;
        mainCamera.enabled = true;

        // タイマーを開始する
        if (timerController != null)
        {
            timerController.StartTimer();
        }
    }
}
