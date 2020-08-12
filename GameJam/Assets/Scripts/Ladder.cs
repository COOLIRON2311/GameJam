using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl pc = collision.GetComponent<PlayerControl>();
        if (pc)
        {
            pc.isOnLadder = true;
            //Stops player from falling:
            //I don't think that's a good idea btw
            // rb.simulated doesn't work
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerControl pc = collision.GetComponent<PlayerControl>();
        if (pc)
        {
            pc.isOnLadder = false;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 4f;
        }
    }
}
