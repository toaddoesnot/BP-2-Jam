using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenwareClicked : MonoBehaviour
{
    public FoodClasses FoodSelected;

    public GameObject Pot;
    public GameObject Toaster;
    //public GameObject itemSpawn;

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
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                HasItem = true;
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
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                HasItem = true;
            }
        }
    }

}
