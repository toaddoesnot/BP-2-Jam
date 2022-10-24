using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dishwasher : MonoBehaviour
{
    public Inventory inventory;
    public FoodClasses foodSelected;
    public drinkManager drinkSc;

    public int orderCount;

    public plateGenerator plateSc1;
    public plateGenerator plateSc2;
    public plateGenerator plateSc3;

    public AudioSource trashSound;

    void OnMouseDown()
    {
        if(foodSelected.currentFoods is -1)
        {
            if (inventory.ToastCooked)
            {
                inventory.ToastCooked = false;
                trashSound.Play();
            }
            if (inventory.SpaghettiCooked)
            {
                inventory.SpaghettiCooked = false;
                trashSound.Play();
            }
            if (inventory.havePlate)
            {
                inventory.havePlate = false;
                RegeneratePlates();
                trashSound.Play();
            }
            if (drinkSc.HasReadyCoffee || drinkSc.HasReadySoda || drinkSc.HasReadyOJ)
            {
                drinkSc.HasReadyCoffee = false;
                drinkSc.HasReadySoda = false;
                drinkSc.HasReadyOJ = false;
                trashSound.Play();
            }
        }
        else
        {
            foodSelected.currentFoods = -1;
            trashSound.Play();
        }
    }

    public void RegeneratePlates()
    {
        plateSc1.GeneratePlate();
        plateSc2.GeneratePlate();
        plateSc3.GeneratePlate();
    }
}
