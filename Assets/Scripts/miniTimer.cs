using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class miniTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public Image uiFill;
    public int Duration;
    public int remainingDuration;

    public bool filled;
    public bool initiated;

    public bool amClock;
    public TimeManager timeSc;

    public int timerType; //0-normal, 1-clock, 2-cookers
    public float burntTime;

    public bool noTimer;

    void Awake()
    {
        if(timerType == 0)
        {
            burntTime = 6;
        }
    }

    public void InitiateTimer()
    {
        if (!noTimer)
        {
            Begin(Duration);
        }
    }

    private void Begin(int Second)
    {
        remainingDuration = Second;
        if (timerType == 0)
        {
            StopAllCoroutines();
            StopAnimation();
        }
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            filled = false;
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(0.1f);
            initiated = true;
        }
        if(remainingDuration < 0)
        {
            OnEnd();
        }
    }

    private void OnEnd()
    {
        filled = true;

        if (timerType == 1)
        {
            if(timeSc.timeOn == true)
            {
                remainingDuration = 0;
                filled = false;
                uiFill.fillAmount = 1;

                Begin(Duration);
            }
        }

        if(timerType != 1)
        {
            StartCoroutine(FoodBurn());
        }
    }

    IEnumerator FoodBurn()
    {
        yield return new WaitForSeconds(burntTime);
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        this.GetComponent<Animation>().Play("bouncyTimer");
    }

    public void StopAnimation()
    {
        this.GetComponent<Animation>().Stop("bouncyTimer");
        print("stop animation");
    }

    public void ResetTimer()
    {
        StopAllCoroutines();
        remainingDuration = 0;
        filled = false;
        uiFill.fillAmount = 1;//was one
        print("stopped resettedd");

        this.GetComponent<Animation>().Stop("bouncyTimer");

        print("hello darkness");
    }
}
