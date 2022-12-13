using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelChooser : MonoBehaviour
{
    //public GameObject[] filters;
    public GameObject[] screens;

    public int currentLvl;
    //public GameObject[] days;

    public Button[] buttons;
    public int levelsUnlocked;

    void Start()
    {
        

        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        currentLvl = levelsUnlocked -1;
        //filters[currentLvl].SetActive(false);

        foreach (Button but in buttons)
        {
            if (but.GetComponent<Button>().interactable is true)
            {
                Image image = but.GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = 0.1f;
                image.color = tempColor;
            }
        }

       if (currentLvl is 1)
        {
            screens[0].SetActive(true);
        }
        if (currentLvl is 2)
        {
            screens[0].SetActive(true);
            screens[1].SetActive(true);
        }
        if (currentLvl is 3)
        {
            screens[0].SetActive(true);
            screens[1].SetActive(true);
            screens[2].SetActive(true);
        }
        if (currentLvl is 4)
        {
            screens[0].SetActive(true);
            screens[1].SetActive(true);
            screens[2].SetActive(true);
            screens[3].SetActive(true);
        }
        if (currentLvl is 5)
        {
            screens[0].SetActive(true);
            screens[1].SetActive(true);
            screens[2].SetActive(true);
            screens[3].SetActive(true);
            screens[4].SetActive(true);
        }

        // foreach (GameObject day in days)
        //{
        //     day.GetComponent<Button>().interactable = false;
        //     days[currentLvl + 1].GetComponent<Button>().interactable = true;
        // }

        if (Input.GetKey("r"))
        {
            Debug.Log("poka");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(1);
        }
    }

    public void NewLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
