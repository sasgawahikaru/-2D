using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour
{
    [Header("�v���C���[�Q�[���I�u�W�F�N�g")] public GameObject playerObj;
    [Header("�R���e�B�j���[�ʒu")] public GameObject[] continuePoint;
    [Header("�Q�[���I�[�o�[")] public GameObject gameOverObj;
    [Header("�t�F�[�h")] public FadeImage fade;
    [Header("�Q�[���I�[�o�[���ɖ炷SE")] public AudioClip gameOverSE;
    [Header("���g���C���ɖ炷SE")] public AudioClip retrySE;
    [Header("�X�e�[�W�N���A�[SE")] public AudioClip stageClearSE;
    [Header("�X�e�[�W�N���A")] public GameObject stageClearObj;
    [Header("�X�e�[�W�N���A����")] public PlayerTriggerCheck stageClearTrigger;

    private Player p;
    private int nextStageNum;
    private bool startFade = false;
    private bool doGameOver = false;
    private bool retryGame = false;
    private bool doSceneChange = false;
    private bool doClear = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null)
        {
            gameOverObj.SetActive(false); // New!
            playerObj.transform.position = continuePoint[0].transform.position;
            p = playerObj.GetComponent<Player>();
            if (p == null)
            {
                Debug.Log("�v���C���[����Ȃ������A�^�b�`����Ă����I");
            }
        }
        else
        {
            Debug.Log("�ݒ肪����ĂȂ���I");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I�[�o�[���̏���
        if (GManager.instance.isGameOver && !doGameOver) //New!
        {
            gameOverObj.SetActive(true);
            doGameOver = true;
        }
        //�v���C���[�����ꂽ���̏���
        else if (p != null && p.IsContinueWaiting() && !doGameOver)  //New!
        {
            if (continuePoint.Length > GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
                p.ContinuePlayer();
            }
            else
            {
                Debug.Log("�R���e�B�j���[�|�C���g�̐ݒ肪����ĂȂ���I");
            }
        }

        //�X�e�[�W��؂�ւ���
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //�Q�[�����g���C
                if (retryGame)
                {
                    GManager.instance.RetryGame();
                }
                //���̃X�e�[�W
                else
                {
                    GManager.instance.stageNum = nextStageNum;
                }
                SceneManager.LoadScene("stage" + nextStageNum);
                doSceneChange = true;
            }
        }
    }

    /// <summary>
    /// �ŏ�����n�߂� New!
    /// </summary>
    public void Retry()
    {
        ChangeScene(1); //�ŏ��̃X�e�[�W�ɖ߂�̂łP
        retryGame = true;
    }

    /// <summary>
    /// �X�e�[�W��؂�ւ��܂��B New!
    /// </summary>
    /// <param name="num">�X�e�[�W�ԍ�</param>
    public void ChangeScene(int num)
    {
        if (fade != null)
        {
            nextStageNum = num;
            fade.StartFadeOut();
            startFade = true;
        }
    }
}