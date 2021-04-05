using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;


    Rigidbody2D rb;
    Animator anim;

    private float xmove = 0f;
    float ymove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            print(GetComponent<Invetory>().inventoryToString());
        }

        
            
        xmove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        ymove = Input.GetAxis("Vertical") * speed * Time.deltaTime;


        anim.SetFloat("xMove", Input.GetAxis("Horizontal"));
        anim.SetFloat("yMove", Input.GetAxis("Vertical"));
        //rb.MovePosition(new Vector2(transform.position.x + xmove, transform.position.y + ymove));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xmove, ymove);
    }
}
