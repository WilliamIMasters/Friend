using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{

    //private Item itemToDrop = new Item();

    public GameObject itemPrefab;

    private void OnDestroy()
    {
        GameObject obj = Instantiate(itemPrefab);
        obj.GetComponent<Item>().id = 1f;
        obj.GetComponent<Item>().quantity = 1f;
        obj.GetComponent<Item>().name = "Meat";

        obj.transform.position = transform.position;
    }
}
