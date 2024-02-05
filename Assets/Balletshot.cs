using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balletshot : MonoBehaviour
{
    public GameObject tama;

    void FixedUpdate()
    {
        //ショット
        if (Input.GetKey(KeyCode.Z))
        {
            //プレハブ召喚
            GameObject playerShot = Instantiate(tama) as GameObject;
            playerShot.transform.position = this.transform.position;
        }
    }
}