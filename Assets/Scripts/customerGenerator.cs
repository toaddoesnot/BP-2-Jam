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

    public int randomCustomer;
    //public float randomInterval;
    public bool weFull;

    public AudioSource doorOpen;

    public void Start()
    {
        InvokeRepeating("GenerateCustomer", 2f, 5.0f);
    }

    public void Update()
    {

        if (customerSlots[0].GetComponent<characterSlot>().occupied is false)
        {
            chosenSeat = customerSlots[0];
        }
        else
        {
            if (customerSlots[1].GetComponent<characterSlot>().occupied is false)
            {
                chosenSeat = customerSlots[1];
            }
            else
            {
                if (customerSlots[2].GetComponent<characterSlot>().occupied is false)
                {
                    chosenSeat = customerSlots[2];
                }
                else
                {
                    if (customerSlots[3].GetComponent<characterSlot>().occupied is false)
                    {
                        chosenSeat = customerSlots[3];
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
        if (weFull is false)
        {
            randomCustomer = Random.Range(0, 3);
            chosenCustomer = todayCustomers[randomCustomer];
            Instantiate(chosenCustomer, chosenSeat.transform.position, Quaternion.identity);
            doorOpen.Play();
        }
    }
    //public stepsScript.gridIm.transform.position = refPos.transform.position;
    

}
