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
    public CursorChanger cursorSc;
    public instructionalComments subtitleSc;

    public GameObject stoveUp;
    public GameObject stoveDown;

    public int stateEm;
    public piggyBank pigSc;

    public bool mouseHovering;
    public float timeOpen;

    void Awake()
    {
        NumberCounter.Text.text = moneyLeft.ToString();
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
    }

    void OnMouseOver()
    {
        if (menuOpen)
        {
            mouseHovering = true;
        }
        
    }
    void OnMouseExit()
    {
        mouseHovering = false;
    }

    void Update()
    {
        if(stateEm == 0 || stateEm == 1)
        {
            moneyDisplay.text = "$" + moneyLeft.ToString();
        }

        if (menuOpen)
        {
            if (!mouseHovering)
            {
                timeOpen += Time.deltaTime;
                if (timeOpen > 6f)
                {
                    CloseMenu();
                }
            }
        }

        

    }

    public void OpenMenu()
    {
        // IF CURSOR IS OK
        if (menuOpen)
        {
            //CloseMenu();
            closeSound.Play();
            timeOpen = 0;

            menuOpen = false;
            menuPop.SetActive(false);

            if (stoveUp.GetComponent<KitchenwareClicked>().myObject != null)
            {
                stoveUp.GetComponent<KitchenwareClicked>().myObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
            if (stoveDown.GetComponent<KitchenwareClicked>().myObject != null)
            {
                stoveDown.GetComponent<KitchenwareClicked>().myObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }
        else
        {
            if (cursorSc.nothingSelected)
            {
                boughtSth = false;

                closeSound.Play();

                menuOpen = true;
                menuPop.SetActive(true);

                if (stoveUp.GetComponent<KitchenwareClicked>().myObject != null)
                {
                    stoveUp.GetComponent<KitchenwareClicked>().myObject.GetComponent<PolygonCollider2D>().enabled = false;
                }
                if (stoveDown.GetComponent<KitchenwareClicked>().myObject != null)
                {
                    stoveDown.GetComponent<KitchenwareClicked>().myObject.GetComponent<PolygonCollider2D>().enabled = false;
                }
            }
            else
            {
                string hands = "Please touch the register with empty hands.";
                if (!subtitleSc.instComments.Contains(hands))
                {
                    subtitleSc.instComments.Add(hands);
                    subtitleSc.Subtitles();
                }
            }
        }
        
    }

    public void CloseMenu()
    {
        closeSound.Play();
        timeOpen = 0;

        menuOpen = false;
        menuPop.SetActive(false);

        //if bought sth set value

        if (stoveUp.GetComponent<KitchenwareClicked>().myObject != null)
        {
            stoveUp.GetComponent<KitchenwareClicked>().myObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        if (stoveDown.GetComponent<KitchenwareClicked>().myObject != null)
        {
            stoveDown.GetComponent<KitchenwareClicked>().myObject.GetComponent<PolygonCollider2D>().enabled = true;
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
