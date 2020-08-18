using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    [TextArea(10, 40)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] public string[] Buttons;
    [SerializeField] public bool end;


    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public bool IsEnd()
    {
        if (end)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
