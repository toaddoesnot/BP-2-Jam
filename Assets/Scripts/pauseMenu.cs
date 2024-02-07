using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject textThingy;
    public GameObject confirmBut;
    public GameObject pauseBut;

    public bool paused;

    public Sprite pauseSpr;
    public Sprite playSpr;

    public GameObject blocker;

    public void PauseGame()
    {
        if (!paused)
        {
            textThingy.GetComponent<Animation>().Play("pauseMenu");
            pauseBut.GetComponent<Button>().enabled = false;
            pauseBut.GetComponent<Image>().sprite = playSpr;
            blocker.SetActive(true);
            StartCoroutine(Confirming());
        }
        else
        {
            Time.timeScale = 1; //unstop time

            blocker.SetActive(false);
            confirmBut.SetActive(false);
            textThingy.GetComponent<Animation>().Play("unpauseMenu");
            pauseBut.GetComponent<Image>().sprite = pauseSpr;
            paused = false;
        }
    }

    IEnumerator Confirming()
    {
        yield return new WaitForSeconds(0.65f);
        confirmBut.SetActive(true);
        pauseBut.GetComponent<Button>().enabled = true;
        paused = true;
        Time.timeScale = 0; //stop time
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
