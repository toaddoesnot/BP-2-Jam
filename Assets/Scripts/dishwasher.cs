using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dishwasher : MonoBehaviour
{
    public Inventory inventory;
    public FoodClasses foodSelected;

    public TextMeshProUGUI orderText;
    public int orderCount;

    public plateGenerator plateSc1;
    public plateGenerator plateSc2;
    public plateGenerator plateSc3;
    public plateGenerator plateSc4;

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
                RegeneratePlates();
               
            }
        }
        else
        {
            foodSelected.currentFoods = -1;
        }

    }

    public void RegeneratePlates()
    {
        plateSc1.GeneratePlate();
        plateSc2.GeneratePlate();
        plateSc3.GeneratePlate();
        plateSc4.GeneratePlate();
    }
}
