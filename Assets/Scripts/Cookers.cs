using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookers : MonoBehaviour
{
    
    public GameObject Ramen;
    public GameObject FrenchToast;

    public bool RamenReady;
    public bool ToastReady;

    public bool HasFood;
    public bool Selected;

    public GameObject foodSelected;
    public FoodClasses foodScript;

    private void Start()
    {
        foodSelected = GameObject.FindGameObjectWithTag("Inventory");
        foodScript = foodSelected.GetComponent<FoodClasses>();
        Selected = false;
        HasFood = false;
    }

    void OnMouseDown()
    {
        

        if (HasFood)
        {
            
        }
        else
        {
            if (Selected)
            {
                Selected = false;
            }
            else
            {
                Selected = true;
            }


            if (foodScript.currentFoods == 4)
            {
                Instantiate(Ramen, transform.position, Quaternion.identity);
            }
            if (foodScript.currentFoods == 0)
            {
                Instantiate(FrenchToast, transform.position, Quaternion.identity);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            HasFood = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            HasFood = false;
        }
    }

}
