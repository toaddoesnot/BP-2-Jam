using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodCart : MonoBehaviour
{
    public GameObject[] jukes;
    
    public drinkManager drinkSc;
    //characterSlot (script)
    //handSc.moneyAm += 5; //FOR MONEY

    public int drinks;
    public bool breakLoop;

    public AudioSource ping;
    
    void Start()
    {
        drinks = 4;
    }

    public void OnMouseDown()
    {
        print("can see you");

        drinks = drinkSc.drinkHave;

        if (drinks != 4)
        {
            drinkSc.HasReadyCoffee = false;
            drinkSc.HasReadySoda = false;
            drinkSc.HasReadyOJ = false;
        }

        //if (handSc.haveOrder)

        foreach (GameObject juke in jukes)
        {
            if (juke.GetComponent<characterSlot>().myOrder != null) // MAY NOT WORK
            {
                juke.GetComponent<characterSlot>().myOrder.GetComponent<orderGenerator>().compareOrder();
            }
            
            if (breakLoop)
            {
                StartCoroutine(coolDown());
                break;
            }
        }
    }

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(1f);
        breakLoop = false;
    }
}
