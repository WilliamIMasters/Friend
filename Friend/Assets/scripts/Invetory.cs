using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory : MonoBehaviour
{

    public List<Item> items = new List<Item>();

    void pickup(Item newItem)
    {
        print("Pickup item -> " + newItem.to_string());
        if(items.Count > 0)
        {
            foreach (Item item in items)
            {
                if (item.id == newItem.id)
                {
                    item.quantity += newItem.quantity;
                    print("Adding to stack");
                }
                else
                {
                    items.Add(newItem);
                    print("new unique item");
                }
            }
        } else
        {
            items.Add(newItem);
            print("new unique item");
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Collectible")
        {
            collision.gameObject.GetComponent<Item>().collected();
            pickup(collision.gameObject.GetComponent<Item>());
        }
    }


    public string inventoryToString()
    {

        if(items.Count > 0)
        {
            string s = "";
            foreach (Item item in items)
            {
                s += item.id + ") Item: " + item.itemName + ", quantity: " + item.quantity + "\n";
            }

            return s;
        } else
        {
            return "Empty";
        }
        
    }
}
