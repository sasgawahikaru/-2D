using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balletshot : MonoBehaviour
{
    public GameObject tama;

    void FixedUpdate()
    {
        //�V���b�g
        if (Input.GetKey(KeyCode.Z))
        {
            //�v���n�u����
            GameObject playerShot = Instantiate(tama) as GameObject;
            playerShot.transform.position = this.transform.position;
        }
    }
}