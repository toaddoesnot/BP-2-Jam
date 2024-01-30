using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightSwitch : MonoBehaviour
{
    public GameObject lightObj;
    public Image blackWall;

    public bool switcher;
    public AudioSource switchSound;

    // Update is called once per frame
    void Update()
    {
        if (switcher)
        {
            lightObj.SetActive(true);
            //blackWall.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            lightObj.SetActive(false);
            //blackWall.color = new Color32(75, 75, 75, 255); //92
        }
    }
}
