using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] private Interactable[] lever_interactions;

    public override bool Activate(GameObject player)
    {
        foreach (Interactable interaction in lever_interactions)
        {
            interaction.Activate(player);
        }

        return true;
    }
}
