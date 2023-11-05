using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class piggyBank : MonoBehaviour
{
    public TextMeshProUGUI pigText;
    public int tipsTotal;

    void Update()
    {
        pigText.text = "$" + tipsTotal.ToString();
    }

    public void PlayAnimation()
    {
        GetComponent<Animation>().Play();
    }
}
