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

    public lightSwitch switchSc;
    public int emState;

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
            switchSc.switcher = false;
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
            switchSc.switcher = true;
        }
        
    }

    public void RequestCleanup()
    {
        if (!requested && cleanups != 0 && traySc.canDrop)
        {
            StartCoroutine(Cleaning());
            requested = true;
            traySc.canDrop = false;
        }
    }

    IEnumerator Cleaning()
    {
        yield return null;

        if(emState == 1)
        {
            robot.GetComponent<Animator>().Play("RC_cleaning_depr");

            timerObj.SetActive(true);
            timerObj.GetComponent<miniTimer>().InitiateTimer();

            yield return new WaitForSeconds(4f);
            timerObj.SetActive(false);
        }
        else
        {
            if (emState == 2)
            {
                robot.GetComponent<Animator>().Play("RC_cleaning");
            }
            else
            {
                robot.GetComponent<Animator>().Play("RC_cleaning");
                timerObj.SetActive(true);
                timerObj.GetComponent<miniTimer>().InitiateTimer();
            }
        }

        yield return new WaitForSeconds(3f);

        timerObj.SetActive(false);
        traySc.canDrop = true;

        cleanups = 0;
        dishSc.recharges = dishSc.maxRecharges;
        dishSc.Replate();

        requested = false;
    }
}
