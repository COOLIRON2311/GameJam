using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private State state;
    [SerializeField] Text button1text;
    [SerializeField] Text button2text; 
    [SerializeField] Text textComponent;
    private GameObject canvas;
    private GameObject button1;
    private GameObject button2;
    private GameObject port1;
    private GameObject port2;
    private GameObject port3;

    private void Start()
    {
        button1 = GameObject.Find("Button");
        button2 = GameObject.Find("Button2");
        port1 = GameObject.Find("Image");
        port2 = GameObject.Find("Image1");
        port3 = GameObject.Find("Image2");
        canvas = GameObject.Find("DialogueSystem");
    }

    public void SetState(State state)
    {
        this.state = state;
        canvas.SetActive(true);
        port1.SetActive(false);
        port2.SetActive(false);
        port3.SetActive(false);
        textComponent.text = state.GetStateStory();
        SetScene();
    }
    public void SetScene()
    {
        if (state.Portrait == 1)
        {
        port1.SetActive(true);
        port2.SetActive(false);
        port3.SetActive(false);
        }
        else if (state.Portrait == 2)
        {
        port1.SetActive(false);
        port2.SetActive(true);
        port3.SetActive(false);
        }
        else if (state.Portrait == 3)
        {
        port1.SetActive(false);
        port2.SetActive(false);
        port3.SetActive(true);
        }
        if (state.Buttons.Length == 1)
        {
            button2.SetActive(false);
            button1text.text = state.Buttons[0];
        }
        else if (state.Buttons.Length == 2)
        {
            button2.SetActive(true);
            button1text.text = state.Buttons[0];
            button2text.text = state.Buttons[1];            
        }
    }
    
    public void FirstButton()
    { 
       
        var nextStates = state.GetNextStates();
        state = nextStates[0];
        textComponent.text = state.GetStateStory();
        if(state.IsEnd())
        {
            canvas.SetActive(false);
        }
        SetScene();
        
    }
    public void SecondButton()
    {  
        var nextStates = state.GetNextStates();
        state = nextStates[1];
        textComponent.text = state.GetStateStory();
        if(state.IsEnd())
        {
            canvas.SetActive(false);
        }
        SetScene();
       
    }
}
