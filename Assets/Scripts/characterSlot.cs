using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlot : MonoBehaviour
{
    public bool occupied;
    public GameObject myPeep;

    public GameObject myRat;
    public GameObject myHound;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            occupied = true;
            myPeep = collision.gameObject;
            if (myPeep.GetComponent<classCustomer>().hound)
            {
                myPeep.transform.position = myHound.transform.position;
            }

            if (myPeep.GetComponent<classCustomer>().rat)
            {
                myPeep.transform.position = myRat.transform.position;
            }
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
