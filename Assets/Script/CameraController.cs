using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //各種オブジェクト
    public Camera MainCamera;
    public Camera EffectCamera;
    public float transitionDuration = 2.0f;     //カメラの終了時間
    //カメラの座標
    public Vector3 startPosition = new Vector3 (0, 0, 3);       //カメラのスタート位置
    public Vector3 endPosition = new Vector3(0, 5, -10);           //カメラのエンド位置

    //タイマースクリプトをインスタンス化
    public timerController Timercontroller;

    // Start is called before the first frame update
    void Start()
    {
        if (Timercontroller != null)
        {
            Timercontroller.PausedTimer();
        }
        StartCoroutine(CameraTranstion());
    }

    private IEnumerator CameraTranstion()
    {
        //演出用のカメラの有効化してメインカメラを無効化
        MainCamera.enabled = false;
        EffectCamera.enabled = true;

        //開始時の位置を設定
        EffectCamera.transform.position = startPosition;

        //経過時間
        float elapsedTime = 0f;
        //演出開始（経過時間が終了時間まで）
        while (elapsedTime < transitionDuration) 
        { 
            //Lerap関数で位置を補間して移動
            EffectCamera.transform.position = Vector3.Lerp(startPosition,endPosition,elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            //次のフレームまで待機する
            yield return null;

        }
        //カメラの位置を終了位置に持ってくる
        EffectCamera.transform.position = endPosition;

        //メインカメラを有効化して、演出カメラを無効化
        EffectCamera.enabled=false;
        MainCamera.enabled = true;

        if (Timercontroller != null) 
        {
            //演出が終わったらタイマー開始
            Timercontroller.StartTimer();        
        }
    }
}
