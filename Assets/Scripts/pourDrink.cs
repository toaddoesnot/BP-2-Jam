using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pourDrink : MonoBehaviour
{
    public bool isPressed;
    public bool filled;

    public GameObject cupPart1;
    public GameObject cupPart2;

    public coaster myCoaster;
    public cupOfDrink myCup;
    
    public float m_Speed;

    void Update()
    {
        if (isPressed)
        {
            cupPart1.SetActive(true);
            cupPart2.SetActive(true);
            myCup.GetComponent<RectMask2D>().padding += new Vector4(0, 0, 0, -1) * m_Speed;
        }
        else
        {
            cupPart1.SetActive(false);
            cupPart2.SetActive(false);
        }

        if (myCup.GetComponent<RectMask2D>().padding.w <= 10)
        {
            filled = true;
            isPressed = false;
            myCup.drinkReady = true;
        }
        
    }

    void OnMouseDown()
    {
        if (myCoaster.occupied && !filled)
        {
            isPressed = true;
            this.GetComponent<AudioSource>().Play();
        }
    }
    void OnMouseUp()
    {
        isPressed = false;
    }

    public void ResetPadding()
    {
        myCup.GetComponent<RectMask2D>().padding = new Vector4(0, 0, 0, 175);
    }

    public void SetPadding()
    {
        myCup.GetComponent<RectMask2D>().padding = new Vector4(0, 0, 0, 0);
    }
}
