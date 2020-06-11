using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{

    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    public float growmax;       // 成長最大値
    public float growspeed;     // 成長速度
    private Vector3 Spos;       // 初期座標

    private float grow;         // 成長値
    private bool growflag;      // 成長フラグ
    private bool retreatflag;   // 退行フラグ

    Vector3 dir;                // 向き
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        growflag = false;
        retreatflag = false;
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

        // 退行処理
        if (retreatflag)
        {
            // 植物が成長
            if (grow > 0.0f)
            {
                Transform trans = this.transform;
                Vector3 pos = trans.position;
                // 真っすぐに成長
                pos -= dir * growspeed;
                grow += -growspeed;
                
                trans.position = pos;
               
            }
            else
            {
                retreatflag = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        

        // 太陽光判定
        if (hit.gameObject.GetComponent<SunLightController>())
        {
         
            audioSource.PlayOneShot(audioClip[0]);  // SE再生

            retreatflag = false;
            growflag = true;
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        // 太陽光判定
        if (hit.gameObject.GetComponent<SunLightController>())
        {
            growflag = false;
            retreatflag = true;

        }


    }
}
