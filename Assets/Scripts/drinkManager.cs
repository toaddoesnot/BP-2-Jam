using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drinkManager : MonoBehaviour
{
    public GameObject cupLeft;
    public GameObject cupMiddle;
    public GameObject cupRight;

    public GameObject sliderLeft;
    public GameObject sliderMiddle;
    public GameObject sliderRight;

    public bool HasAnyCup;
    public bool HasSthReady;
    public bool HasReadyCoffee;
    public bool HasReadySoda;
    public bool HasReadyOJ;

    public bool pouring1;
    public bool pouring2;
    public bool pouring3;

    public void Update()
    {
        if (this.GetComponent<FoodClasses>().currentFoods is 12)
        {

        }
        else
        {
            HasAnyCup = false;
        }

        if (HasReadyCoffee || HasReadySoda || HasReadyOJ)
        {
            HasSthReady = true;
        }
        else
        {
            HasSthReady = false;
        }

    }

    public void GetCup()
    {
        if(HasSthReady is false)
        {
            HasAnyCup = true;
        }
        else
        {

        }
    }

    public void PrepareCoffee()
    {
        if (pouring1 is false)
        {
            if (HasAnyCup)
            {
                pouring1 = true;
                HasAnyCup = false;
                this.GetComponent<FoodClasses>().currentFoods = -1;
                cupLeft.SetActive(true);
                sliderLeft.SetActive(true);
                cupLeft.GetComponent<cupOfDrink>().DrinkPreparation();
            }
        }
    }

    public void PrepareSoda()
    {
        if (pouring2 is false)
        {
            if (HasAnyCup)
            {
                pouring2 = true;
                HasAnyCup = false;
                this.GetComponent<FoodClasses>().currentFoods = -1;
                cupMiddle.SetActive(true);
                sliderMiddle.SetActive(true);
                cupMiddle.GetComponent<cupOfDrink>().DrinkPreparation();
            }
        }
    }

    public void PrepareOJ()
    {
        if (pouring3 is false)
        {
            if (HasAnyCup)
            {
                pouring3 = true;
                HasAnyCup = false;
                this.GetComponent<FoodClasses>().currentFoods = -1;
                cupRight.SetActive(true);
                sliderRight.SetActive(true);
                cupRight.GetComponent<cupOfDrink>().DrinkPreparation();
            }
        }
    }

}
