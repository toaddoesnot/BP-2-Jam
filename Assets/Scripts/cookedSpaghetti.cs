using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedSpaghetti : MonoBehaviour
{
    public Inventory inventory;
    public FoodClasses buttons;

    public GameObject inventoryManager;
    public GameObject self;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
        buttons = inventoryManager.GetComponent<FoodClasses>();
    }

    void OnMouseDown()
    {
        print("Crissie wake up");
        if (inventory.sthCooked)
        {

        }
        else
        {
            inventory.SpaghettiCooked = true;
            Object.Destroy(self);
            buttons.currentFoods = -1;
        }
    }
}
