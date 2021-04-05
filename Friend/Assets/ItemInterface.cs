using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInterface : MonoBehaviour
{

    public void destroy()
    {
        GetComponentInParent<Item>().destroy();
    }

}
