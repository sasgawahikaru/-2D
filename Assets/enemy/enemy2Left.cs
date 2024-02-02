using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Left: MonoBehaviour
{
    [Header("�U���I�u�W�F�N�g")] public GameObject attackObj;
    [Header("�U���Ԋu")] public float interval;

private Animator anim;
private float timer;

// Start is called before the first frame update
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
    if (currentState.IsName("idle"))
    {
        if (timer > interval)
        {
            anim.SetTrigger("attack");
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
public void Attack()
{
    GameObject g = Instantiate(attackObj);
    g.transform.SetParent(transform);
    g.transform.position = attackObj.transform.position;
    g.transform.rotation = attackObj.transform.rotation;
    g.SetActive(true);
}
    //public void Attack()
    //{
    //    Debug.Log("�U��");
    //}
}