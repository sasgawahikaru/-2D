using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class kinsetu : MonoBehaviour
{
//    protected Player isDown;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 //       if (isDown==false) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Bullet, transform.position, Quaternion.identity);
            }
 //       }
    }
}
