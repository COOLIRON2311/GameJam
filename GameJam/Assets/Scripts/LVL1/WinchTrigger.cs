using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class WinchTrigger : Interactable
{
    public GameObject BridgeLeft;
    public GameObject BridgeRight;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool Activate(GameObject player)
    {
        Inventory inv = player.GetComponent<Inventory>();
        if (inv.DoesItemExist("L1_WHEEL"))
        {
            inv.RemoveItem("L1_WHEEL");

            Animator left = BridgeLeft.GetComponent<Animator>();
            Animator right = BridgeRight.GetComponent<Animator>();

            left.Play("BridgeDescend");
            right.Play("BridgeDescend");
            Debug.Log("NEW");
            return true;
        }
        return false;
    }
}
