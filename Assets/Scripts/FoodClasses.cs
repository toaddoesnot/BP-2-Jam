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
    }



}
