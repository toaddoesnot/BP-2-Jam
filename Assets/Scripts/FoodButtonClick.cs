using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButtonClick : MonoBehaviour
{
    public FoodClasses FoodSelected;
    public Inventory inventory;
    public GameObject inventoryManager;

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
        
        if (HaveToast)
        {
            if (FoodSelected.currentFoods == 1)
            {
                strawberry.SetActive(true);
                FoodSelected.currentFoods = -1;
            }
            if (FoodSelected.currentFoods == 2)
            {
                butter.SetActive(true);
                FoodSelected.currentFoods = -1;
            }
        }

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

        if (HaveNoodles)
        {
            if (FoodSelected.currentFoods == 5)
            {
                egg.SetActive(true);
                FoodSelected.currentFoods = -1;
            }
            if (FoodSelected.currentFoods == 6)
            {
                shroom.SetActive(true);
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
