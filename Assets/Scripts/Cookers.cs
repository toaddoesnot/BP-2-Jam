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
            Selected = false;
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
                Selected = false;
            }
            if (foodScript.currentFoods == 0)
            {
                Instantiate(FrenchToast, transform.position, Quaternion.identity);
                Selected = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Toast")
        {
            HasFood = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (collision.gameObject.tag == "Noodles")
        {
            HasFood = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Toast")
        {
            HasFood = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (collision.gameObject.tag == "Noodles")
        {
            HasFood = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
