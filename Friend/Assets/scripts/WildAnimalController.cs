using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildAnimalController : MonoBehaviour
{

    public bool getsScared = true;

    public float speed = 5f;
    public float sprintSpeed = 8f;

    public float minActionTime;
    public float maxActionTime;

    public bool currentlyScared;
    private bool currentlyWaiting;
    private bool currentlyRoaming;

    private Vector2 direction;

    public Transform scareTarget;
    public float scareRadius = 5f;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentlyScared = false;
        currentlyRoaming = false;
        currentlyWaiting = false;

        speed /= 10f;

        scareTarget = null;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkProximity();
        //print("test");
        if (!currentlyScared)
        {
            //print("NotScared");
            if (!currentlyRoaming && !currentlyWaiting)
            {
                decideAction();
            } else if(currentlyRoaming)
            {
                rb.MovePosition(new Vector2( transform.position.x + (direction.x * speed) * Time.deltaTime, transform.position.y + (direction.y * speed) * Time.deltaTime));
            }
        } else if(getsScared) // Scared
        {
            print("Run");
            Vector2 scareDirection = new Vector2(transform.position.x - scareTarget.transform.position.x, transform.position.y - scareTarget.transform.position.y);
            scareDirection.Normalize();
            scareDirection *= 10f;

            rb.MovePosition(new Vector2(transform.position.x + (scareDirection.x * sprintSpeed) * Time.deltaTime, transform.position.y + (scareDirection.y * sprintSpeed) * Time.deltaTime));

            
        }
        
    }


    void decideAction()
    {
        //print("decideAction");

        int ff = Mathf.RoundToInt(Random.Range(0f, 1f));
        float time = Random.Range(minActionTime, maxActionTime);

        //print(ff);
        if (ff == 0) // Stand still
        {
            StartCoroutine(standForSeconds(time));
            anim.SetFloat("xMove", direction.x / 10f);
            anim.SetFloat("yMove", direction.y / 10f);  
        } else if(ff==1) // Move
        {
            direction = new Vector2((float)Random.Range(-10, 10), (float)Random.Range(-10, 10));
            anim.SetFloat("xMove", direction.x / 10f);
            anim.SetFloat("yMove", direction.y / 10f);

            StartCoroutine(roamForSeconds(time));
        }
    }

    public void SetScaredTarget(Transform target)
    {
        scareTarget = target;
        currentlyScared = true;
    }

    public void LostScaredTarget()
    {
        scareTarget = null;
        currentlyScared = false;
    }

    void checkProximity()
    {
        //if(Mathf.Abs((Vector2)(transform.position - scareTarget.position)))
    }

    IEnumerator standForSeconds(float seconds)
    {
        currentlyWaiting = true;
        yield return new WaitForSeconds(seconds);
        currentlyWaiting = false;
    }

    IEnumerator roamForSeconds(float seconds)
    {
        currentlyRoaming = true;
        yield return new WaitForSeconds(seconds);
        currentlyRoaming = false;
    }
}
