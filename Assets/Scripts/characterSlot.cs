using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlot : MonoBehaviour
{
    public bool occupied;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            occupied = true;
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
