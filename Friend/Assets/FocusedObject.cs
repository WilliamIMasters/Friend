using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MakeTransparent>())
        {
            collision.GetComponent<MakeTransparent>().transparent();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MakeTransparent>())
        {
            collision.GetComponent<MakeTransparent>().makeOriginal();
        }
    }
}
