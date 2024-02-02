using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    private string TamaTag2 = "HitArea2";
    private string TamaTag3 = "HitArea3";
    private string enemyTag = "Enemy";
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
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
                rb.velocity = new Vector2(xVector * speed, -gravity);
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
                anim.Play("enemy2dead");
                anim.Play("enemy3dead");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                Destroy(gameObject, 0.1f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == TamaTag3)
        {
            anim.Play("Enemydead");
            anim.Play("enemy2dead");
            anim.Play("enemy3dead");

            rb.velocity = new Vector2(0, -gravity);
            isDead = true;
            col.enabled = false;
            Destroy(gameObject, 0.1f);
        }

    }
}