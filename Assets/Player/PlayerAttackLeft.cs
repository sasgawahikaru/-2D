using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttackLeft : MonoBehaviour
{
    [Header("�X�s�[�h")] public float speed = 3.0f;
    [Header("�ő�ړ�����")] public float maxDistance = 100.0f;
    [Header("�U���I�u�W�F�N�g")] public GameObject attackObj;

    [Header("�d��")] public float gravity;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
    [Header("�ڐG����")] public EnemyCollisionCheck checkCollision;

    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    private Vector3 defaultPos;

    private string TamaTag2 = "HitArea2";
    private string enemyTag = "Enemy";
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
            rb.MovePosition(transform.position += transform.right * Time.deltaTime * speed);
        }
            //anim.Play("Enemydead");
            //anim.Play("enemy2dead");
            //rb.velocity = new Vector2(0, -gravity);
            //isDead = true;
            //col.enabled = false;
            //Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //if (enemyTag == TamaTag2)
        //{
        //    anim.Play("Enemydead");
        //    anim.Play("enemy2dead");
        //    rb.velocity = new Vector2(0, -gravity);
        //    isDead = true;
        //    col.enabled = false;
        //    Destroy(gameObject, 3f);
        //}
    }
}