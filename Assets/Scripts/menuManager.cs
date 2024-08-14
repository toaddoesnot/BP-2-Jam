 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public bool menuLvl;

    public int levelsUnlocked;
    public int currentLvl;

    public Button[] buttons;
    public bool exception;
    public int trueLevels;

    public GameObject[] texts;

    public float idleTimer;
    public float respawnTime;

    public GameObject stars;
    public GameObject video;

    public void Start()
    {
        //PlayerPrefs.DeleteAll();

        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            //buttons[i].interactable = false; ////reenable
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            //buttons[i].interactable = true; ////reenable
        }
    }

    void Update()
    {
        currentLvl = levelsUnlocked - 1;

        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
        {
            idleTimer += Time.deltaTime;

            if (idleTimer > respawnTime)
            {
               // PlayVideo();
                //idleTimer = 0;
            }
        }
        else
        {
            idleTimer = 0;
            //stars.SetActive(true);
            //video.SetActive(false);
        }
    }

    public void PlayVideo()
    {
        SceneManager.LoadScene(6);
        //stars.SetActive(false);
        //video.SetActive(true);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    //MENU

    public void Load0()
    {
        SceneManager.LoadScene(1);
    }
    public void Load1()
    {
        SceneManager.LoadScene(2);
    }
    public void Load2()
    {
        SceneManager.LoadScene(3);
    }
    public void Load3()
    {
        SceneManager.LoadScene(4);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleException()
    {
        

        if (!exception)
        {
            trueLevels = levelsUnlocked;
            exception = true;
            levelsUnlocked = 4;
            foreach (Button but in buttons)
            {
                but.interactable = true;
            }
        }
        else
        {
            levelsUnlocked = trueLevels;
            foreach (Button but in buttons)
            {
                but.interactable = false;
            }
            for (int i = 0; i < levelsUnlocked; i++)
            {
                buttons[i].interactable = true;
            }
            exception = false;
        }
    }




}
