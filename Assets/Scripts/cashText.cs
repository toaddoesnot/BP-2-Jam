using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class cashText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public int CountFPS = 30;
    public float Duration = 3f;
    public string NumberFormat = "N0";
    private int _value;

    public Sprite[] cashSprites;
    public GameObject butt;

    void Start()
    {
        InvokeRepeating("cashAnimation", 2f, 18f);
    }

    void cashAnimation()
    {
        StartCoroutine(cashAnimating());
    }

    public IEnumerator cashAnimating()
    {
        yield return new WaitForSeconds(0f);
        GetComponent<Image>().sprite = cashSprites[1];
        butt.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Text.faceColor = new Color32(255, 255, 255, 0); 

        yield return new WaitForSeconds(1f);
        GetComponent<Image>().sprite = cashSprites[0];
        butt.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        Text.GetComponent<TextMeshProUGUI>().faceColor = new Color32(255, 255, 255, 255);

        print("shownAnimation");
    }

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            UpdateText(value);
            _value = value;
        }
    }

    private Coroutine CountingCoroutine;

    private void UpdateText(int newValue)
    {
        if (CountingCoroutine != null)
        {
            StopCoroutine(CountingCoroutine);
        }

        CountingCoroutine = StartCoroutine(CountText(newValue));
    }

    private IEnumerator CountText(int newValue)
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
        int previousValue = _value;
        int stepAmount;

        if (newValue - previousValue < 0)
        {
            stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration)); // newValue = -20, previousValue = 0. CountFPS = 30, and Duration = 1; (-20- 0) / (30*1) // -0.66667 (ceiltoint)-> 0
        }
        else
        {
            stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration)); // newValue = 20, previousValue = 0. CountFPS = 30, and Duration = 1; (20- 0) / (30*1) // 0.66667 (floortoint)-> 0
        }

        if (previousValue < newValue)
        {
            while (previousValue < newValue)
            {
                previousValue += stepAmount;
                if (previousValue > newValue)
                {
                    previousValue = newValue;
                }

                Text.SetText(previousValue.ToString(NumberFormat));

                yield return Wait;
            }
        }
        else
        {
            while (previousValue > newValue)
            {
                previousValue += stepAmount; // (-20 - 0) / (30 * 1) = -0.66667 -> -1              0 + -1 = -1
                if (previousValue < newValue)
                {
                    previousValue = newValue;
                }

                Text.SetText(previousValue.ToString(NumberFormat));

                yield return Wait;
            }
        }
    }


}
