using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenwareClicked : MonoBehaviour
{
    public FoodClasses FoodSelected;

    public GameObject Pot;
    public GameObject Toaster;

    public bool HasItem;

    void OnMouseDown()
    {
        if (FoodSelected.currentFoods == 9)
        {
            if(HasItem)
            {
                
            }
            else
            {
                Instantiate(Pot, transform.position, Quaternion.identity);
                FoodSelected.currentFoods = -1;
            }
        }
           
        if (FoodSelected.currentFoods == 10)
        {
            if (HasItem)
            {
                
            }
            else
            {
                Instantiate(Toaster, transform.position, Quaternion.identity);
                FoodSelected.currentFoods = -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cooker")
        {
            HasItem = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cooker")
        {
            HasItem = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}

