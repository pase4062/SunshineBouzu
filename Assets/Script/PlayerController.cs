using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed;         // 移動速度
    private Vector3 velocity;

    private CharacterController controller;
    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        { //地面についているか判定
            if (Input.GetKey(KeyCode.B))
            {
                moveDirection.y = 5; //ジャンプするベクトルの代入
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

        moveDirection.y -= 10 * Time.deltaTime; //重力計算
        controller.Move(moveDirection * Time.deltaTime); 

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

        if(!Physics.Raycast(transform.position,
                        Vector3.up,
                        10.0f
                        ))
        {
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);

        }

        Debug.DrawLine(transform.position,
                transform.position + new Vector3(0, 10.0f, 0), Color.blue);


    }
}
