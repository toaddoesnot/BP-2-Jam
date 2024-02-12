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
    
    public bool introLevels;
    private bool FrancesDone;

    public float howFast; //usually 20

    public int EmState;
    
    public instructionalComments subtitleSc;
    public bool weEmpty; //only for level instrucitonal

    public void Start()
    {
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
    }

    public void Update()
    {
        bool allOccupied = true;

        for (int i = 0; i < customerSlots.Length; i++)
        {
            if (customerSlots[i].GetComponent<characterSlot>().occupied == false)
            {
                randSeat = i;
                allOccupied = false;
            }
        }
        weFull = allOccupied;

        if (!customerSlots[0].GetComponent<characterSlot>().occupied && !customerSlots[1].GetComponent<characterSlot>().occupied && !customerSlots[2].GetComponent<characterSlot>().occupied && !customerSlots[3].GetComponent<characterSlot>().occupied && !customerSlots[4].GetComponent<characterSlot>().occupied && !customerSlots[5].GetComponent<characterSlot>().occupied)
        {
            weEmpty = true;
        }
        else
        {
            weEmpty = false;
        }

        //{
        //    weFull = true;
        //}

        if (EmState == 0)
        {
            for (int i = 0; i < customerSlots.Length; i++)
            {
                if (customerSlots[i].GetComponent<characterSlot>().gaveManic == true)
                {
                    foreach (GameObject slot in customerSlots)
                    {
                        slot.GetComponent<characterSlot>().gaveManic = true;
                    }
                }
            }
        }
    }

    public void StartCustomers()
    {
        InvokeRepeating("GenerateCustomer", 10f, 25f);
    }

    public void DepressiveCustomers()
    {
        StartCoroutine(FirstCustomer());
        InvokeRepeating("GenerateCustomer", 20f, 50f);
    }

    public void ManicCustomers()
    {
        InvokeRepeating("GenerateCustomer", 4f, 12f);
    }

    public IEnumerator ManicEpisode()
    {
        yield return null;
        EmState = 2;

        InvokeRepeating("GenerateCustomer", 1f, 8f);
        string selfServe = "What if we let the guests sit themselves??";
        if (!subtitleSc.instComments.Contains(selfServe))
        {
            subtitleSc.instComments.Add(selfServe);
            subtitleSc.Subtitles();
        }
    }
    
    IEnumerator FirstCustomer()
    {
        yield return new WaitForSeconds(2f);
        GenerateCustomer();
    }

    public void Generator()
    {
        StartCoroutine(GenerateX());
    }

    IEnumerator GenerateX()
    {
        yield return null;
        GetComponent<hand>().tutorialLvl = 2;
        GenerateCustomer();

        yield return new WaitForSeconds(25f);
        GetComponent<hand>().tutorialLvl = 3;
        GenerateCustomer();

        yield return new WaitForSeconds(25f);
        GetComponent<hand>().tutorialLvl = 4;
        GenerateCustomer();
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
                if (!FrancesDone)
                {
                    customerSlots[randSeat].GetComponent<characterSlot>().eatingTime = 1f;
                    FrancesDone = true;
                }
            }
            
            customerSlots[randSeat].GetComponent<characterSlot>().myPeep.GetComponent<Image>().sprite = customerSlots[randSeat].GetComponent<characterSlot>().guestSprites[randomCustomer];
            customerSlots[randSeat].GetComponent<characterSlot>().myPeep.SetActive(true);
            customerSlots[randSeat].GetComponent<characterSlot>().myGuest = randomCustomer;

            customerSlots[randSeat].GetComponent<characterSlot>().occupied = true;
            customerSlots[randSeat].GetComponent<characterSlot>().counting = true;
            customerSlots[randSeat].GetComponent<characterSlot>().currentState = 0;

            customerSlots[randSeat].GetComponent<characterSlot>().mapCenter.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            customerSlots[randSeat].GetComponent<characterSlot>().mapAnimation.SetActive(true);

            doorOpen.Play();

            if (EmState == 2)
            {
                customerSlots[randSeat].GetComponent<characterSlot>().currentState++;

                customerSlots[randSeat].GetComponent<characterSlot>().StartCoroutine(customerSlots[randSeat].GetComponent<characterSlot>().Order());
            }
        }
           
    }
    //public stepsScript.gridIm.transform.position = refPos.transform.position;

    
    
}
