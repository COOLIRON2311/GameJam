using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    [SerializeField] State startingState;
    [SerializeField] private DialogController _dialogController;
    State state;
    
    void Start()
    {
        state = startingState;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _dialogController.SetState(state);
    }
}
