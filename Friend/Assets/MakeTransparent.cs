using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    //private SpriteRenderer sr;

    //private Color originalColour;

    public float alpha = 0.75f;

    //private Color transparentColour;

    private void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        
    }
    public void transparent()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Color colour = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
            colour.a = alpha;
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = colour;
        }
    }

    public void makeOriginal()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Color colour = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
            colour.a = 1f;
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = colour;
        }
    }
}
