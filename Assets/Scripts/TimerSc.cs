using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerSc : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI timeText;
    public StartSc restartSc;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            restartSc.StartVoid();
        }

        DisplayTime(timeValue);
    }

    public void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
