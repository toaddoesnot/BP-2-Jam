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
    public bool FoodFullfilled;

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

    public GameObject[] timers; //0 - white 1 - red 2 - both 3,4,5 - drinks
    public int neededTimer;
    public string nombre;

    public GameObject[] additionalIng;
    public GameObject myPeepsc;

    public bool halfOrder;
    private int whatIhave;

    public int orderWorth; ///NEW FOR MONEY handSc.moneyAm += 5;
    public int myTip;
    public int[] prices; //0 - plain toast; 1 - toasts +1; 2 - toasts +2; 3 - nood plain; 4 - nood +1; 5 - nood +2; 6 - drink

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
        foreach (GameObject time in timers)
        {
            time.GetComponent<miniTimer>().timeText.text = nombre.ToString();
        }

        if (OrderFullfilled)
        {
            foreach (GameObject back in bgs)
            {
                back.SetActive(false);
            }
        }

        if (randomOrder == 0 && OrderFullfilled == false) //toast
        {
            neededTimer = 4; //0,1,2 - drinks, 3 - white 4 - red 5 - both
            timers[4].SetActive(true);
        }
        else
        {
            if (randomOrder is 1 && OrderFullfilled is false) //noodle
            {
                neededTimer = 3;
                timers[3].SetActive(true);
            }
            else
            {
                if (randomOrder is 2 && OrderFullfilled is false) //noodle
                {
                    if (!halfOrder)
                    {
                        neededTimer = 5;
                        timers[5].SetActive(true);
                    }
                    else
                    {
                        timers[5].SetActive(false);

                        if (whatIhave == 1)
                        {
                            neededTimer = 4;
                            timers[4].SetActive(true);
                            
                        }
                        if (whatIhave == 2)
                        {
                            neededTimer = 3;
                            timers[3].SetActive(true);
                        }
                        ////
                    }
                    
                }
            }
        }

        if (noodleIngredients[0].activeInHierarchy)
        {
            additionalIng[0].SetActive(true);
        }
        if (noodleIngredients[1].activeInHierarchy)
        {
            additionalIng[1].SetActive(true);
        }
        if (toastIngredients[0].activeInHierarchy)
        {
            additionalIng[2].SetActive(true);
        }
        if (toastIngredients[1].activeInHierarchy)
        {
            additionalIng[3].SetActive(true);
        }
    }

    public void Order()
    {
        if (randomOrder is 0)
        {
            Toast();
            orderWorth += prices[0];
        }
        if (randomOrder is 1)
        {
            Noodle();
            orderWorth += prices[3];
        }
        if (randomOrder is 2)
        {
            Toast();
            Noodle();
            orderWorth += prices[0] + prices[3];
        }

        if (drinks is not 3) //drinkPrice
        {
            foreach (GameObject drinkee in drinkIngredients)
            {
                drinkee.SetActive(false);
                drinkIngredients[drinks].SetActive(true);
            }

            if (DrinkFullfilled == false && OrderFullfilled == true)
            {
                neededTimer = drinks;
                timers[neededTimer].SetActive(true);
            }
            orderWorth += prices[6];
        }
        else
        {
            DrinkFullfilled = true;
        }

        
        //StartCoroutine(GoTimers());
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
            orderWorth += prices[1];
        }
        else
        {
            foreach (GameObject toastee in toastIngredients)
            {
                toastee.SetActive(true);
            }
            orderWorth += prices[2];
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
            orderWorth += prices[4];
        }
        else
        {
            foreach (GameObject noodee in noodleIngredients)
            {
                noodee.SetActive(true);
            }
            orderWorth += prices[5];
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
            cartObj.ping.Play();

            StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

            drinkSc.HasReadyCoffee = false;
            drinkSc.HasReadySoda = false;
            drinkSc.HasReadyOJ = false;
        }
        //
        

        if (OrderFullfilled == false && handSc.foodHave == randomOrder || OrderFullfilled == false && randomOrder is 2)
        {
            if (randomOrder is 0 && handSc.toastFill == firstCourse)
            {
                handSc.haveOrder = false;
                OrderFullfilled = true;

                if (drinks != 4 && !DrinkFullfilled)
                {
                    neededTimer = drinks;
                    timers[neededTimer].SetActive(true);
                    myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                    //myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                }

                StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

                cartObj.breakLoop = true;
                cartObj.ping.Play();
            }

            if (PotatoONoodle is 1)
            {
                if (randomOrder is 1 && handSc.noodFill == secondCourse && handSc.potatoInstead || randomOrder is 2 && handSc.toastFill == firstCourse && handSc.noodFill == secondCourse && handSc.potatoInstead)
                {
                    handSc.haveOrder = false;
                    OrderFullfilled = true;

                    if(drinks != 4 && !DrinkFullfilled)
                    {
                        neededTimer = drinks;
                        timers[neededTimer].SetActive(true);
                        myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                        myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                    }

                    StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

                    cartObj.breakLoop = true;
                    cartObj.ping.Play();
                }
                else ///HALF-ORDER
                {
                    print("Half order received");

                    if (randomOrder is 2 && handSc.toastFill == firstCourse || randomOrder is 2 && handSc.noodFill == secondCourse && handSc.potatoInstead)
                    {
                        if (!halfOrder)
                        {
                            if(handSc.toastFill == firstCourse)
                            {
                                whatIhave = 2;

                                bgs[0].SetActive(false);

                                neededTimer = 3;
                                timers[neededTimer].SetActive(true);

                                myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                                ////////myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                                /////insert change of timer, disable order ticket sprite
                            }
                            if(handSc.noodFill == secondCourse)
                            {
                                whatIhave = 1;

                                bgs[1].SetActive(false);

                                neededTimer = 4;
                                timers[neededTimer].SetActive(true);

                                myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                                ///////myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                                /////insert change of timer, disable order ticket sprite
                            }
                            handSc.haveOrder = false;
                            halfOrder = true;

                            StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

                            cartObj.breakLoop = true;
                            cartObj.ping.Play();
                        }
                        else
                        {
                            handSc.haveOrder = false;
                            OrderFullfilled = true;

                            if (drinks != 4 && !DrinkFullfilled)
                            {
                                neededTimer = drinks;
                                timers[neededTimer].SetActive(true);

                                myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                                myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                            }

                            StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

                            cartObj.breakLoop = true;
                            cartObj.ping.Play();
                        }
                    }
                }
            }
            else
            {
                if (randomOrder is 1 && handSc.noodFill == secondCourse || randomOrder is 2 && handSc.toastFill == firstCourse && handSc.noodFill == secondCourse)
                {
                    handSc.haveOrder = false;
                    OrderFullfilled = true;

                    if (drinks != 4 && !DrinkFullfilled)
                    {
                        neededTimer = drinks;
                        timers[neededTimer].SetActive(true);
                        myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                        myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                        //timers[neededTimer].GetComponent<miniTimer>().InitiateTimer();
                    }

                    StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

                    cartObj.breakLoop = true;
                    cartObj.ping.Play();
                }
                else
                {
                    if (randomOrder is 2 && handSc.toastFill == firstCourse || randomOrder is 2 && handSc.noodFill == secondCourse)
                    {
                        if (!halfOrder)
                        {
                            if (handSc.toastFill == firstCourse)
                            {
                                whatIhave = 2;
                                bgs[0].SetActive(false);

                                neededTimer = 3;
                                timers[neededTimer].SetActive(true);

                                myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                                //////////myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                                /////insert change of timer, disable order ticket sprite
                            }
                            if (handSc.noodFill == secondCourse)
                            {
                                whatIhave = 1;
                                bgs[1].SetActive(false);

                                neededTimer = 4;
                                timers[neededTimer].SetActive(true);

                                myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                                ////////myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                                /////insert change of timer, disable order ticket sprite
                            }
                            handSc.haveOrder = false;
                            halfOrder = true;

                            StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

                            cartObj.breakLoop = true;
                            cartObj.ping.Play();
                        }
                        else
                        {
                            handSc.haveOrder = false;
                            OrderFullfilled = true;

                            if (drinks != 4 && !DrinkFullfilled)
                            {
                                neededTimer = drinks;
                                timers[neededTimer].SetActive(true);
                                myPeepsc.GetComponent<characterSlot>().myNewTimer = timers[neededTimer];
                                myPeepsc.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().InitiateTimer();
                                //timers[neededTimer].GetComponent<miniTimer>().InitiateTimer();
                            }

                            StartCoroutine(myPeepsc.GetComponent<characterSlot>().Eating());

                            cartObj.breakLoop = true;
                            cartObj.ping.Play();
                        }
                    }
                }
            }
        }
    }
}
