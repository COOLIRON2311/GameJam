using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    [SerializeField] State startingState;
   State state;
   GameObject Canvas;
   GameObject Button1;
   [SerializeField] Text textComponent;

    void Start()
    {
        Button1 = GameObject.Find("Button");
        Canvas = GameObject.Find("DialogueSystem");
        state = startingState;
    }

private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Canvas.SetActive(true);
        textComponent.text = state.GetStateStory();
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
        //SetScene();
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
        //SetScene();
    }

}
