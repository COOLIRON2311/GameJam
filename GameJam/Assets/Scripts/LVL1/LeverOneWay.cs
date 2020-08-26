using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOneWay : Interactable
{
    [SerializeField] private Interactable[] lever_interactions;
    private bool activated = false;

    public override bool Activate(GameObject player)
    {
        if (!activated)
        {
            foreach(Interactable interaction in lever_interactions)
            {
                interaction.Activate(this.gameObject);
            }
            GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.27f, gameObject.transform.position.y);
        }
        else
        {
            PopUpMessage.ShowPopUpMessage("Рычаг не поддаётся в обратную сторону.");
        }

        activated = true;
        return true;
    }
}
