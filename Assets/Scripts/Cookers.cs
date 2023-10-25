using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookers : MonoBehaviour
{
    
    //public GameObject Ramen;
    //public GameObject FrenchToast;

    //public bool RamenReady;
   // public bool ToastReady;

    public bool HasFood;

    public bool IAmPot;
    public bool IAmToaster;
    public GameObject self;

    public GameObject foodSelected;
    public FoodClasses foodScript;

    public Inventory inventory;
    public GameObject inventoryManager;

    public GameObject myStove;

    public Slider timer;
    public bool foodReady;

    Image myImage;
    public GameObject lid;
    public Sprite empty;
    public Sprite full;
    public Sprite fullTwo;

    public int whoDis; //1-pot; 2-pasta; 3-toast; 4-egg;
    public GameObject timerObj;

    private void Start()
    {
        myImage = this.GetComponent<Image>();
        foodSelected = GameObject.FindGameObjectWithTag("Inventory");
        foodScript = foodSelected.GetComponent<FoodClasses>();
        HasFood = false;

        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
        timerObj.SetActive(false);
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
            if (foodReady && foodScript.noUcant is false && foodScript.currentFoods is -1)
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
                        if (inventory.sthCooked is false && foodScript.noUcant is false)
                        {
                            foodScript.currentFoods = 10; //ENABLE FOR DISHWASHING!!!!!!!!!!!!!
                            Destroy(self); //ENABLE FOR DISHWASHING!!!!!!!!!!!!!
                        }
                    }
                    if (IAmPot)
                    {
                        if (inventory.sthCooked is false && foodScript.noUcant is false)
                        {
                            foodScript.currentFoods = 9; //ENABLE FOR DISHWASHING!!!!!!!!!!!!!
                            Destroy(self); //ENABLE FOR DISHWASHING!!!!!!!!!!!!!
                        }
                    }
                }
            }
            else
            {
                if (IAmPot)
                {
                    if (foodScript.currentFoods == 4)
                    {
                        whoDis = 2; //pasta 

                        foodScript.Foods[4].GetComponent<ingridientSupply>().Spend();

                        StartCoroutine(Cook());
                        HasFood = true;
                        foodScript.currentFoods = -1;
                    }
                    if (foodScript.currentFoods == 8)
                    {
                        whoDis = 1; //potato

                        foodScript.Foods[8].GetComponent<ingridientSupply>().Spend();

                        StartCoroutine(Cook());
                        HasFood = true;
                        foodScript.currentFoods = -1;
                    }
                }

                else
                {
                    if (IAmToaster)
                    {
                        if (foodScript.currentFoods == 0)
                        {
                            whoDis = 3; //toast

                            foodScript.Foods[0].GetComponent<ingridientSupply>().Spend();

                            StartCoroutine(Cook());
                            HasFood = true;
                            foodScript.currentFoods = -1;
                        }
                        if (foodScript.currentFoods == 5)
                        {
                            whoDis = 4; //egg

                            foodScript.Foods[5].GetComponent<ingridientSupply>().Spend();

                            StartCoroutine(Cook());
                            HasFood = true;
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

        if (whoDis is 1)
        {
            inventory.PotatoCooked = true;
            myStove.GetComponent<KitchenwareClicked>().TakePasta();
        }

        if (whoDis is 2)
        {
            inventory.SpaghettiCooked = true;
            myStove.GetComponent<KitchenwareClicked>().TakePasta();
        }

        if (whoDis is 3)
        {
            inventory.ToastCooked = true;
            myStove.GetComponent<KitchenwareClicked>().TakeBread();
        }

        if (whoDis is 4)
        {
            inventory.EggCooked = true;
            myStove.GetComponent<KitchenwareClicked>().TakeBread();
        }

        ResetTimer();
        HasFood = false;
        myImage.sprite = empty;
        whoDis = 0;
    }

    public IEnumerator Cook()
    {
        print("ALIVE");
        lid.SetActive(true);
        timerObj.SetActive(true);
        

        if (IAmPot)
        {
            myStove.GetComponent<KitchenwareClicked>().Boiling();
        }
        if (IAmToaster)
        {
            myStove.GetComponent<KitchenwareClicked>().Frying();
        }

        timerObj.GetComponent<miniTimer>().InitiateTimer();
        timer.value += 1;
        yield return new WaitForSeconds(1);
        timer.value += 1;
        yield return new WaitForSeconds(1);
        timer.value += 1;
        yield return new WaitForSeconds(1);
        timer.value += 1;
        yield return new WaitForSeconds(1);
        timer.value += 1;
        foodReady = true;

        if (IAmPot)
        {
            myStove.GetComponent<KitchenwareClicked>().BoilingReady();
        }
        if (IAmToaster)
        {
            myStove.GetComponent<KitchenwareClicked>().FryingReady();
        }
        lid.SetActive(false);

        if (whoDis is 2 || whoDis is 3)
        {
            myImage.sprite = full;
        }

        if (whoDis is 1 || whoDis is 4)
        {
            myImage.sprite = fullTwo;
        }
    }

    public void ResetTimer()
    {
        timer.value = 0;
        foodReady = false;
        timerObj.SetActive(false);
    }

}
