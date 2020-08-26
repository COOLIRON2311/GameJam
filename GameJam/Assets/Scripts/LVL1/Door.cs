using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
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
        if (inv.DoesItemExist("L1_KEY"))
        {
            inv.RemoveItem("L1_KEY");
            Destroy(gameObject);
            return true;
        }
        else
        {
            PopUpMessage.ShowPopUpMessage("Кажется, нужен ключ...");
        }
        return false;
    }
}
