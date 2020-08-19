using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{

    public GameObject GUICanvas;
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
        if (collision.gameObject.name == "player")
        {
            if (GUICanvas)
            {
                GUICanvas.GetComponent<DeathMenu>().PlayerDied(collision.transform.position);
            }
        }
    }
}
