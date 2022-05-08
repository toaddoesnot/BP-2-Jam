using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenwareClicked : MonoBehaviour
{
    public FoodClasses FoodSelected;

    public GameObject Kettle;
    public GameObject Pot;
    public GameObject Toaster;

    void OnMouseDown()
    {
        if (FoodSelected.currentFoods == 8)
        {
            Kettle.SetActive(true);
            Pot.SetActive(false);
            Toaster.SetActive(false);
        }
        if (FoodSelected.currentFoods == 9)
        {
            Pot.SetActive(true);
            Kettle.SetActive(false);
            Toaster.SetActive(false);
        }
        if (FoodSelected.currentFoods == 10)
        {
            Toaster.SetActive(true);
            Pot.SetActive(false);
            Kettle.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
