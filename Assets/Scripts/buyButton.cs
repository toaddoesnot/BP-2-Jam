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

    void Awake()
    {

        if (amDrink)
        {
            mySupply = null;
            maxRefill = 5;
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

        if (!amDrink)
        {
            if (mySupply.recharges < maxRefill && menuSc.moneyLeft - myPrice >= 0)
            {
                this.GetComponent<Button>().enabled = true;
            }
            else
            {
                this.GetComponent<Button>().enabled = false;
            }
        }
        if (amDrink)
        {
            if (myDrink.rechargeCup < maxRefill && menuSc.moneyLeft - myPrice >= 0)
            {
                this.GetComponent<Button>().enabled = true;
            }
            else
            {
                this.GetComponent<Button>().enabled = false;
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
        }
    }

}
