using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerGenerator : MonoBehaviour
{
    public bool HasCustomer;
    public GameObject customer;
    public orderGenerator orderSc;

    private void Start()
    {
        GenerateCustomer();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            HasCustomer = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            HasCustomer = false;
            GenerateCustomer();
        }
    }

    public void GenerateCustomer()
    {
        Instantiate(customer, transform.position, Quaternion.identity);
        orderSc.GenerateOrder();
    }
}
