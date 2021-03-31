using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour
{

    public int healthPoints;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            flashRed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile" && collision.gameObject.GetComponent<projectile>())
        {
            this.takeDamage(collision.gameObject.GetComponent<projectile>().damage);
            collision.gameObject.GetComponent<projectile>().freeze();
            collision.gameObject.transform.parent = gameObject.transform;
            //collision.gameObject.GetComponent<projectile>().destroy();
        }
    }

    public void takeDamage(int damage)
    {
        healthPoints -= damage;
        flashRed();
        if(healthPoints <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(this.gameObject);
    }

    private void flashRed()
    {
        Color original = sr.color;
        sr.color = Color.red;
        StartCoroutine(flashOriginal(original));
    }

    private IEnumerator flashOriginal(Color original)
    {
        yield return new WaitForSeconds(0.1f);
        sr.color = original;
    }
}
