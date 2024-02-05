using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttackLeft : MonoBehaviour
{
    [Header("スピード")] public float speed = 3.0f;
    [Header("最大移動距離")] public float maxDistance = 100.0f;
    [Header("攻撃オブジェクト")] public GameObject attackObj;

    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;

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
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float d = Vector3.Distance(transform.position, defaultPos);

        //最大移動距離を超えている
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