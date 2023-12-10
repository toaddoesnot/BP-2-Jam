using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingridientSupply : MonoBehaviour
{
    public Sprite[] supplies; //from 9 to 0
    public Sprite lid;

    public Image[] dots;
    public Sprite[] dotSprites;

    public bool ninePack; //if deselected then 6 pack
    public bool twoPack;

    public bool lidClosed;

    public int recharges;
    public int ingLeft;

    Image myImage;
    private int minRecharged;
    public hand handSc;

    void Start()
    {
        myImage = this.GetComponent<Image>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        if (handSc.tutorialLvl is 1)
        {
            recharges = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myImage.sprite = supplies[ingLeft];

        if (handSc.tutorialLvl is 1 && recharges == 0)
        {
            recharges = 3;
        }

        if (ingLeft > 0)
        {
            this.GetComponent<Button>().enabled = true;
        }
        else
        {
            this.GetComponent<Button>().enabled = false;
        }

        if (dots != null && dots.Length > 0)
        {
            if (recharges > 0)
            {
                for (int i = 0; i < dots.Length; i++)
                {
                    if (i < recharges)
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
            }
            else
            {
                // Set all dots to empty if rechargeCup is zero
                for (int i = 0; i < dots.Length; i++)
                {
                    dots[i].sprite = dotSprites[0];
                }
            }
        }
    }

    public void Spend()
    {
        if (ingLeft == 1)
        {
            if (recharges > 0)
            {
                Recharge();
            }
            else
            {
                ingLeft = 0;
            }
        }
        else
        {
            ingLeft--;
        }
    }

    public void Recharge()
    {
        if (ninePack)
        {
            ingLeft = 9; 
        }
        else
        {
            if (twoPack)
            {
                ingLeft = 2;
            }
            else
            {
                ingLeft = 6;
            }
        }
        recharges--;
    }

    public void AddIngredient()
    {
        recharges++;

        if (recharges == 1 && ingLeft == 0)
        {
            Recharge();
        }
    }
}
