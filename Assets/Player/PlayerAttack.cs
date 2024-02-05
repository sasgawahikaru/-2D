using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("�U���I�u�W�F�N�g")] public GameObject attackObj;

    [Header("�ړ����x")] public float speed;
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

    private bool isAttack = false;

    private string TamaTag2 = "HitArea2";
    int AttackCoolTime = 0;
    //    private float timer;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (!isAttack)
        {
            //�ڒn����𓾂�
            //isGround = ground.IsGround();
            //isHead = head.IsGround();

            ////�e����W���̑��x�����߂�
            //float xSpeed = GetXSpeed();
            //float ySpeed = GetYSpeed();

            //�A�j���[�V������K�p
            SetAnimation();
            if (AttackCoolTime == 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    GameObject g = Instantiate(attackObj);
                    g.transform.SetParent(transform);
                    g.transform.position = attackObj.transform.position;
                    g.transform.rotation = attackObj.transform.rotation;
                    g.SetActive(true);
                    AttackCoolTime = 10;
                }
            }
                //�ړ����x��ݒ�
            //    rb.velocity = new Vector2(xSpeed, ySpeed);
            //}
            //else
            //{
            //    rb.velocity = new Vector2(0, -gravity);
        }
        if (!isDead)
        {
            anim.Play("Enemydead");
            anim.Play("enemy2dead");
            rb.velocity = new Vector2(0, -gravity);
            isDead = true;
            col.enabled = false;
            Destroy(gameObject, 3f);
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null || attackObj == null)
        {
            Debug.Log("�ݒ肪����܂���");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

        //�ʏ�̏��
        //        if (currentState.IsName("idle"))
        //        {
        //            //if (timer > interval)
        //            //{
        //            //    anim.SetTrigger("attack");
        //            //    timer = 0.0f;
        //            //}
        //            //else
        //            //{
        //                timer += Time.deltaTime;
        ////            }
        //        }
        if (AttackCoolTime > 0)
        {
            AttackCoolTime--;
        }
    } 
    private void SetAnimation()
    {
       anim.SetBool("Attack", isAttack);
    }
    public void Attack()
    {
        //if (collision.collider.tag == TamaTag)
        //{
        //    anim.Play("Player_down");
        //    isDown = true;
        ////}
        //if (Input.GetKey(KeyCode.Space))
        //{
        //anim.Play("PlayerAttack");
        //isAttack = false;
        //       if (Input.GetKey(KeyCode.Z))
        //       {
        ////           isAttack = true;
        //           anim.Play("PlayerAttack");
        //           GameObject g = Instantiate(attackObj);
        //           g.transform.SetParent(transform);
        //           g.transform.position = attackObj.transform.position;
        //           g.transform.rotation = attackObj.transform.rotation;
        //           g.SetActive(true);
  //             }
    }
    //public void Attack()
    //{
    //    Debug.Log("�U��");
    //}
}