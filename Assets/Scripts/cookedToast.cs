using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedToast : MonoBehaviour
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
        buttons.currentFoods = -1;
        if (inventory.sthCooked)
        {
            
        }
        else
        {
            inventory.ToastCooked = true;
            Object.Destroy(self);
            buttons.currentFoods = -1;
        }
    }
}
