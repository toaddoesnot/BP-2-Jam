using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coaster : MonoBehaviour
{
    public GameObject myCup;
    public GameObject drinkInventory;

    public bool occupied;

    public bool hasCof;
    public bool hasSoda;
    public bool hasOJ;

    public AudioSource cupSound;

    public void OnMouseDown()
    {
        if (occupied is false)
        {
            if (drinkInventory.GetComponent<drinkManager>().HasSthReady is true)
            {
                myCup.SetActive(true);
                cupSound.Play();

                if (drinkInventory.GetComponent<drinkManager>().HasReadyCoffee is true)
                {
                    myCup.GetComponent<coasterCup>().layers[0].SetActive(true);
                    drinkInventory.GetComponent<drinkManager>().HasReadyCoffee = false;
                    hasCof = true;
                    occupied = true;
                }
                if (drinkInventory.GetComponent<drinkManager>().HasReadySoda is true)
                {
                    myCup.GetComponent<coasterCup>().layers[1].SetActive(true);
                    drinkInventory.GetComponent<drinkManager>().HasReadySoda = false;
                    hasSoda = true;
                    occupied = true;
                }
                if (drinkInventory.GetComponent<drinkManager>().HasReadyOJ is true)
                {
                    myCup.GetComponent<coasterCup>().layers[2].SetActive(true);
                    drinkInventory.GetComponent<drinkManager>().HasReadyOJ = false;
                    hasOJ = true;
                    occupied = true;
                }
                drinkInventory.GetComponent<drinkManager>().HasSthReady = false;
            }
        }
    }
}
