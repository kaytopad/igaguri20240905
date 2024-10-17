<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //�e��I�u�W�F�N�g
    public Camera MainCamera;
    public Camera EffectCamera;
    public float transitionDuration = 2.0f;     //�J�����̏I������
    //�J�����̍��W
    public Vector3 startPosition = new Vector3 (0, 0, 3);       //�J�����̃X�^�[�g�ʒu
    public Vector3 endPosition = new Vector3(0, 5, -10);           //�J�����̃G���h�ʒu

    //�^�C�}�[�X�N���v�g���C���X�^���X��
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
        //���o�p�̃J�����̗L�������ă��C���J�����𖳌���
        MainCamera.enabled = false;
        EffectCamera.enabled = true;

        //�J�n���̈ʒu��ݒ�
        EffectCamera.transform.position = startPosition;

        //�o�ߎ���
        float elapsedTime = 0f;
        //���o�J�n�i�o�ߎ��Ԃ��I�����Ԃ܂Łj
        while (elapsedTime < transitionDuration) 
        { 
            //Lerap�֐��ňʒu���Ԃ��Ĉړ�
            EffectCamera.transform.position = Vector3.Lerp(startPosition,endPosition,elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            //���̃t���[���܂őҋ@����
            yield return null;

        }
        //�J�����̈ʒu���I���ʒu�Ɏ����Ă���
        EffectCamera.transform.position = endPosition;

        //���C���J������L�������āA���o�J�����𖳌���
        EffectCamera.enabled=false;
        MainCamera.enabled = true;

        if (Timercontroller != null) 
        {
            //���o���I�������^�C�}�[�J�n
            Timercontroller.StartTimer();        
        }
    }
}
=======
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
>>>>>>> 580bfc4d6d17be014a1acf5a8fb6878f1882c3d1
