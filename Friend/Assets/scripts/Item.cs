using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float id;

    public float quantity;

    public string itemName = "";

    /*public Item(float id, float quantity, string name)
    {
        this.id = id;
        this.quantity = quantity;
        this.name = name;
    }*/

    public void collected()
    {
        GetComponentInChildren<Animator>().SetTrigger("Collected");
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }

    public string to_string()
    {
        return ("Item: " + itemName + ", id: " + id + ", quantity: " + quantity);
    }
}
