using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClasses : MonoBehaviour
{
    public GameObject[] Foods;
    public int currentFoods = -1;

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
