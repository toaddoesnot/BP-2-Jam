using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class orderSc : MonoBehaviour
{
    public Inventory inventorySc;
    public dishwasher dishSc;

    private void Start()
    {
        inventorySc = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        dishSc = FindObjectOfType<dishwasher>().GetComponent<dishwasher>();
    }

    public void OnMouseDown()
    {
        if (inventorySc.havePlate)
        {
            CompleteOrder();
        }
    }

    public void CompleteOrder()
    {
        
        if (inventorySc.OrderStatus is 6)
        {
            inventorySc.HowManyOrds += 1;
            inventorySc.AddOrder();
            inventorySc.OrderStatus = 0;
            inventorySc.havePlate = false;
            dishSc.RegeneratePlates();

        }

        else
        {
            
        }
        
    }

}
