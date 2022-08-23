using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderGenerator : MonoBehaviour
{
    public bool HasOrder;
    public GameObject order;

    public Inventory inventorySc;

    private void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Order")
        {
            HasOrder = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Order")
        {
            HasOrder = false;
            GenerateOrder();
        }
    }

    public void GenerateOrder()
    {
            Instantiate(order, transform.position, Quaternion.identity);
            inventorySc.havePlate = false;

    }

}
