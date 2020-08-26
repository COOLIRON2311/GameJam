using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] private Interactable[] lever_interactions;
    private bool activated = false;

    public override bool Activate(GameObject player)
    {
        if (!activated)
        {
            activated = true;
            GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.27f, gameObject.transform.position.y);
        }
        else
        {
            activated = false;
            GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.27f, gameObject.transform.position.y);
        }

        foreach (Interactable interaction in lever_interactions)
        {
            interaction.Activate(this.gameObject);
        }

        
        return true;
    }
}
