using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;
    public float dayDuration = 300f;

    float totalTime = 0;
    public float currentTime = 0;

    public AudioSource clockSound;
    public bool doneNoon;

    public bool timeOn;
    public float maxTime;

    public bool needFloat;
    public bool doneFloat;
    public Fungus.Flowchart myFlowchart2;

    public GameObject closeSign;
    public Sprite closed1;
    public Sprite closed2;

    public GameObject openSign;
    public miniTimer timerSc;

    public instructionalComments subtitleSc;
    public bool needTip;
    public customerGenerator cg;
    public hand handSc;

    public Sprite[] extraClocks;
    public int emotSt;
    public Image clockIm;

    void Start()
    {
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        cg = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<customerGenerator>();

        if (needTip)
        {
            InvokeRepeating("openTip", 2f, 10f);
        }
        
    }

    void openTip()
    {
        string openDiner = "Click on the sign to open the diner";
        if (!subtitleSc.instComments.Contains(openDiner))
        {
            subtitleSc.instComments.Add(openDiner);
            subtitleSc.Subtitles();
        }
    }

    void Update()
    {
        if (timeOn is true)
        {
           totalTime += Time.deltaTime;
            currentTime = totalTime % dayDuration;
            //clockHandWTransform.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup * 90f);

            if (doneNoon is false)
            {
                if (currentTime >= 150f)
                {
                    clockSound.Play();
                    doneNoon = true;

                }
            }

            if (currentTime >= maxTime)
            {
                if (doneFloat is false)
                {
                    //Scene scene = SceneManager.GetActiveScene();
                    //SceneManager.LoadScene(scene.name);
                    FinishTime();
                    doneFloat = true;
                }
            }

            if (emotSt == 1)
            {
                if (currentTime >= 81f && currentTime < 90f)
                {
                    clockIm.sprite = extraClocks[0];
                }
                else
                {
                    if (currentTime >= 90f)
                    {
                        clockIm.sprite = extraClocks[1];
                    }
                }
            }
        }
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return currentTime * hoursInDay * minutesInHour / dayDuration % minutesInHour;
    }

    public void FinishTime()
    {
        timeOn = false;
        closeSign.GetComponent<Button>().enabled = true;
        closeSign.GetComponent<Image>().sprite = closed2;
        //myFlowchart2.ExecuteBlock("step2");
    }

    public void OpenDiner()
    {
        timeOn = true;
        CancelInvoke("openTip");

        timerSc.InitiateTimer();///////////
        openSign.SetActive(false);

        closeSign.SetActive(true);
        closeSign.GetComponent<Button>().enabled = false;
        closeSign.GetComponent<Image>().sprite = closed1;

        if (handSc.tutorialLvl != 1)
        {
            cg.StartCustomers();
        }
            
    }

    public void OpenWithoutTime()
    {
        openSign.SetActive(false);

        closeSign.SetActive(true);
        closeSign.GetComponent<Button>().enabled = false;
        closeSign.GetComponent<Image>().sprite = closed1;
    }
}
