using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Activate(GameObject player)
    {
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interactor i = collision.GetComponent<Interactor>();
        if (i)
        {
            i.AddInteraction(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Interactor i = collision.GetComponent<Interactor>();
        if (i)
        {
            i.RemoveInteraction(this);
        }
        Debug.Log("EXIT");
    }
}
