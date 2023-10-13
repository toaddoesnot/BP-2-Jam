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
    public bool canDrop;
    
    void Start()
    {
        drinks = 4;
        canDrop = true;
    }

    public void OnMouseDown()
    {
        if (canDrop)
        {
            print("can see you");

            drinks = drinkSc.drinkHave;

            foreach (GameObject juke in jukes)
            {
                if (juke.GetComponent<characterSlot>().myOrder != null)
                {
                    juke.GetComponent<characterSlot>().myOrder.GetComponent<orderGenerator>().compareOrder();
                }

                if (breakLoop)
                {
                    StartCoroutine(coolDown());
                    break;
                }
            }
            canDrop = false;
            StartCoroutine(resetCart());
        }
        
    }

    IEnumerator resetCart()
    {
        yield return new WaitForSeconds(1.2f);
        canDrop = true;
    }


    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(1f);
        breakLoop = false;
    }
}
