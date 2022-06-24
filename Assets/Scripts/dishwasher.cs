using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dishwasher : MonoBehaviour
{
    public Inventory inventory;
    public FoodClasses foodSelected;

    private void Start()
    {
       
    }

    private void Update()
    {
        
    }


    void OnMouseDown()
    {
        if(foodSelected.currentFoods is -1)
        {
            if (inventory.ToastCooked)
            {
                inventory.ToastCooked = false;
            }
            if (inventory.SpaghettiCooked)
            {
                inventory.SpaghettiCooked = false;
            }
            if (inventory.havePlate)
            {
                inventory.havePlate = false;
            }
        }
        else
        {
            foodSelected.currentFoods = -1;
        }

    }
}
