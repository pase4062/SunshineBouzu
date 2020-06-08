using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    #pragma warning disable 0649    // 警告非表示

    private GameObject lookobj;     // 注視するオブジェクト
    private Transform lookpos;      // 注視点

    [SerializeField]
    private GameObject Player;  // テルテル君

    [SerializeField]
    private GameObject Sun;     // 太陽君


    
    // Start is called before the first frame update
    void Start()
    {
        lookobj = Player;
        lookpos = lookobj.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x += (lookpos.position.x - transform.position.x) * Time.deltaTime * 2.0f;
        //pos.y += (lookpos.position.y - transform.position.y) * Time.deltaTime * 2.0f;

        transform.position = pos;

        // 注視物を変更
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeFocus();
        }
    }

    void ChangeFocus()
    {
        if(lookobj.tag == "Player")
        {
            lookobj = Sun;
        }
        else if((lookobj.tag == "Sun"))
        {
            lookobj = Player;
        }

        lookpos = lookobj.GetComponent<Transform>();
    }
}
