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

    void OnMouseDown()
    {
        if (occupied)
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
        else
        {
            if (foodSelected.currentFoods == 12)
            {
                occupied = true;
                myCup.SetActive(true);
                cupSound.Play();
                foodSelected.currentFoods = -1;
            }
            if (drinkSc.drinkHave == myDrink)
            {
                myButton.filled = true;
                occupied = true;
                myCup.SetActive(true);
                cupSound.Play();
                foodSelected.currentFoods = -1;

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
