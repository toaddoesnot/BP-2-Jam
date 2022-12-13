using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class orderGenerator : MonoBehaviour
{
    public int firstCourse;
    public int secondCourse;
    public int drinks;

    public int randomOrder;

    public GameObject[] toastIngredients;
    public GameObject[] noodleIngredients;
    public GameObject[] drinkIngredients;

    public bool OrderFullfilled;
    public bool DrinkFullfilled;

    public GameObject allDrinks;
    public GameObject allFood;

    public drinkManager drinkSc;
    public hand handSc;

    public AudioSource gulpSnd;
    public AudioSource chewSnd;

    public GameObject noodleBase;
    public GameObject toastBase;

    public AudioSource exitSnd;

    public void Start()
    {
        drinkSc = GameObject.FindGameObjectWithTag("Inventory").GetComponent<drinkManager>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        exitSnd = handSc.GetComponent<AudioSource>();

        if (handSc.tutorialLvl is 1)
        {
            firstCourse = Random.Range(0, 3);
            drinks = 3;

            randomOrder = 0;
            Order();
        }
        if (handSc.tutorialLvl is 2)
        {
            firstCourse = Random.Range(0, 3);
            secondCourse = Random.Range(0, 3);
            drinks = 3;

            randomOrder = Random.Range(0, 3);
            Order();
        }
        else
        {
            firstCourse = Random.Range(0, 3);
            secondCourse = Random.Range(0, 3);
            drinks = Random.Range(0, 4);

            randomOrder = Random.Range(0, 3);
            Order();
        }

        
    }

    public void OnMouseDown()
    {
        print("You clicked on a character");
        
        //DRINKS//
        if (drinks == drinkSc.drinkHave)
        {
            DrinkFullfilled = true;
            drinkSc.HasReadyCoffee = false;
            drinkSc.HasReadySoda = false;
            drinkSc.HasReadyOJ = false;
            handSc.moneyAm += 5;
        }

        if (handSc.haveOrder)
        {
            if (handSc.foodHave == randomOrder)
            {
                if (randomOrder is 0 && handSc.toastFill == firstCourse)
                {
                    handSc.haveOrder = false;
                    OrderFullfilled = true;
                    handSc.moneyAm += 10;
                }
                if (randomOrder is 1 && handSc.noodFill == secondCourse)
                {
                    handSc.haveOrder = false;
                    OrderFullfilled = true;
                    handSc.moneyAm += 15;
                }
                if (randomOrder is 2 && handSc.toastFill == firstCourse && handSc.noodFill == secondCourse)
                {
                    handSc.haveOrder = false;
                    OrderFullfilled = true;
                    handSc.moneyAm += 25;
                }
            }
        }
    }

    public void Update()
    {
        if(OrderFullfilled && DrinkFullfilled)
        {
            Skidaddle();
        }
        else
        {
            if (DrinkFullfilled)
            {
                allDrinks.SetActive(false);
            }
            if (OrderFullfilled)
            {
                allFood.SetActive(false);
            }
        }
    }

    public void Skidaddle()
    {
        exitSnd.Play();
        Destroy(this.gameObject);
    }


    public void Order()
    {
        if (randomOrder is 0)
        {
            Toast();
        }
        if (randomOrder is 1)
        {
            Noodle();
        }
        if (randomOrder is 2)
        {
            Toast();
            Noodle();
        }

        if (drinks is not 3)
        {
            foreach (GameObject drinkee in drinkIngredients)
            {
                drinkee.SetActive(false);
                drinkIngredients[drinks].SetActive(true);
            }
        }
        else
        {
            DrinkFullfilled = true;
        }
    }

    public void Toast()
    {
        toastBase.SetActive(true);

        if (firstCourse is 0 || firstCourse is 1)
        {
            foreach (GameObject toastee in toastIngredients)
            {
                toastee.SetActive(false);
                toastIngredients[firstCourse].SetActive(true);
            }
        }
        else
        {
            foreach (GameObject toastee in toastIngredients)
            {
                toastee.SetActive(true);
            }
        }
    }
    public void Noodle()
    {
        noodleBase.SetActive(true);

        if (secondCourse is 0 || secondCourse is 1)
        {
            foreach (GameObject noodee in noodleIngredients)
            {
                noodee.SetActive(false);
                noodleIngredients[secondCourse].SetActive(true);
            }
        }
        else
        {
            foreach (GameObject noodee in noodleIngredients)
            {
                noodee.SetActive(true);
            }
        }
    }
}
