using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private bool bGround;

    // Start is called before the first frame update
    void Start()
    {
        bGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetGround()
    {
        return bGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bGround = false;
    }
}
