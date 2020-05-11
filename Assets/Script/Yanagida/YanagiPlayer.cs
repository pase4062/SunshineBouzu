using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YanagiPlayer : MonoBehaviour
{
    public float speed;         // 移動速度
    private Vector3 velocity;
    private Vector3 moveDirection;
    public float jumpForce;       // ジャンプ時に加える力
    Rigidbody2D rb2d;
    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            velocity -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            rb2d.AddForce(transform.up * this.jumpForce);
            jump = true;
        }
        //moveDirection.y -= 10 * Time.deltaTime; //重力計算
        //controller.Move(moveDirection * Time.deltaTime);

        velocity = velocity.normalized * speed;

        if (velocity.magnitude > 0)
        {
            transform.position += velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}
