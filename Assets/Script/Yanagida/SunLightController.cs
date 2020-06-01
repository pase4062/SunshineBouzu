using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightController : MonoBehaviour
{
    public float speed;         // 移動速度
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.J))
        {
            velocity -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.L))
        {
            velocity += Vector3.right;
        }

        velocity = velocity.normalized * speed * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            transform.position += velocity;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        
        // 太陽光判定
        if (hit.gameObject.GetComponent<Rainbow>())
        {
   

            hit.gameObject.GetComponent<Rainbow>().OnSun();
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        // 太陽光判定
        //if (hit.gameObject.name == "Rainbow")
        if(hit.gameObject.GetComponent<Rainbow>())
        {
            hit.gameObject.GetComponent<Rainbow>().OutSun();
        }
    }
}
