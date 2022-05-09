using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookers : MonoBehaviour
{
    
    public GameObject Ramen;
    public GameObject FrenchToast;

    public bool RamenReady;
    public bool ToastReady;

    public bool HasRamen;
    public bool HasToast;

    public GameObject foodSelected;
    public FoodClasses foodScript;

    private void Start()
    {
        foodSelected = GameObject.FindGameObjectWithTag("Inventory");
        foodScript = foodSelected.GetComponent<FoodClasses>();
    }

    void OnMouseDown()
    {
        if (foodScript.currentFoods == 4)
        {
            if(HasRamen)
            {

            }
            else
            {
                Instantiate(Ramen, transform.position, Quaternion.identity);
                HasRamen = true;
            }
        }
        if (foodScript.currentFoods == 0)
        {
            if (HasToast)
            {

            }
            else
            {
                Instantiate(FrenchToast, transform.position, Quaternion.identity);
                HasToast = true;
            }

        }
    }
}
