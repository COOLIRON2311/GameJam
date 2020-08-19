using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    [SerializeField] State startingState;
   
   State state;
   GameObject Canvas;
   GameObject button1;
   GameObject button2;

   [SerializeField] Text button1text;
    [SerializeField] Text button2text; 
   [SerializeField] Text textComponent;

    void Start()
    {
        button1 = GameObject.Find("Button");
        button2 = GameObject.Find("Button2");
        Canvas = GameObject.Find("DialogueSystem");
        state = startingState;
        //SetScene();
    }

    public State GiveMeState()
    {
        return state;
    }

 private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Canvas.SetActive(true);
        textComponent.text = state.GetStateStory();
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
            Canvas.SetActive(false);
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
            Canvas.SetActive(false);
        }
        SetScene();
       
    } 

}
