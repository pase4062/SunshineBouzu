using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    // 移動速度
    public float speed = 1.0f;

    // RigidBody
    private Rigidbody2D rb;

    // スケール
    Vector2 scale;

    // 右向きフラグ
    public bool bRight;

    // 太陽フラグ
    public bool bSun;

    // 
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
        bRight = true;
        bSun = false;
        anim = GetComponent<Animator>();
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
                scale.x = 1;
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }

            if (!bRight)
            {
                scale.x = -1;
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {

        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            bRight = !bRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sun"))
        {
            anim.SetBool("Hide", true);
            bSun = !bSun;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sun"))
        {
            anim.SetBool("Hide", false);
            bSun = !bSun;
        }
    }
}
