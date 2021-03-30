using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;


    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xmove = 0f;
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f) // move right
        {
            
            xmove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }

        float ymove = 0f;
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.1f) // move right
        {

            ymove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }


        anim.SetFloat("xMove", Input.GetAxis("Horizontal"));
        anim.SetFloat("yMove", Input.GetAxis("Vertical"));
        rb.MovePosition(new Vector2(transform.position.x + xmove, transform.position.y + ymove));
    }
}
