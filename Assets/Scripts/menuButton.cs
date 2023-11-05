using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menuButton : MonoBehaviour ////cash register script
{
    public GameObject menuPop;
    public bool menuOpen;

    public int moneyLeft;
    public TextMeshProUGUI moneyDisplay;

    public AudioSource closeSound;
    public AudioSource openSound;

    public cashText NumberCounter;
    public bool boughtSth;

    void Awake()
    {
        NumberCounter.Text.text = moneyLeft.ToString();
    }

    void Update()
    {
        moneyDisplay.text = "$" + moneyLeft.ToString();
    }

    public void OpenMenu()
    {
        boughtSth = false;

        closeSound.Play();

        menuOpen = true;
        menuPop.SetActive(true);
    }

    public void CloseMenu()
    {
        closeSound.Play();

        menuOpen = false;
        menuPop.SetActive(false);

        if (boughtSth)
        {
            SetValue();
        }
    }

    public void MainMenu()
    {

    }

    public void SetValue()
    {
        NumberCounter.Value = moneyLeft;
        
    }
}
