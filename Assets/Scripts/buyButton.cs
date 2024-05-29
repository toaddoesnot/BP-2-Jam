using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buyButton : MonoBehaviour
{
    public int myPrice;
    public TextMeshProUGUI priceDisplay;

    public ingridientSupply mySupply;
    public coaster myDrink;
    public menuButton menuSc;

    public bool amDrink;

    public int maxRefill; //make refill amounts scarcer
    public TextMeshProUGUI myStock;

    public bool enabledB;

    void Awake()
    {

        if (amDrink)
        {
            mySupply = null;
            maxRefill = 1;
        }
        else
        {
            myDrink = null;
            maxRefill = 3;
        }
    }

    void Update()
    {
        priceDisplay.text = "$" + myPrice.ToString();

        if (amDrink)
        {
            myStock.text = myDrink.cupsLeft + "/5";
        }
        else
        {
            if (mySupply.ninePack)
            {
                myStock.text = mySupply.ingLeft + "/9"; //recharges
            }
            else
            {
                myStock.text = mySupply.ingLeft + "/6";
            }
        }
        
        if (!amDrink)
        {
            if(mySupply != null)
            {
                if (mySupply.recharges < maxRefill && menuSc.moneyLeft - myPrice >= 0) // && menuSc.moneyLeft + menuSc.pigSc.tipsTotal - myPrice >= 0                                //mySupply.recharges < maxRefill && menuSc.moneyLeft - myPrice >= 0 || 
                {
                    this.GetComponent<Button>().interactable = true;
                    enabledB = true;
                }
                else
                {
                    this.GetComponent<Button>().interactable = false;
                    enabledB = false;
                }
            }
                
        }

        if (amDrink)
        {
            if(myDrink != null)
            {
                if (myDrink.cupsLeft == 0 && menuSc.moneyLeft - myPrice >= 0)  // && menuSc.moneyLeft + menuSc.pigSc.tipsTotal - myPrice >= 0   //myDrink.cupsLeft == 0 && menuSc.moneyLeft - myPrice >= 0 ||  //(myDrink.rechargeCup < maxRefill && menuSc.moneyLeft - myPrice >= 0 || myDrink.rechargeCup < maxRefill && menuSc.moneyLeft + menuSc.pigSc.tipsTotal - myPrice >= 0)
                {
                    this.GetComponent<Button>().interactable = true;
                    enabledB = true;
                }
                else
                {
                    this.GetComponent<Button>().interactable = false;
                    enabledB = false;
                }
            }
            
        }
    }

    public void replenishProduce()
    {
        if (menuSc.moneyLeft - myPrice >= 0)
        {
            this.GetComponent<Animation>().Play();
            menuSc.boughtSth = true;

            if (!amDrink)
            {
                mySupply.AddIngredient();
            }
            else
            {
                myDrink.AddIngredient();
            }
            

            menuSc.moneyLeft = menuSc.moneyLeft - myPrice;

            if (menuSc.boughtSth)
            {
                menuSc.SetValue();
            }
        }
        else
        {
            if (menuSc.moneyLeft + menuSc.pigSc.tipsTotal - myPrice >= 0)
            {
                this.GetComponent<Animation>().Play();
                menuSc.boughtSth = true;

                if (!amDrink)
                {
                    mySupply.AddIngredient();
                }
                else
                {
                    myDrink.AddIngredient();
                }

                menuSc.pigSc.tipsTotal = myPrice - menuSc.moneyLeft;
                menuSc.moneyLeft = 0;
            }
        }
    }

}
