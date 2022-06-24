using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool HaveToast;
    public bool HaveNoodles;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
        FoodSelected = inventoryManager.GetComponent<FoodClasses>();
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
                    Destroy(self);
                    inventory.havePlate = true;
                }
            }

        }

        if (FoodSelected.currentFoods == 1)
        {
                if (HaveToast)
                {
                    strawberry.SetActive(true);
                    FoodSelected.currentFoods = -1;
                }
        }
           
        if (FoodSelected.currentFoods == 2)
        {
                if (HaveToast)
                {
                    butter.SetActive(true);
                    FoodSelected.currentFoods = -1;
                }
        }
       

        if (FoodSelected.currentFoods == 5)
        {
                if (HaveNoodles)
                {
                    egg.SetActive(true);
                    FoodSelected.currentFoods = -1;
                }
        }

        if (FoodSelected.currentFoods == 6)
        {
                if (HaveNoodles)
                {
                    shroom.SetActive(true);
                    FoodSelected.currentFoods = -1;
                }
        }
        
    }

}
