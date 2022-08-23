using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class FoodButtonClick : MonoBehaviour
{
    public FoodClasses FoodSelected;
    public Inventory inventory;
    public GameObject inventoryManager;

    public GameObject self;

    public GameObject toast;
    public GameObject strawberry;
    public GameObject butter;
    public GameObject noodles;
    public GameObject egg;
    public GameObject shroom;

    public int orderCompletion;

    public bool HaveToast;
    public bool HaveNoodles;
    public bool HaveDrink;

    public Flowchart Main;


    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
        FoodSelected = inventoryManager.GetComponent<FoodClasses>();
    }

    public void Update()
    {
        if (toast.activeInHierarchy)
        {
            if (butter.activeInHierarchy)
            {
                if (strawberry.activeInHierarchy)
                {
                    Main.SetBooleanVariable("MadeToast", true);
                }
            }
        }

        if (noodles.activeInHierarchy)
        {
            if (egg.activeInHierarchy)
            {
                if (shroom.activeInHierarchy)
                {
                    Main.SetBooleanVariable("MadeSoup", true);
                }
            }
        }

    }

    void OnMouseDown()
    {
        if (FoodSelected.currentFoods == -1)
        {
            if (HaveToast is false)
            {
                if (inventory.ToastCooked)
                {
                    toast.SetActive(true);
                    orderCompletion++;
                    HaveToast = true;
                    inventory.ToastCooked = false;
                    FoodSelected.currentFoods = -1;
                }
            }

            if (HaveNoodles is false)
            {
                if (inventory.SpaghettiCooked)
                {
                    noodles.SetActive(true);
                    orderCompletion++;
                    HaveNoodles = true;
                    inventory.SpaghettiCooked = false;
                    FoodSelected.currentFoods = -1;
                }
            }

            if (inventory.sthCooked is false)
            {
                if (inventory.havePlate)
                {

                }
                else
                {
                    
                    inventory.havePlate = true;
                   inventory.OrderStatus = orderCompletion;
                    

                }
            }

        }

        if (FoodSelected.currentFoods == 1)
        {
                if (HaveToast)
                {
                    strawberry.SetActive(true);
                orderCompletion++;
                FoodSelected.currentFoods = -1;
                }
        }
           
        if (FoodSelected.currentFoods == 2)
        {
                if (HaveToast)
                {
                    butter.SetActive(true);
                orderCompletion++;
                FoodSelected.currentFoods = -1;
                }
        }
       

        if (FoodSelected.currentFoods == 5)
        {
                if (HaveNoodles)
                {
                    egg.SetActive(true);
                orderCompletion++;
                FoodSelected.currentFoods = -1;
                }
        }

        if (FoodSelected.currentFoods == 6)
        {
                if (HaveNoodles)
                {
                    shroom.SetActive(true);
                orderCompletion++;
                FoodSelected.currentFoods = -1;
                }
        }
        
    }

}
