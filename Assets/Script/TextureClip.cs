using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureClip : MonoBehaviour
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

    Texture2D getCenterClippedTexture(Texture2D texture)
    {
        Color[] pixel;
        Texture2D clipTex;
        int tw = texture.width;
        int th = texture.height;

        if (tw == th)
            return texture;
        if (tw > th)
        { // 横の方が長い
            int margin = tw - th;
            int margin2 = (tw - th) / 2;

            // GetPixels (x, y, width, height) で切り出せる
            pixel = texture.GetPixels(margin2, 0, tw - margin, th);

            // 横幅，縦幅を指定してTexture2Dを生成
            clipTex = new Texture2D(tw - margin, th);
        }
        else
        { // 縦の方が長い
            int margin = th - tw;
            int margin2 = (th - tw) / 2;
            pixel = texture.GetPixels(0, margin2, tw, th - margin);
            clipTex = new Texture2D(tw, th - margin);
        }
        clipTex.SetPixels(pixel);
        clipTex.Apply();
        return clipTex;
    }
}
