using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redish : MonoBehaviour
{
    public plateGenerator myPlace;
    public hand inventory;
    public dishwashingMachine dishSc;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
    }

    public void OnMouseDown()
    {
        if (inventory.haveOrder)
        {
            inventory.haveOrder = false;
            dishSc.recharges++;

            myPlace.GeneratePlate();
            //make so that all ingredients transfer too

            dishSc.recharges--;
        }
    }
}
