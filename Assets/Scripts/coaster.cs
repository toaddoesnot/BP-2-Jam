using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coaster : MonoBehaviour
{
    public GameObject myCup;
    public drinkManager drinkSc;
    public FoodClasses foodSelected;

    public bool occupied;

    public AudioSource cupSound;
    public pourDrink myButton;
    public int myDrink;

    public int cupsLeft;
    public int rechargeCup; //how many recharges I have

    private bool canPlace;

    public Image[] dots;
    public Sprite[] dotSprites;

    public bool depress;
    public GameObject outSign;

    void Start()
    {
        if (!depress)
        {
            cupsLeft = 5;
        }
        else
        {
            cupsLeft = 1;
        }
    }

    void Update()
    {
        if (cupsLeft > 0) //rechargeCup
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (i < cupsLeft) //rechargeCup
                {
                    // Dot is full
                    dots[i].sprite = dotSprites[1];
                    
                }
                else
                {
                    // Dot is empty
                    dots[i].sprite = dotSprites[0];
                    
                }
            }
            outSign.SetActive(false);
        }
        else
        {
            // Set all dots to empty if rechargeCup is zero
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].sprite = dotSprites[0];
            }

            outSign.SetActive(true);
        }

        if (cupsLeft > 0)
        {
            myButton.GetComponent<Button>().enabled = true;
            canPlace = true;
        }
        else
        {
            //myButton.GetComponent<Button>().enabled = false;
            cupsLeft = 0;
            canPlace = false;
        }

    }

    public void Spend()
    {
        
        if (cupsLeft == 1)
        {
            if (rechargeCup > 0)
            {
                Recharge();
            }
            else
            {
                cupsLeft = 0;
            }
        }
        else
        {
            cupsLeft--;
        }
    }

    public void Recharge()
    {
        cupsLeft = 5;
        rechargeCup--;
    }

    void OnMouseDown()
    {
        if (occupied)
        {
            if (cupsLeft >= 0)
            {
                if (myCup.GetComponent<cupOfDrink>().drinkReady && foodSelected.noUcant is false && foodSelected.currentFoods is -1)
                {
                    if (myCup.GetComponent<cupOfDrink>().IamCoffee)
                    {
                        drinkSc.HasReadyCoffee = true;
                    }
                    if (myCup.GetComponent<cupOfDrink>().IamSoda)
                    {
                        drinkSc.HasReadySoda = true;
                    }
                    if (myCup.GetComponent<cupOfDrink>().IamJuice)
                    {
                        drinkSc.HasReadyOJ = true;
                    }

                    Spend();
                    occupied = false;
                    myCup.GetComponent<cupOfDrink>().drinkReady = false;

                    myButton.filled = false;
                    myButton.ResetPadding();

                    myCup.GetComponent<cupOfDrink>().takeDrink.Play();
                    myCup.SetActive(false);
                }
                else //just with a glass
                {
                    if (myCup.GetComponent<RectMask2D>().padding.w == 175) //if didn't start pouring
                    {
                        occupied = false;
                        myCup.SetActive(false);
                        cupSound.Play();
                        foodSelected.currentFoods = 12;
                    }
                }
            } 
        }
        else
        {
            if (foodSelected.currentFoods == 12)
            {
                if (canPlace)
                {
                    occupied = true;

                    myCup.SetActive(true);
                    cupSound.Play();
                    foodSelected.currentFoods = -1;
                }
            }
            else
            {
                if (drinkSc.drinkHave == myDrink)
                {
                    myButton.filled = true;
                    occupied = true;
                    myCup.SetActive(true);
                    cupSound.Play();
                    foodSelected.currentFoods = -1;

                    cupsLeft++;

                    if (myCup.GetComponent<cupOfDrink>().IamCoffee)
                    {
                        drinkSc.HasReadyCoffee = false;
                    }
                    if (myCup.GetComponent<cupOfDrink>().IamSoda)
                    {
                        drinkSc.HasReadySoda = false;
                    }
                    if (myCup.GetComponent<cupOfDrink>().IamJuice)
                    {
                        drinkSc.HasReadyOJ = false;
                    }

                    myButton.SetPadding();
                }
            }
            
        }
    }

    public void AddIngredient()
    {
        //rechargeCup = 1;//++

        //if (rechargeCup == 1 && cupsLeft == 0)
        //{
        //Recharge();
        //}
        cupsLeft = 5;
    }
}
