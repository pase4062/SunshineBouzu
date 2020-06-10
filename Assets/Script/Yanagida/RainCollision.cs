using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollision : MonoBehaviour
{
    GameObject Player;       // プレイヤー取得用
    PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playercontroller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "Player")
        {
            // プレイヤーが濡れた
            playercontroller.ColRain();
            
        }
        
    }
}
