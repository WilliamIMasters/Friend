using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scary : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ScareDetector" && collision.gameObject.GetComponentInParent<WildAnimalController>())
        {
            collision.gameObject.GetComponentInParent<WildAnimalController>().SetScaredTarget(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ScareDetector" && collision.gameObject.GetComponentInParent<WildAnimalController>())
        {
            collision.gameObject.GetComponentInParent<WildAnimalController>().LostScaredTarget();
        }
    }
}
