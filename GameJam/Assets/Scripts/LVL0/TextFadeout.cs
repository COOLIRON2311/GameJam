using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeout : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float dist = Vector2.Distance(gameObject.transform.parent.position, player.transform.position);
            Debug.Log(dist);
            if (dist < 5)
            {
                Debug.Log("here");
                Text t = GetComponent<Text>();
                Color color = t.color;
                color.a = 1-dist/5;
                t.color = color;
            }
        }
    }
}
