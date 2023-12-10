using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookers : MonoBehaviour
{
    
    //public GameObject Ramen;
    //public GameObject FrenchToast;

    //public bool RamenReady;
    //public bool ToastReady;

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
    public Sprite burnt;
    public Sprite burntTwo;

    public int whoDis; //1-pot; 2-pasta; 3-toast; 4-egg;
    public GameObject timerObj;

    public instructionalComments subtitleSc;
    public bool foodDead;

    private void Start()
    {
        myImage = this.GetComponent<Image>();
        foodSelected = GameObject.FindGameObjectWithTag("Inventory");
        foodScript = foodSelected.GetComponent<FoodClasses>();
        HasFood = false;

        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
        timerObj.SetActive(false);

        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
    }

    void Update()
    {
        if (foodReady && timerObj.GetComponent<miniTimer>().foodBurnt)
        {
            foodDead = true;

            if (whoDis is 2 || whoDis is 3) //1 potato 2 pasta 3 toast 4 egg
            {
                myImage.sprite = burnt;
            }

            if (whoDis is 1 || whoDis is 4)
            {
                myImage.sprite = burntTwo;
            }
        }
        else
        {
            foodDead = false;
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
            else
            {
                if (foodScript.currentFoods == 2 || foodScript.currentFoods == 1 || foodScript.currentFoods == 6)
                {
                    string justIng = "Ah, an add-on! Goes on a plate right after the base.";

                    if (!subtitleSc.instComments.Contains(justIng))
                    {
                        subtitleSc.instComments.Add(justIng);
                        subtitleSc.Subtitles();
                    }

                }
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
                if (foodScript.currentFoods == 2 || foodScript.currentFoods == 1 || foodScript.currentFoods == 6)
                {
                    string justIng = "Ah, an add-on! Goes on a plate right after the base.";

                    if (!subtitleSc.instComments.Contains(justIng))
                    {
                        subtitleSc.instComments.Add(justIng);
                        subtitleSc.Subtitles();
                    }
                    
                }

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

                    if (foodScript.currentFoods == 0 || foodScript.currentFoods == 5)
                    {
                        string potComment = "This is a pot! For pasta and potatoes only.";
                        if (!subtitleSc.instComments.Contains(potComment))
                        {
                            subtitleSc.instComments.Add(potComment);
                            subtitleSc.Subtitles();
                        }
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

                        if (foodScript.currentFoods == 4 || foodScript.currentFoods == 8)
                        {
                            string panComment = "This is a frying pan! For eggs and French toast only.";
                            if (!subtitleSc.instComments.Contains(panComment))
                            {
                                subtitleSc.instComments.Add(panComment);
                                subtitleSc.Subtitles();
                            }
                            
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

        if (foodDead)
        {
           inventory.sthBurnt = true;
            foodDead = false;
            timerObj.GetComponent<miniTimer>().foodBurnt = false;
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
