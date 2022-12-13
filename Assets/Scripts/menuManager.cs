using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public bool menuLvl;

    public bool pauseOpen;
    public GameObject pauseMenu;

    public void Start()
    {
        
    }

    void Update()
    {
        if (menuLvl)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        Debug.Log(Time.time);
        if (menuLvl is false)
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    if (pauseOpen is false)
            //    {
                   // pauseMenu.SetActive(true);
                   // pauseOpen = true;
                   // Time.timeScale = 0;
             //   }
             //   Debug.Log("esc");
            //}
        }
    }

    //PAUSE

    public void ContinueGame()
    {
       // Time.timeScale = 1;
       // pauseMenu.SetActive(false);
       // pauseOpen = false;
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    //MENU

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
