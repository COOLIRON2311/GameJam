using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherDoor : Interactable
{
    public override bool Activate(GameObject player)
    {
        Lever lever = player.GetComponent<Lever>();
        if (lever)
        {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
