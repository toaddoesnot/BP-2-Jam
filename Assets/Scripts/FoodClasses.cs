using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodClasses : MonoBehaviour
{
    public GameObject[] Foods;
    public int currentFoods = -1;
    public hand handSc;
     
    public bool noUcant;

    public void Update()
    {
        if (this.GetComponent<Inventory>().sthCooked is true || this.GetComponent<drinkManager>().HasSthReady is true || handSc.haveOrder)
        {
            noUcant = true;
        }
        else
        {
            noUcant = false;
        }

        if (Input.GetMouseButtonDown(1))//right mouse button
        {
            if(currentFoods != -1)
            {
                currentFoods = -1;
            }
        }
    }

    public void SetButton(int index)
    {
        if (!noUcant)
        {
            currentFoods = index;
        }
    }
}
