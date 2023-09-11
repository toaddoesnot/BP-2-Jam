using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drinkManager : MonoBehaviour
{
    public bool HasSthReady;
    public bool HasReadyCoffee;
    public bool HasReadySoda;
    public bool HasReadyOJ;

    public int drinkHave;

    public void Update()
    {
        if (HasReadyCoffee || HasReadySoda || HasReadyOJ)
        {
            HasSthReady = true;
        }
        else
        {
            HasSthReady = false;
        }

        if (HasReadyCoffee)
        {
            drinkHave = 0;
        }
        else
        {
            if (HasReadySoda)
            {
                drinkHave = 1;
            }
            else
            {
                if (HasReadyOJ)
                {
                    drinkHave = 2;
                }
                else
                {
                    drinkHave = 4;
                }
            }
        }
    }
}
