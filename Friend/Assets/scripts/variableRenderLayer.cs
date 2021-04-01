using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variableRenderLayer : MonoBehaviour
{

    private bool isStatic;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //sr.sortingOrder = Mathf.RoundToInt(transform.position.y * -10);
        updateSortingLayer(this.gameObject);
        
    }

    private void updateSortingLayer(GameObject myObject)
    {

        if(myObject.GetComponent<SpriteRenderer>())
        {
            myObject.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * -10);
        }
        

        if (myObject.transform.childCount > 0)
        {
            for (int i = 0; i < myObject.transform.childCount; i++)
            {
                updateSortingLayer(myObject.transform.GetChild(i).gameObject);
            }
        }
    }
}
