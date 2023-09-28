using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public TimeManager tm;

    public Transform minuteHand;
    public Transform hourHand;

    const float hoursToDegree = 360 / 12, minutesToDegrees = 360 / 60;

    public miniTimer timerSc;

    void Start()
    {
        tm = this.GetComponent<TimeManager>();
        timerSc.InitiateTimer();
    }

    void Update()
    {
        hourHand.rotation = Quaternion.Euler(0, 0, -tm.GetHour() * hoursToDegree);
        minuteHand.rotation = Quaternion.Euler(0, 0, -tm.GetMinutes() * minutesToDegrees);


    }


}
