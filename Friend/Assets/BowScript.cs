using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public GameObject bow;

    public float rotationSpeed = 10f;
    public float radius = 2f;
    public float radiusSpeed = 2f;

    private Vector3 desiredPos;

    void Start()
    {
        bow.transform.position = (bow.transform.position - transform.position).normalized * radius + transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Rotate around player
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(mousePos.y - playerScreenPos.y, mousePos.x - playerScreenPos.x) * Mathf.Rad2Deg;
        float currentAngle = bow.transform.eulerAngles.z;

        bow.transform.RotateAround(transform.position, new Vector3(0, 0, 1), angle - currentAngle);



        // Fire
        if(Input.GetMouseButtonDown(0))
        {
            print("fire");
        }


    }
}
