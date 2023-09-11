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

    public void PressButton()
    {
        if (onScreen == 0)
        {
            cameraObj.transform.localPosition = camL.transform.localPosition;
            this.GetComponent<Image>().sprite = room2;
            onScreen = 1;
        }
        else
        {
            cameraObj.transform.localPosition = camR.transform.localPosition;
            this.GetComponent<Image>().sprite = room1;
            onScreen = 0;
        }
    }
}
