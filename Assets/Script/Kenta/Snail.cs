using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    // 移動速度
    public float speed = 1.0f;

    // RigidBody
    private Rigidbody2D rb;

    // 右向きフラグ
    public bool bRight;

    // 太陽フラグ
    public bool bSun;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bRight = true;
        bSun = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(!bSun)
        {
            if (bRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }

            if (!bRight)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EndWall"))
        {
            bRight = false;
        }
        else if (collision.gameObject.CompareTag("StartWall"))
        {
            bRight = true;
        }

        
    }
}
