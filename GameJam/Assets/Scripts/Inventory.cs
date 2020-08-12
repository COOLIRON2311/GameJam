using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //TODO:
    //Item is inherited from MonoBehaviour, and storing it like that
    // is generally a shitty practice
    private Dictionary<string, Item> _inventory;
    void Start()
    {
        _inventory = new Dictionary<string, Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {   
            var itemObjects = GameObject.FindGameObjectsWithTag("Item");

            foreach (GameObject itemObject in itemObjects)
            {
                if (Vector2.Distance(transform.position, itemObject.transform.position) < 0.7)
                {
                    Item item = itemObject.GetComponent<Item>();
                    AddItem(item);
                    Destroy(itemObject);
                    break;
                }
            }
        }
    }

    public void AddItem(Item item)
    {
        if (_inventory.ContainsKey(item.ID))
        {
            _inventory[item.ID].amount += item.amount;
        }
        else
        {
            _inventory.Add(item.ID, item);
        }
    }

    public void RemoveItem(string id, int amount)
    {
        if (_inventory.ContainsKey(id))
        {
            if (_inventory[id].amount > amount)
            {
                _inventory[id].amount -= amount;
            }
            else if (_inventory[id].amount == amount)
            {
                _inventory.Remove(id);
            }
            else
            {
                Debug.LogError("Trying to delete more items than avaible in inventory: " + id + " " + amount);
            }
        }
        else
        {
            Debug.LogError("Trying to delete item that doesn't exist! " + id + " " + amount);
        }
    }

    public bool DoesItemExist(string id)
    {
        return _inventory.ContainsKey(id);
    }
}
