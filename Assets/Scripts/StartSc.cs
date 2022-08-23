using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSc : MonoBehaviour
{
    public GameObject screenPic;
    public TimerSc timerSc;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

    }

    public void StartScreen()
    {
        screenPic.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartVoid()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartButton()
    {
        screenPic.SetActive(false);
        Time.timeScale = 1;
    }
}
