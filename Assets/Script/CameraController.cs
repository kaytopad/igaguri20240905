using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera effectCamera;
    public float transitionDuration = 4.0f; // 回転全体の時間
    public float zoomRange = 2.0f; // 引きと寄りの距離
    public float rotationAngle = 360f; // 回転角度
    public timerController timerController; // timerControllerの参照
    public Image fadeImage; // フェード用のImage

    public float fadeDuration = 2.0f; // フェードの時間

    private void Start()
    {
        // タイマーを停止して、フェードインを開始
        if (timerController != null)
        {
            timerController.PauseTimer();
        }

        // コルーチンでフェードインとカメラ演出を順番に実行
        StartCoroutine(FadeInAndStartCamera());
    }

    private IEnumerator FadeInAndStartCamera()
    {
        // フェードイン
        yield return StartCoroutine(FadeIn());

        // フェードが完了したらカメラ演出を開始
        StartCoroutine(CameraRotationWithZoom());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        Color color = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            // 透明度を変化させる
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = color;

            elapsedTime += Time.deltaTime;
            yield return null; // フレームごとに更新
        }

        // 最終的に完全に透明に設定
        color.a = 0f;
        fadeImage.color = color;
    }

    private IEnumerator CameraRotationWithZoom()
    {
        // 演出用カメラを有効化してメインカメラを無効化
        mainCamera.enabled = false;
        effectCamera.enabled = true;

        float elapsedTime = 0f;
        Quaternion initialRotation = effectCamera.transform.rotation;
        Quaternion finalRotation = initialRotation * Quaternion.Euler(0, rotationAngle, 0); // 一周回転

        Vector3 initialPosition = effectCamera.transform.position;
        Vector3 centerPosition = initialPosition + effectCamera.transform.forward * zoomRange; // 寄りの位置

        while (elapsedTime < transitionDuration)
        {
            // 回転の補間
            effectCamera.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, elapsedTime / transitionDuration);

            // 引きと寄りの補間
            float zoomFactor = Mathf.Sin((elapsedTime / transitionDuration) * Mathf.PI * 2); // -1から1の範囲で変動
            effectCamera.transform.position = Vector3.Lerp(initialPosition, centerPosition, (zoomFactor + 1) / 2); // 0から1の範囲に正規化

            elapsedTime += Time.deltaTime;
            yield return null; // フレームごとに更新
        }

        // 最終位置と回転を正確に設定
        effectCamera.transform.rotation = finalRotation;
        effectCamera.transform.position = initialPosition;

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
