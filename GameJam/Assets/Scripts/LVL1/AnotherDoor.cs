using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherDoor : Interactable
{
    public override bool Activate(GameObject player)
    {
        LeverOneWay lever = player.GetComponent<LeverOneWay>();
        if (lever)
        {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
