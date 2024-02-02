using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attackkopi : MonoBehaviour
{

    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�ړ����x")] public float speedEnemy;
    [Header("�d��")] public float gravity;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
    [Header("�ڐG����")] public EnemyCollisionCheck checkCollision;
    #endregion

    #region//�v���C�x�[�g�ϐ�
    //    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    #endregion


    [Header("�X�s�[�h")] public float speed = 3.0f;
    [Header("�ő�ړ�����")] public float maxDistance = 100.0f;
    private Rigidbody2D rb;
    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();
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
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisibleAct)
            {
                if (checkCollision.isOn)
                {
                    rightTleftF = !rightTleftF;
                }
                int xVector = -1;
                if (rightTleftF)
                {
                    xVector = 1;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                rb.velocity = new Vector2(xVector * speedEnemy, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            if (!isDead)
            {
                anim.Play("Enemydead");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                Destroy(gameObject, 3f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
            }
        }
        //�ő�ړ������𒴂��Ă���
        if (d > maxDistance)
        {
            Destroy(this.gameObject);
        }
        if (d > 1)
        {
            rb.MovePosition(transform.position += -transform.right * Time.deltaTime * speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}