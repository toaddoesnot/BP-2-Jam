using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public TimeManager managerSc;

    public float idleTimer;
    public float respawnTime;

    public hand handSc;
    public levelOne instLevels;

    public bool needRespawn;
    public int myScene;

    public depressedLevels deprSc;
    public stableLevels stabSc;
    public manicLevels manicSc;

    public sink sinkSc;
    public screenSwiper screenSc;
    public instructionalComments subtitleSc;
    public customerGenerator cg;

    void Start()
    {
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        cg = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<customerGenerator>();
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
    }

    void Update()
    {
        if (needRespawn)
        {
            if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
            {
                idleTimer += Time.deltaTime;

                if (idleTimer > respawnTime)
                {
                    Replay();
                    idleTimer = 0;
                }
            }
            else
            {
                idleTimer = 0;
            }


            if (managerSc.timeOn)
            {
               //PREV WAS HERE
            }
            else
            {
                //idleTimer = 0;
            }
        }
        
        
    }

    public void NewLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelsUnlocked") + "unlocked");
        SceneManager.LoadScene(myScene);
    }

    public void Replay()
    {
        if (handSc.tutorialLvl is 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            if (handSc.tutorialLvl is 100)
            {
                SceneManager.LoadScene(0); //for now sample scene
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        
        //
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StableEnd()
    {
        //
        if (sinkSc.cleanups == 0 && screenSc.onScreen == 0 && !sinkSc.anyDirty && cg.weEmpty)
        {
            stabSc.YuriEncounter();
            managerSc.closeSign.GetComponent<Button>().interactable = false;
        }
        else
        {
            string closeDiner = "Let's collect and wash the dishes first!";
            if (!subtitleSc.playing && !subtitleSc.instComments.Contains(closeDiner))
            {
                subtitleSc.instComments.Add(closeDiner);
                subtitleSc.Subtitles();
            }
        }
    }

    public void DepressiveEnd()
    {
        if (sinkSc.cleanups == 0 && screenSc.onScreen == 0 && !sinkSc.anyDirty && cg.weEmpty)
        {
            deprSc.InitiateFrances();
            managerSc.closeSign.GetComponent<Button>().interactable = false;
        }
        else
        {
            string closeDiner = "We still need to leave the diner clean... Relatively...";
            if (!subtitleSc.playing && !subtitleSc.instComments.Contains(closeDiner))
            {
                subtitleSc.instComments.Add(closeDiner);
                subtitleSc.Subtitles();
            }
        }
    }

    public void ManicEnd()
    {
        if (sinkSc.cleanups == 0 && screenSc.onScreen == 0 && !sinkSc.anyDirty && cg.weEmpty)
        {
            manicSc.FinishLevel();
            managerSc.closeSign.GetComponent<Button>().interactable = false;
        }
        else
        {
            string closeDiner = "I don't want to close!! Let's serve more customers.";
            if (!subtitleSc.playing && !subtitleSc.instComments.Contains(closeDiner))
            {
                subtitleSc.instComments.Add(closeDiner);
                subtitleSc.Subtitles();
            }
        }
    }
}
