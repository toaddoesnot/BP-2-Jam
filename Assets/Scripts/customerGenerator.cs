using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class customerGenerator : MonoBehaviour
{
    public GameObject[] todayCustomers;
    public GameObject[] customerSlots;

    public GameObject chosenCustomer;
    public GameObject chosenSeat;

    public TimeManager clockSc;

    public int randomCustomer;
    //public float randomInterval;
    public bool weFull;

    public AudioSource doorOpen;

    public float howFast;


    public void Start()
    {
        InvokeRepeating("GenerateCustomer", 2f, 15.0f);
    }

    public void StartCustomers()
    {
        InvokeRepeating("GenerateCustomer", 2f, howFast);
    }



    public void Update()
    {

        if (customerSlots[0].GetComponent<characterSlot>().occupied is false)
        {
            chosenSeat = customerSlots[0];
            weFull = false;
        }
        else
        {
            if (customerSlots[1].GetComponent<characterSlot>().occupied is false)
            {
                chosenSeat = customerSlots[1];
                weFull = false;
            }
            else
            {
                if (customerSlots[2].GetComponent<characterSlot>().occupied is false)
                {
                    chosenSeat = customerSlots[2];
                    weFull = false;
                }
                else
                {
                    if (customerSlots[3].GetComponent<characterSlot>().occupied is false)
                    {
                        chosenSeat = customerSlots[3];
                        weFull = false;
                    }
                    else
                    {
                        weFull = true;
                    }
                }
            }
        }

    }

    public void GenerateCustomer()
    {
        if (weFull is false && clockSc.timeOn)
        {
            randomCustomer = Random.Range(0, 3);
            chosenCustomer = todayCustomers[randomCustomer];
            Instantiate(chosenCustomer, chosenSeat.transform.position, Quaternion.identity, chosenSeat.transform);
            doorOpen.Play();
        }
    }
    //public stepsScript.gridIm.transform.position = refPos.transform.position;
    

}
