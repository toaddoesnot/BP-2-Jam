using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookers : MonoBehaviour
{
    
    //public GameObject Ramen;
    //public GameObject FrenchToast;

    public bool RamenReady;
    public bool ToastReady;

    public bool HasFood;

    public bool IAmPot;
    public bool IAmToaster;
    public GameObject self;

    public GameObject foodSelected;
    public FoodClasses foodScript;

    public Inventory inventory;
    public GameObject inventoryManager;



    private void Start()
    {
        foodSelected = GameObject.FindGameObjectWithTag("Inventory");
        foodScript = foodSelected.GetComponent<FoodClasses>();
        HasFood = false;

        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
    }

    private void Update()
    {
        if (HasFood)
        {
            //self.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            //self.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    void OnMouseDown()
    {
        if (HasFood)
        {
            Checker();
        }
        else
        {
            if (foodScript.currentFoods is -1)
            {
                if (HasFood is false)
                {
                     
                }
            }
            else
            {
                if (foodScript.currentFoods == 4)
                {
                    if (IAmPot)
                    {
                        HasFood = true;
                        //Instantiate(Ramen, transform.position, Quaternion.identity);
                        foodScript.currentFoods = -1;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (foodScript.currentFoods == 0)
                    {
                        if (IAmToaster)
                        {
                            HasFood = true;
                            //Instantiate(FrenchToast, transform.position, Quaternion.identity);
                            foodScript.currentFoods = -1;
                        }
                        else
                        {

                        }
                       
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Toast" || collision.gameObject.tag == "Noodles")
        {
           HasFood = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Toast" || collision.gameObject.tag == "Noodles")
        {
            HasFood = false;
        }
    }

    public void Checker()
    {
        if (IAmPot)
        {
            inventory.SpaghettiCooked = true;
            Destroy(self);
        }

        if (IAmToaster)
        {
            inventory.ToastCooked = true;
            Destroy(self);
        }
    }

}
