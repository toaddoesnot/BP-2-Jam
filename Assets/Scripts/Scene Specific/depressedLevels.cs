using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class depressedLevels : MonoBehaviour
{
    public Button openSign;
    public GameObject blocker;
    public GameObject checkObj;
    public Fungus.Flowchart deprFlowchart;
    public GameObject francesObj;

    public screenSwiper swipeSc;

    public GameObject blankScreen;
    public GameObject blank1;
    public GameObject blank2;

    public AudioSource backGM;

    private bool active;

    public void CheckActive()
    {
        if (active)
        {
            checkObj.SetActive(false);
            active = false;
        }
        else
        {
            checkObj.SetActive(true);
            active = true;
        }
    }

    public void InitiateFrances()
    {
        backGM.volume = 0.4f;
        blocker.SetActive(true);

        francesObj.SetActive(true);
        deprFlowchart.ExecuteBlock("Frances");
    }

    public void StartDepression()
    {
        blocker.SetActive(false);
        openSign.interactable = true;
    }

    public void FinishGame()
    {
        blankScreen.SetActive(true);
        StartCoroutine(finishingGame());
    }

    IEnumerator finishingGame()
    {
        backGM.volume = 0f;

        yield return new WaitForSeconds(5f);
        blank2.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
