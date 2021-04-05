using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float ttl;
    public float speed;

    public int damage;

    private Rigidbody2D rb;
    private Animator animator;

    private bool toDestroy;

    // Start is called before the first frame update
    void Start()
    {
        toDestroy = true;
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        rb.AddRelativeForce(transform.right * speed * 100);
        //rb.velocity += new Vector2(transform.forward.x * speed, transform.forward.y * speed);

        StartCoroutine(kill());
    }


    IEnumerator kill()
    {
        yield return new WaitForSeconds(ttl);

        if(toDestroy)
        {
            destroy();
        }
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }

    public void freeze()
    {
        toDestroy = false;
        rb.velocity = Vector3.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("Landed", true);
    }



}
