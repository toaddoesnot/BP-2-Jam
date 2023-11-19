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

    public bool introLevels;

    public void Start()
    {
        //InvokeRepeating("GenerateCustomer", 8f, 20f); //10f 30 f
    }

    public void StartCustomers()
    {
        InvokeRepeating("GenerateCustomer", 8f, 20f);
    }

    public void Generator()
    {
        StartCoroutine(GenerateX());
    }

    IEnumerator GenerateX()
    {
        yield return null;
        GenerateCustomer();

        yield return new WaitForSeconds(10f);
        GenerateCustomer();

        yield return new WaitForSeconds(12f);
        GenerateCustomer();
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
        if (weFull is false && clockSc.timeOn || introLevels)
        {
            if (!introLevels)
            {
                randomCustomer = Random.Range(0, 3);
                customerSlots[randSeat].GetComponent<characterSlot>().timey.SetActive(true);
                customerSlots[randSeat].GetComponent<characterSlot>().timerSc.InitiateTimer();
            }
            else
            {
                randomCustomer = 2;
                customerSlots[randSeat].GetComponent<characterSlot>().midTime = 200f;
                customerSlots[randSeat].GetComponent<characterSlot>().maxTime = 400f;
                customerSlots[randSeat].GetComponent<characterSlot>().eatingTime = 1f;
            }
            
            customerSlots[randSeat].GetComponent<characterSlot>().myPeep.GetComponent<Image>().sprite = customerSlots[randSeat].GetComponent<characterSlot>().guestSprites[randomCustomer];
            customerSlots[randSeat].GetComponent<characterSlot>().myPeep.SetActive(true);
            customerSlots[randSeat].GetComponent<characterSlot>().myGuest = randomCustomer;

            customerSlots[randSeat].GetComponent<characterSlot>().occupied = true;
            customerSlots[randSeat].GetComponent<characterSlot>().counting = true;
            customerSlots[randSeat].GetComponent<characterSlot>().currentState = 0;

            doorOpen.Play();
        }
           
    }
    //public stepsScript.gridIm.transform.position = refPos.transform.position;
}
