using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float initialDelay;
    public float delay;

    public GameObject objToSpawn;

    public bool randAngle = true;


    void Start()
    {
        StartCoroutine(initialWait());
    }

    private void spawn()
    {
        GameObject newObj = Instantiate(objToSpawn);
        newObj.transform.position = transform.position;
        Vector3 rotation = transform.rotation.eulerAngles;
        if(randAngle)
        {
            rotation.z += Random.Range(-15, 15);

        }
        newObj.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    IEnumerator waitToSpawn()
    {
        yield return new WaitForSeconds(delay);
        spawn();
        StartCoroutine(waitToSpawn());
    }

    IEnumerator initialWait()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(waitToSpawn());
    }
}
