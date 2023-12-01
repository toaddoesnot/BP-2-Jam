using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sink : MonoBehaviour
{
    public int cleanups;
    public int secondLvl;
    public int thirdLvl;

    public Sprite[] sinkSprites;//0 empty 1 first level 2 second level 3 third level
    public bool requested;

    public Image sinkObj;
    public GameObject robot;

    public GameObject[] dishes;
    public bool anyDirty;
    public GameObject timerObj;

    public foodCart traySc;
    public dishwashingMachine dishSc;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject dish in dishes)
        {
            if(dish.activeSelf)
            {
                anyDirty = true;
                break;
            }
            else
            {
                anyDirty = false;
            }
        }

        if(cleanups == 0)
        {
            sinkObj.sprite = sinkSprites[0];
        }
        else
        {
            if (cleanups >= 0 && cleanups < secondLvl)
            {
                sinkObj.sprite = sinkSprites[1];
            }
            else
            {
                if (cleanups >= secondLvl && cleanups < thirdLvl)
                {
                    sinkObj.sprite = sinkSprites[2];
                }
                else
                {
                    sinkObj.sprite = sinkSprites[3];
                }
            }
            
        }
        
    }

    public void RequestCleanup()
    {
        if (!requested && cleanups != 0)
        {
            StartCoroutine(Cleaning());
            requested = true;
            traySc.canDrop = false;
        }
    }

    IEnumerator Cleaning()
    {
        yield return null;
        robot.GetComponent<Animator>().Play("RC_cleaning");

        timerObj.SetActive(true);
        timerObj.GetComponent<miniTimer>().InitiateTimer();

        yield return new WaitForSeconds(3f);

        timerObj.SetActive(false);
        traySc.canDrop = true;

        cleanups = 0;
        dishSc.recharges = dishSc.maxRecharges;
        dishSc.Replate();

        requested = false;
    }
}
