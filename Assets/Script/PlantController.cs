using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public float growmax;       // 成長最大値
    public float growspeed;     // 成長速度
    private Vector3 Spos;       // 初期座標

    private float grow;         // 成長値

    private GameObject collisionobj;
    // Start is called before the first frame update
    void Start()
    {
        Transform trans = this.transform;
        Vector3 pos = trans.position;
        Spos = pos;             // 初期座標を保存

        grow = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider hit)
    {
        

        // 太陽光判定
        if (hit.gameObject.GetComponent<SunLightController>())
        {
            if (grow < growmax)
            {


                Transform trans = this.transform;
                Vector3 pos = trans.position;
                // 真っすぐに成長
                pos.x += growspeed;
                grow += growspeed;
                gameObject.GetComponent<BoxCollider>().isTrigger = true;

                trans.position = pos;
            }
        }
    }
    void OnTriggerExit(Collider hit)
    {
  
        
        
    }
}
