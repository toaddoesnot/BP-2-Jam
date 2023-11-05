using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenSwiper : MonoBehaviour
{
    public int onScreen;

    public GameObject cameraObj;
    public GameObject camL;
    public GameObject camR;

    public Sprite room1;
    public Sprite room2;

    public GameObject exclamation;
    public GameObject[] notes;
    public bool sthActive;

    //EVENTS
    public bool addMoney;
    public GameObject cashR;
    public menuButton menuSc;
    public piggyBank tipSc;

    void Update()
    {
        if (notes[0].activeInHierarchy || notes[1].activeInHierarchy || notes[2].activeInHierarchy || notes[3].activeInHierarchy || notes[4].activeInHierarchy || notes[5].activeInHierarchy)
        {
            sthActive = true;
        }
        else
        {
            sthActive = false;
        }

        if (sthActive)
        {
            exclamation.SetActive(true);
        }
        else
        {
            exclamation.SetActive(false);
        }
    }

    public void PressButton()
    {
        if (onScreen == 0)
        {
            cameraObj.transform.localPosition = camL.transform.localPosition;
            this.GetComponent<Image>().sprite = room2;
            onScreen = 1;
            addMoney = false;
        }
        else
        {
            cameraObj.transform.localPosition = camR.transform.localPosition;
            this.GetComponent<Image>().sprite = room1;
            onScreen = 0;

            if (addMoney)
            {
                PaymentAnim();
            }
        }
    }

    public void PaymentAnim()
    {
        cashR.GetComponent<AudioSource>().Play();

        menuSc.SetValue();
        tipSc.PlayAnimation();
    }

    
}
