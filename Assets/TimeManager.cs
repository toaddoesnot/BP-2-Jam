using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;
    public float dayDuration = 120f;

    float totalTime = 0;
    public float currentTime = 0;

    public AudioSource clockSound;
    public bool doneNoon;

    public bool timeOn;
    public float maxTime;

    public bool needFloat;
    public bool doneFloat;
    public Fungus.Flowchart myFlowchart2;

    public void StartTime()
    {
        timeOn = true;
    }


    void Update()
    {
        if(timeOn is true)
        {
            totalTime += Time.deltaTime;
            currentTime = totalTime % dayDuration;
            //clockHandWTransform.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup * 90f);

            if (doneNoon is false)
            {
                if (currentTime >= 60f)
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
        myFlowchart2.ExecuteBlock("step2");
        timeOn = false;
    }
}
