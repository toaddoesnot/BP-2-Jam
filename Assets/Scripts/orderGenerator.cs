using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class orderGenerator : MonoBehaviour
{
    public int firstCourse;
    public int secondCourse;
    public int drinks;

    public int randomOrder;

    public GameObject[] noodleIngredients;
    public GameObject[] toastIngredients;
    public GameObject[] drinkIngredients;
    public GameObject[] bgs;

    public bool OrderFullfilled;
    public bool DrinkFullfilled;

    public drinkManager drinkSc;
    public hand handSc;

    public GameObject noodleBase;
    public GameObject potatoBase;
    public GameObject toastBase;

    public AudioSource exitSnd;
    public GameObject mee;

    public int PotatoONoodle;
    public foodCart cartObj;
    private bool canCheck; 

    public void Start()
    {
        drinkSc = GameObject.FindGameObjectWithTag("Inventory").GetComponent<drinkManager>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        cartObj = GameObject.FindGameObjectWithTag("foodcart").GetComponent<foodCart>(); 

        exitSnd = handSc.GetComponent<AudioSource>();

        if (handSc.tutorialLvl is 1)
        {
            firstCourse = Random.Range(0, 3);
            drinks = 3;

            randomOrder = 0;
            Order();
        }
        else
        {
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
                PotatoONoodle = Random.Range(0, 2);
                firstCourse = Random.Range(0, 3);
                secondCourse = Random.Range(0, 3);
                drinks = Random.Range(0, 4);

                randomOrder = Random.Range(0, 3);
                Order();
            }
        }
    }

    public void Update()
    {
        if(OrderFullfilled && DrinkFullfilled)
        {
            Skidaddle();
        }
    }

    public void Skidaddle()
    {
        Destroy(mee);
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
        bgs[0].SetActive(true);
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
        bgs[1].SetActive(true);
        if (PotatoONoodle is 0)
        {
            noodleBase.SetActive(true);
        }

        if (PotatoONoodle is 1)
        {
            potatoBase.SetActive(true);
        }

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

    public void compareOrder()
    {
        if (DrinkFullfilled == false && cartObj.drinks == drinks)
        {
            DrinkFullfilled = true;
            foreach (GameObject drinkee in drinkIngredients)
            {
                drinkee.SetActive(false);
            }
            cartObj.drinks = 4;
            cartObj.breakLoop = true;
        }
        //

        if (OrderFullfilled == false && handSc.foodHave == randomOrder)
        {
            if (randomOrder is 0 && handSc.toastFill == firstCourse)
            {
                handSc.haveOrder = false;
                OrderFullfilled = true;
                cartObj.breakLoop = true;
            }

            if (PotatoONoodle is 1)
            {
                if (randomOrder is 1 && handSc.noodFill == secondCourse && handSc.potatoInstead || randomOrder is 2 && handSc.toastFill == firstCourse && handSc.noodFill == secondCourse && handSc.potatoInstead)
                {
                    handSc.haveOrder = false;
                    OrderFullfilled = true;
                    cartObj.breakLoop = true;
                }
            }
            else
            {
                if (randomOrder is 1 && handSc.noodFill == secondCourse || randomOrder is 2 && handSc.toastFill == firstCourse && handSc.noodFill == secondCourse)
                {
                    handSc.haveOrder = false;
                    OrderFullfilled = true;
                    cartObj.breakLoop = true;
                }
            }
        }
    }
}
