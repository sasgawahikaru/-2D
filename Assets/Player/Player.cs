using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject tama;
    public GameObject player;
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�ړ����x")] public float speed;
    [Header("�d��")] public float gravity;
    [Header("�W�����v���x")] public float jumpSpeed;
    [Header("�W�����v���鍂��")] public float jumpHeight;
    [Header("�W�����v���钷��")] public float jumpLimitTime;
    [Header("�ڒn����")] public GroundCheck ground;
    [Header("�V�䔻��")] public GroundCheck head;
    [Header("�_�b�V���̑����\��")] public AnimationCurve dashCurve;
    [Header("�W�����v�̑����\��")] public AnimationCurve jumpCurve;
    [Header("���݂�����̍����̊���(%)")] public float stepOnRate;
    #endregion

    #region//�v���C�x�[�g�ϐ� 
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    //   private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private bool isClearMotion = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string TamaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";

    public AudioClip se;
    #endregion

    void Start()
    {
        //�R���|�[�l���g�̃C���X�^���X��߂܂���
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //���Ł@���Ă��鎞�ɖ߂�
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //���Ł@�����Ă���Ƃ�
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //���Ł@���Ă���Ƃ�
            else
            {
                sr.enabled = true;
            }
            //1�b�������疾�ŏI���
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
        if (isDown == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.Play("PlayerAttack");
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDown)
        {
            //�ڒn����𓾂�
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //�e����W���̑��x�����߂�
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //�A�j���[�V������K�p
            SetAnimation();

            //�ړ����x��ݒ�
            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
        //�V���b�g
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    //�v���n�u����
        //    GameObject playerShot = Instantiate(tama) as GameObject;
        //    playerShot.transform.position = this.transform.position;
        //}
    }

    /// <summary> 
    /// Y�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B 
    /// </summary> 
    /// <returns>Y���̑���</returns> 
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //�����𓥂񂾍ۂ̃W�����v
        if (isOtherJump)
        {
            //���݂̍�������ׂ鍂����艺��
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //�W�����v���Ԃ������Ȃ肷���ĂȂ���
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //�n�ʂɂ���Ƃ�
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //�W�����v�����ʒu���L�^����
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //�W�����v��
        else if (isJump)
        {
            //������L�[�������Ă��邩
            bool pushUpKey = verticalKey > 0;
            //���݂̍�������ׂ鍂����艺��
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //�W�����v���Ԃ������Ȃ肷���ĂȂ���
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }

    /// <summary> 
    /// X�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B 
    /// </summary> 
    /// <returns>X���̑���</returns> 
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //�O��̓��͂���_�b�V���̔��]�𔻒f���đ��x��ς���
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        beforeKey = horizontalKey;
        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary> 
    /// �A�j���[�V������ݒ肷�� 
    /// </summary> 
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary> 
    �@�@/// �R���e�B�j���[�ҋ@��Ԃ� 
    /// </summary> 
    /// <returns></returns> 
    public bool IsContinueWaiting()
    {
        return IsDownAnimEnd();
    }

    //�_�E���A�j���[�V�������������Ă��邩�ǂ��� 
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void ContinuePlayer()
    {
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //���ꂽ���̏���
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                AudioSource.PlayClipAtPoint(se, transform.position);
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.SubHeartNum();
        }
    }

    #region//�ڐG����
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == TamaTag)
        {

                ReceiveDamage(true); //New!
  
        }

        if (collision.collider.tag == enemyTag)
        {
            //���݂�����ɂȂ鍂��
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));
            //���݂�����̃��[���h���W
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                    if (o != null)
                    {
                        otherJumpHeight = o.boundHeight;    //����Â������̂��璵�˂鍂�����擾����
                        o.playerStepOn = true;        //����Â������̂ɑ΂��ē���Â�������ʒm����
                        jumpPos = transform.position.y; //�W�����v�����ʒu���L�^���� 
                        isOtherJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("ObjectCollision���t���ĂȂ���!");
                    }
                }
                //else
                //{
                //    anim.Play("player_down");
                //    isDown = true;
                //    break;
                //}

                else
                {
                    ReceiveDamage(true); //New!
                    break;
                }
            }
        }
    }
    #endregion
}