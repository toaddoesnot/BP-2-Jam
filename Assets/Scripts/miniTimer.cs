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

    public void InitiateTimer()
    {
        Begin(Duration);
    }

    private void Begin(int Second)
    {
        remainingDuration = Second;
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
        if (amClock)
        {
            if(timeSc.timeOn == true)
            {
                remainingDuration = 0;
                filled = false;
                uiFill.fillAmount = 1;

                Begin(Duration);
            }
        }
        else
        {
            this.GetComponent<Animation>().Play("bouncyTimer");
        }
    }

    public void ResetTimer()
    {
        remainingDuration = 0;
        filled = false;
        uiFill.fillAmount = 1;
        this.GetComponent<Animation>().Stop();
    }
}
