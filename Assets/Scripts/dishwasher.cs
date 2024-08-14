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
    public hand handSc;

    public int orderCount;

    public AudioSource trashSound;
    public dishwashingMachine dishSc;

    public bool cantTrash;

    void OnMouseDown()
    {
        if (!cantTrash)
        {
            trashSound.Play();

            if (foodSelected.currentFoods is -1)
            {
                if (inventory.ToastCooked)
                {
                    inventory.ToastCooked = false;
                }
                if (inventory.SpaghettiCooked)
                {
                    inventory.SpaghettiCooked = false;
                }
                if (inventory.EggCooked)
                {
                    inventory.EggCooked = false;
                }
                if (inventory.PotatoCooked)
                {
                    inventory.PotatoCooked = false;
                }

                if (inventory.sthBurnt)
                {
                    inventory.sthBurnt = false;
                }

                if (inventory.havePlate)
                {
                    inventory.havePlate = false;
                }
                if (drinkSc.HasReadyCoffee || drinkSc.HasReadySoda || drinkSc.HasReadyOJ)
                {
                    drinkSc.HasReadyCoffee = false;
                    drinkSc.HasReadySoda = false;
                    drinkSc.HasReadyOJ = false;
                }
                if (handSc.haveOrder)
                {
                    handSc.haveOrder = false;
                    dishSc.recharges--;
                }
            }
            else
            {

                foodSelected.currentFoods = -1;
                trashSound.Play();
            }
        }
        
    }

}
