﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    public bool debug;　　　　　// デバッグモード
    public float speed;         // 移動速度
    private Vector3 velocity;

    private Rigidbody2D rb;
    private Vector3 moveDirection;
    private Vector3 respornPos;  // リスポジション
    public int jumpPower;        // ジャンプ力
    public  GroundCheck gc;      // 接地判定

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        debug = true;
        respornPos = transform.position;
        jumpPower = 250;
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.GetGround())
        { 
            //地面についているか判定
            if (Input.GetKeyDown(KeyCode.B))
            {
                audioSource.PlayOneShot(audioClip[0]);  // ジャンプSE再生

                rb.AddForce(Vector2.up * jumpPower);    //ジャンプするベクトルの代入
            }
        }

        // 移動
        velocity = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            velocity -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
        }

        velocity = velocity.normalized * speed * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            transform.position += velocity;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }

        // 雨判定
        if(!Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y + 1.2f),
                        Vector2.up,
                        10.0f
                        ) && !debug)
        {
            transform.position = respornPos;
        }

        Debug.DrawLine(transform.position,
                transform.position + new Vector3(0, 10.0f, 0), Color.blue);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CheckPoint")
        {
            respornPos = collision.gameObject.transform.position;
        }

    }

}