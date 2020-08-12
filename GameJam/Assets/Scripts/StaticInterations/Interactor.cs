using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private List<Interactable> _interactions;
    // Start is called before the first frame update
    void Start()
    {
        _interactions = new List<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && _interactions.Count > 0)
        {
            _interactions.First().Activate(gameObject);
        }
    }

    public void AddInteraction(Interactable interaction)
    {
        _interactions.Add(interaction);
    }

    public void RemoveInteraction(Interactable interaction)
    {
        _interactions.Remove(interaction);
    }
}
