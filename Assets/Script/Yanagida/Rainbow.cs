using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    //private GameObject gameObject;
    private Color color;        // オブジェクトカラー
    private bool alphaflag;
    public float alpha;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        color = gameObject.GetComponent<Renderer>().material.color;
        color.a = alpha;
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if(alphaflag)
        {
            if(alpha < 0.8f)
            {
                alpha += 0.01f;
            }
        }
        if(!alphaflag)
        {
            if (alpha > 0.1f)
            {
                alpha += -0.01f;
            }
        }

        
        color = gameObject.GetComponent<Renderer>().material.color;
        color.a = alpha;
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    public void OnSun()
    {
        audioSource.PlayOneShot(audioClip[0]);  // SE再生

        // 太陽光判定
        alphaflag = true;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    public void OutSun()
    {
        // 太陽光が離れた
        
        alphaflag = false;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
