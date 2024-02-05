using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLeft : MonoBehaviour
{
    private Rigidbody2D rb = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x -= 0.5f;
        //pos.x -= 0.1f;

        //’e‚ÌˆÚ“®
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //if (pos.z >= 20)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
