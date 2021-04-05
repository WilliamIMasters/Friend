using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBob : MonoBehaviour
{
    public float modifier = 10f;
    public float f = 0.01f;
    public float i =0f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = transform.position;
        //pos.y += Mathf.Sin(Time.time * f) * modifier;
        transform.position += transform.up * Mathf.Sin(Time.time * 3f + i) * f / modifier;
    }
}
