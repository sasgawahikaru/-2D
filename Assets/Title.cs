using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;

    private bool firstPush = false;
    private bool goNextScene = false;

    //スタートボタンを押されたら呼ばれる
    //void Start()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        SceneManager.LoadScene("Stage1");
    //        Debug.Log("Press Start!");
    //        if (!firstPush)
    //        {
    //            Debug.Log("Go Next Scene!");
    //            fade.StartFadeOut();
    //            firstPush = true;
    //        }
    //    }
    //}
    //public void PressStart()
    //{
    //    Debug.Log("Press Start!");
    //    if (!firstPush)
    //    {
    //        Debug.Log("Go Next Scene!");
    //        fade.StartFadeOut();
    //        firstPush = true;
    //    }
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // SceneManager.LoadScene("Stage1");
            Debug.Log("Press Start!");
            if (!firstPush)
            {
                Debug.Log("Go Next Scene!");
                fade.StartFadeOut();
                firstPush = true;
            }
        }
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("Stage1");
            goNextScene = true;
        }
        //if (Input.GetKeyDown("S"))
        //{
        //    if (!goNextScene && fade.IsFadeOutComplete())
        //    {
        //        SceneManager.LoadScene("Stage1");
        //        goNextScene = true;
        //    }
        //}
    }
}