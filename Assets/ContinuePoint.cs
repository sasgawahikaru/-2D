using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePoint : MonoBehaviour
{
    [Header("�R���e�B�j���[�ԍ�")] public int continueNum;
    [Header("��")] public AudioClip se;
    [Header("�v���C���[����")] public PlayerTriggerCheck trigger;
    [Header("�X�s�[�h")] public float speed = 3.0f;
    [Header("������")] public float moveDis = 3.0f;

    private bool on = false;
    private float kakudo = 0.0f;
    private Vector3 defaultPos;
    void Start()
    {
        //������
        if (trigger == null)
        {
            Debug.Log("�C���X�y�N�^�[�̐ݒ肪����܂���");
            Destroy(this);
        }
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[���͈͓��ɓ�����
        if (trigger.isOn && !on)
        {
            GManager.instance.continueNum = continueNum;
            GManager.instance.PlaySE(se);
            on = true;
        }

        if (on)
        {
            if (kakudo < 180.0f)
            {
                //sin�J�[�u�ŐU��������
                transform.position = defaultPos + Vector3.up * moveDis * Mathf.Sin(kakudo * Mathf.Deg2Rad);

                //�r�����炿�����Ⴍ�Ȃ�
                if (kakudo > 90.0f)
                {
                    transform.localScale = Vector3.one * (1 - ((kakudo - 90.0f) / 90.0f));
                }
                kakudo += 180.0f * Time.deltaTime * speed;
            }
            else
            {
                gameObject.SetActive(false);
                on = false;
            }
        }
    }
}