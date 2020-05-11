using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControllerB : MonoBehaviour
{
    public float growmax;       // 成長最大値
    public float growspeed;     // 成長速度
    private Vector3 Spos;       // 初期座標

    private float grow;         // 成長値
    private bool growflag;      // 成長フラグ

    Vector3 dir;                // 向き
    // Start is called before the first frame update
    void Start()
    {
        growflag = false;
       
        Transform trans = this.transform;
        Vector3 pos = trans.position;
        Spos = pos;             // 初期座標を保存

        grow = 0.0f;

        // 向き取得
        float angleDir = transform.eulerAngles.z * (Mathf.PI / 180.0f);
        dir = new Vector3(Mathf.Cos(angleDir), Mathf.Sin(angleDir), 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 成長処理
        if (growflag)
        {

            // 植物が成長
            if (grow < growmax)
            {


                Transform trans = this.transform;
                Vector3 pos = trans.position;
                // 真っすぐに成長
                pos += dir * growspeed;
                grow += growspeed;

                trans.position = pos;
            }
            else
            {
                growflag = false;
            }
        }

        
    }

    void OnTriggerEnter(Collider hit)
    {


        // 太陽光判定
        if (hit.gameObject.GetComponent<SunLightController>())
        {
          
            growflag = true;
        }
    }
    
}
