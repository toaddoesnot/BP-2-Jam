using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class customerGenerator : MonoBehaviour
{
    //public GameObject[] todayCustomers;
    public GameObject[] customerSlots;

    public GameObject chosenCustomer;
    public GameObject chosenSeat;

    public TimeManager clockSc;

    public int randomCustomer;
    public int randSeat;

    //public float randomInterval;
    public bool weFull;
    public AudioSource doorOpen;
    public float howFast; //usually 15

    public void Start()
    {
        InvokeRepeating("GenerateCustomer", 8f, 20f); //10f 30 f
    }

    public void StartCustomers()
    {
        //InvokeRepeating("GenerateCustomer", 2f, howFast);
    }

    public void Update()
    {
        for(int i = 0; i < customerSlots.Length; i++)
        {
            if(customerSlots[i].GetComponent<characterSlot>().occupied == false)
            {
                randSeat = i;
            }
        }
        if (customerSlots[0].GetComponent<characterSlot>().occupied)
        {
            weFull = true;
        }
    }

    public void GenerateCustomer()
    {
        if (weFull is false && clockSc.timeOn)
        {
            randomCustomer = Random.Range(0, 3);
            //randomCustomer = 0; //for bear memes

            customerSlots[randSeat].GetComponent<characterSlot>().myPeep.GetComponent<Image>().sprite = customerSlots[randSeat].GetComponent<characterSlot>().guestSprites[randomCustomer];
            customerSlots[randSeat].GetComponent<characterSlot>().myPeep.SetActive(true);
            customerSlots[randSeat].GetComponent<characterSlot>().myGuest = randomCustomer;

            customerSlots[randSeat].GetComponent<characterSlot>().occupied = true;
            customerSlots[randSeat].GetComponent<characterSlot>().counting = true;
            customerSlots[randSeat].GetComponent<characterSlot>().currentState = 0;
            customerSlots[randSeat].GetComponent<characterSlot>().timey.SetActive(true);
            customerSlots[randSeat].GetComponent<characterSlot>().timerSc.InitiateTimer();
            //chosenCustomer = todayCustomers[randomCustomer];
            //Instantiate(chosenCustomer, chosenSeat.transform.position, Quaternion.identity, chosenSeat.transform);
            doorOpen.Play();
        }
    }
    //public stepsScript.gridIm.transform.position = refPos.transform.position;
}
