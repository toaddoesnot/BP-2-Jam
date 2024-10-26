using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class guestsBehavior : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] stoves;

    public TimeManager timeSc;
    public Fungus.Flowchart GuestChooser;
    public GameObject blocker;

    private bool doneFlow;


    // Update is called once per frame
    void Update()
    {
        
        if (!doneFlow)
        {
            if (timeSc.doneFloat)
            {
                foreach(GameObject slot in slots)
                {
                    if (slot.GetComponent<characterSlot>().occupied == true)
                    {
                        slot.GetComponent<characterSlot>().timerSc.PauseTimer(); /// UnpauseTimer()
                        slot.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().PauseTimer();

                    }
                } 

                foreach (GameObject stove in stoves)
                {
                    if (stove.GetComponent<KitchenwareClicked>().HasItem == true)
                    {
                        stove.GetComponent<KitchenwareClicked>().myObject.GetComponent<Cookers>().timerObj.GetComponent<miniTimer>().PauseTimer();
                    }
                }

                blocker.SetActive(true);
                StartCoroutine(SpaceForStop());
                doneFlow = true;

            }
        }
    }

    IEnumerator SpaceForStop()
    {
        yield return new WaitForSeconds(3f);

        GuestChooser.ExecuteBlock("overChoice");

    }



    public void Overstay()
    {
        foreach (GameObject slot in slots)
        {
            if (slot.GetComponent<characterSlot>().occupied == true)
            {
                slot.GetComponent<characterSlot>().timerSc.UnpauseTimer();
                slot.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().UnpauseTimer();

                slot.GetComponent<characterSlot>().chosenBeh = 1;
            }
        }
        foreach (GameObject stove in stoves)
        {
            if (stove.GetComponent<KitchenwareClicked>().HasItem == true)
            {
                stove.GetComponent<KitchenwareClicked>().myObject.GetComponent<Cookers>().timerObj.GetComponent<miniTimer>().PauseTimer();
            }
        }

        blocker.SetActive(false);
    }

    public void NoOverstay()
    {
        foreach (GameObject slot in slots)
        {
            if (slot.GetComponent<characterSlot>().occupied == true)
            {
                slot.GetComponent<characterSlot>().timerSc.UnpauseTimer();
                slot.GetComponent<characterSlot>().myNewTimer.GetComponent<miniTimer>().UnpauseTimer();

                slot.GetComponent<characterSlot>().chosenBeh = 2;
            }
        }
        foreach (GameObject stove in stoves)
        {
            if (stove.GetComponent<KitchenwareClicked>().HasItem == true)
            {
                stove.GetComponent<KitchenwareClicked>().myObject.GetComponent<Cookers>().timerObj.GetComponent<miniTimer>().UnpauseTimer();
            }
        }

        blocker.SetActive(false);
    }
}
