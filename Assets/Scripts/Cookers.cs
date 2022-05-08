using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookers : MonoBehaviour
{
    public FoodClasses FoodSelected;

    public GameObject Ramen;
    public GameObject FrenchToast;
    public GameObject InstantRamen;

    public bool RamenReady;
    public bool ToastReady;

    void OnMouseDown()
    {
        if (FoodSelected.currentFoods == 4)
        {
            Ramen.SetActive(true);
            RamenReady = true;
        }
        if (FoodSelected.currentFoods == 0)
        {
            FrenchToast.SetActive(true);
            ToastReady = true;
        }
    }
}
