using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class stableLevels : MonoBehaviour
{
    public Fungus.Flowchart Stable;
    public Button openSign;

    public GameObject blocker;
    public GameObject blocker2;

    public GameObject drinkRequest;
    public GameObject YuriObj;
    public GameObject RCobj;

    public bool gaveDrink;
    public GameObject screenBt;
    public GameObject newBear;

    public GameObject blackScreen;
    public AudioSource soundBg;

    public TextMeshProUGUI nodeText;
    private bool amOpen;

    public void DrinkTutorial()
    {
        if (!gaveDrink)
        {
            drinkRequest.SetActive(true);
        }
        else
        {
            drinkRequest.SetActive(false);
            blocker.SetActive(false);
            openSign.interactable = true;

            Stable.ExecuteBlock("afterServing");
        }
    }

    public void YuriEncounter()
    {
        Stable.ExecuteBlock("Yuri");
        blocker2.SetActive(true);
        screenBt.GetComponent<Button>().enabled = false;
        
        YuriObj.SetActive(true);
    }

    public void YuriLeaves()
    {
        YuriObj.GetComponent<Animation>().Play();
    }

    public void CustomerEncounter()
    {
        screenBt.GetComponent<Button>().enabled = true;
        screenBt.GetComponent<screenSwiper>().extraCase = true;
        newBear.SetActive(true);
    }

    public void YuriLeaves2()
    {
        YuriObj.SetActive(false);
        newBear.SetActive(false);
        RCobj.GetComponent<Animator>().Play("RC_out");
    }

    public void FinishLevel()
    {
        blackScreen.SetActive(true);
        soundBg.volume = 0.2f;
    }

    public void RemindToOpen()
    {
        

        if (!amOpen)
        {
            nodeText.text = "Let's open the diner!";
            amOpen = true;
        }
        else
        {
            nodeText.text = "";
        }
    }
}
