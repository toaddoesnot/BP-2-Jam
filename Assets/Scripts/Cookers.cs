using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public KitchenwareClicked myStove;

    public Slider timer;
    public bool foodReady;


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
            if (foodReady)
            {
                print("Ready to check");
                Checker();
            }
        }
        else
        {
            if (foodScript.currentFoods is -1)
            {
                if (HasFood is false)
                {
                    print("go to dishwasher");

                    if (IAmToaster)
                    {
                        if (inventory.sthCooked is false)
                        {
                            foodScript.currentFoods = 10;
                            Destroy(self);
                        }
                    }
                    if (IAmPot)
                    {
                        if (inventory.sthCooked is false)
                        {
                            foodScript.currentFoods = 9;
                            Destroy(self);
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                if (foodScript.currentFoods == 4)
                {
                    if (IAmPot)
                    {
                        StartCoroutine(Cook());
                        HasFood = true;
                        //Instantiate(Ramen, transform.position, Quaternion.identity);
                        foodScript.currentFoods = -1;
                    }
                }
                else
                {
                    if (foodScript.currentFoods == 0)
                    {
                        if (IAmToaster)
                        {
                            StartCoroutine(Cook());
                            HasFood = true;
                            //Instantiate(FrenchToast, transform.position, Quaternion.identity);
                            foodScript.currentFoods = -1;
                        }
                    }
                }
            }



        }
    }


    public void Checker()
    {
        print("CHECKING");

        if (IAmPot)
        {
            inventory.SpaghettiCooked = true;
            ResetTimer();
            HasFood = false;
            //Destroy(self);
        }

        if (IAmToaster)
        {
            inventory.ToastCooked = true;
            ResetTimer();
            HasFood = false;
            // Destroy(self);
        }
    }

    public IEnumerator Cook()
    {
        print("ALIVE");
        timer.value += 1;
        yield return new WaitForSeconds(1);
        timer.value += 1;
        yield return new WaitForSeconds(1);
        timer.value += 1;
        yield return new WaitForSeconds(1);
        timer.value += 1;
        foodReady = true;
    }

    public void ResetTimer()
    {
        timer.value = 0;
        foodReady = false;
    }

}
