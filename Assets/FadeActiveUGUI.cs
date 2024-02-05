using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeActiveUGUI : MonoBehaviour
{
    [Header("�t�F�[�h�X�s�[�h")] public float speed = 1.0f;
    [Header("�㏸��")] public float moveDis = 10.0f;
    [Header("�㏸����")] public float moveTime = 1.0f;
    [Header("�L�����o�X�O���[�v")] public CanvasGroup cg;
    [Header("�v���C���[����")] public PlayerTriggerCheck trigger;

    private Vector3 defaltPos;
    private float timer = 0.0f;

    private void Start()
    {
        //������
        if (cg == null && trigger == null)
        {
            Debug.Log("�C���X�y�N�^�[�̐ݒ肪����܂���");
            Destroy(this);
        }
        else
        {
            cg.alpha = 0.0f;
            defaltPos = cg.transform.position;
            cg.transform.position = defaltPos - Vector3.up * moveDis;
        }
    }

    private void Update()
    {
        //�v���C���[���͈͓��ɓ�����
        if (trigger.isOn)
        {
            //�㏸���Ȃ���t�F�[�h�C������
            if (cg.transform.position.y < defaltPos.y || cg.alpha < 1.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position += Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer += speed * Time.deltaTime;
            }
            //�t�F�[�h�C������
            else
            {
                cg.alpha = 1.0f;
                cg.transform.position = defaltPos;
            }
        }
        //�v���C���[���͈͓��ɂ��Ȃ�
        else
        {
            //���~���Ȃ���t�F�[�h�A�E�g����
            if (cg.transform.position.y > defaltPos.y - moveDis || cg.alpha > 0.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position -= Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer -= speed * Time.deltaTime;
            }
            //�t�F�[�h�A�E�g����
            else
            {
                timer = 0.0f;
                cg.alpha = 0.0f;
                cg.transform.position = defaltPos - Vector3.up * moveDis;
            }
        }
    }
}