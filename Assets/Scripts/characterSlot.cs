using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlot : MonoBehaviour
{
    public bool occupied;
    public GameObject myPeep;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            occupied = true;
            myPeep = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            occupied = false;
        }
    }
    
}
