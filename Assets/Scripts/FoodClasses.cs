using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClasses : MonoBehaviour
{
    public GameObject[] Foods;
    public int currentFoods = -1;

    

    private void Start()
    {
        
    }

    public void SetButton(int index)
    {
        currentFoods = index;
        //if (currentFoods != -1)
            //Foods[currentFoods].SetActive(false);
        //Foods[index].SetActive(true);
    }


    public void Update()
    {
        //print(currentFoods);
        //Foods[currentFoods].SetActive(false);
        //Foods[index].SetActive(true);
    }


}
