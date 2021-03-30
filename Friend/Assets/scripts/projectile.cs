using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float ttl;
    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(transform.right * speed * 100);
        //rb.velocity += new Vector2(transform.forward.x * speed, transform.forward.y * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
