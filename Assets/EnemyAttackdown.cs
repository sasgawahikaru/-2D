using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackdown : MonoBehaviour
{
    [Header("�X�s�[�h")] public float speed = 3.0f;
    [Header("�ő�ړ�����")] public float maxDistance = 100.0f;
    [Header("�U���I�u�W�F�N�g")] public GameObject attackObj;

    private Rigidbody2D rb = null;
    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("�ݒ肪����܂���");
            Destroy(this.gameObject);
        }
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float d = Vector3.Distance(transform.position, defaultPos);

        //�ő�ړ������𒴂��Ă���
        if (d > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            rb.MovePosition(transform.position += -transform.up * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}