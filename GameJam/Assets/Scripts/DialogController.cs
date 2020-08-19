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

    private void Start()
    {
        button1 = GameObject.Find("Button");
        button2 = GameObject.Find("Button2");
        canvas = GameObject.Find("DialogueSystem");
    }

    public void SetState(State state)
    {
        this.state = state;
        canvas.SetActive(true);
        textComponent.text = state.GetStateStory();
        SetScene();
    }
    public void SetScene()
    {
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
