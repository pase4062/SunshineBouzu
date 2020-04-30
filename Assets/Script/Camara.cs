using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    private Transform lookpos;   // 注視点

    // Start is called before the first frame update
    void Start()
    {
        lookpos = GameObject.Find("player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x += (lookpos.position.x - transform.position.x) * Time.deltaTime * 2.0f;
        //pos.y += (lookpos.position.y - transform.position.y) * Time.deltaTime * 2.0f;

        transform.position = pos;

        if (Input.GetKey(KeyCode.M))
        {
            transform.position += new Vector3(2, 0, 0);
        }
    }
}
