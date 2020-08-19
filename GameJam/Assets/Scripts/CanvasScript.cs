using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
   GameObject Canvas;


    void Start()
    {
        Canvas = GameObject.Find("DialogueSystem");
        Canvas.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
