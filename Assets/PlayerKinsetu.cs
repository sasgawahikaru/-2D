using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKinsetu : MonoBehaviour
{
    #region//�v���C�x�[�g�ϐ� 
    private Animator anim = null;
    private bool isAttack = false;
    #endregion

    void Start()
    {
        //�R���|�[�l���g�̃C���X�^���X��߂܂���
        anim = GetComponent<Animator>();
 //       rb = GetComponent<Rigidbody2D>();
 //       capcol = GetComponent<CapsuleCollider2D>();
 //       sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //if (!isDown)
        //{
        //    //�ڒn����𓾂�
        //    isGround = ground.IsGround();
        //    isHead = head.IsGround();

        //    //�e����W���̑��x�����߂�
        //    float xSpeed = GetXSpeed();
        //    float ySpeed = GetYSpeed();

            //�A�j���[�V������K�p
            SetAnimation();

            //�ړ����x��ݒ�
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
