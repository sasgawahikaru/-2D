using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKinsetu : MonoBehaviour
{
    #region//プライベート変数 
    private Animator anim = null;
    private bool isAttack = false;
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
 //       rb = GetComponent<Rigidbody2D>();
 //       capcol = GetComponent<CapsuleCollider2D>();
 //       sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //if (!isDown)
        //{
        //    //接地判定を得る
        //    isGround = ground.IsGround();
        //    isHead = head.IsGround();

        //    //各種座標軸の速度を求める
        //    float xSpeed = GetXSpeed();
        //    float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
  //          rb.velocity = new Vector2(xSpeed, ySpeed);
 //       }
        //else
        //{
        //    rb.velocity = new Vector2(0, -gravity);
        //}
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("PlayerAttack");
        }
    }
    private void SetAnimation()
    {
        anim.SetBool("Attack", isAttack);
    }
}
