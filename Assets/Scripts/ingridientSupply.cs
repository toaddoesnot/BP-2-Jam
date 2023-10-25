using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingridientSupply : MonoBehaviour
{
    public Sprite[] supplies; //from 9 to 0
    public Sprite lid;

    public bool ninePack; //if deselected then 6 pack
    public bool lidClosed;

    public int recharges;
    public int ingLeft;

    Image myImage;

    void Start()
    {
        myImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        myImage.sprite = supplies[ingLeft];

        if (ingLeft > 0)
        {
            this.GetComponent<Button>().enabled = true;
        }
        else
        {
            this.GetComponent<Button>().enabled = false;
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
            ingLeft = 6;
        }
        recharges--;
    }
}
