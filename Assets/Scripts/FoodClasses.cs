using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodClasses : MonoBehaviour
{
    public GameObject[] Foods;
    public int currentFoods = -1;

    public bool noUcant;

    public void Update()
    {
        if (this.GetComponent<Inventory>().sthCooked is true || this.GetComponent<drinkManager>().HasSthReady is true)
        {
            foreach (GameObject but in Foods)
            {
                but.GetComponent<Button>().interactable = false;
            }
            noUcant = true;
        }
        else
        {
            foreach (GameObject but in Foods)
            {
                but.GetComponent<Button>().interactable = true;
            }
            noUcant = false;
        }
    }

    public void SetButton(int index)
    {
        currentFoods = index;

        if(currentFoods is 3) 
        {
            if (this.GetComponent<drinkManager>().pouring1)
            {
                if (this.GetComponent<drinkManager>().HasAnyCup)
                {
                    currentFoods = 12;
                }
            }
        }
        if (currentFoods is 7)
        {
            if (this.GetComponent<drinkManager>().pouring2)
            {
                if (this.GetComponent<drinkManager>().HasAnyCup)
                {
                    currentFoods = 12;
                }
            }
        }
        if (currentFoods is 11)
        {
            if (this.GetComponent<drinkManager>().pouring3)
            {
                if (this.GetComponent<drinkManager>().HasAnyCup)
                {
                    currentFoods = 12;
                }
            }
        }
    }



}
