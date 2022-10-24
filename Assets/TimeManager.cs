using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;
    public float dayDuration = 120f;

    float totalTime = 0;
    public float currentTime = 0;

    public AudioSource clockSound;
    public bool doneNoon;

    void Update()
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
            
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return currentTime * hoursInDay * minutesInHour / dayDuration % minutesInHour;
    }
}
