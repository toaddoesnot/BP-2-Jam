using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cupOfDrink : MonoBehaviour
{
    public bool IamCoffee;
    public bool IamSoda;
    public bool IamJuice;

    public bool drinkReady;

    public GameObject myDrink;
    public GameObject drinkManagerSc;

    public Slider timePour;
    public AudioSource takeDrink;

    // Update is called once per frame
    void Update()
    {
        if (drinkReady)
        {
            myDrink.SetActive(true);

            if (IamCoffee)
            {
                if(drinkManagerSc.GetComponent<drinkManager>().HasSthReady is false)
                {
                    drinkManagerSc.GetComponent<drinkManager>().sliderLeft.SetActive(false);
                }
            }
            if (IamSoda)
            {
                if (drinkManagerSc.GetComponent<drinkManager>().HasSthReady is false)
                {
                    drinkManagerSc.GetComponent<drinkManager>().sliderMiddle.SetActive(false);
                }
            }
            if (IamJuice)
            {
                if (drinkManagerSc.GetComponent<drinkManager>().HasSthReady is false)
                {
                    drinkManagerSc.GetComponent<drinkManager>().sliderRight.SetActive(false);
                }
            }
        }
    }

    public void OnMouseDown()
    {
        if (drinkManagerSc.GetComponent<drinkManager>().HasSthReady is false)
        {
            if (drinkReady)
            {
                if (IamCoffee)
                {
                    drinkManagerSc.GetComponent<drinkManager>().cupLeft.SetActive(false);
                    drinkManagerSc.GetComponent<drinkManager>().HasReadyCoffee = true;
                    drinkManagerSc.GetComponent<drinkManager>().pouring1 = false;
                }
                if (IamSoda)
                {
                    drinkManagerSc.GetComponent<drinkManager>().cupMiddle.SetActive(false);
                    drinkManagerSc.GetComponent<drinkManager>().HasReadySoda = true;
                    drinkManagerSc.GetComponent<drinkManager>().pouring2 = false;
                }
                if (IamJuice)
                {
                    drinkManagerSc.GetComponent<drinkManager>().cupRight.SetActive(false);
                    drinkManagerSc.GetComponent<drinkManager>().HasReadyOJ = true;
                    drinkManagerSc.GetComponent<drinkManager>().pouring3 = false;
                }
                print("grabbedDrink");
                myDrink.SetActive(false);
                drinkReady = false;
                timePour.value = 0;
                takeDrink.Play();
            }
        }
    }

    public void DrinkPreparation()
    {
        StartCoroutine(PourDrink());
    }


    public IEnumerator PourDrink()
    {
        yield return new WaitForSeconds(1);
        timePour.value += 1;
        yield return new WaitForSeconds(1);
        timePour.value += 1;
        yield return new WaitForSeconds(1);
        timePour.value += 1;
        yield return new WaitForSeconds(1);
        timePour.value += 1;
        drinkReady = true;
    }


}
