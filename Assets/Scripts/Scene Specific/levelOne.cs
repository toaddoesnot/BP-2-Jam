using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.SceneManagement;

public class levelOne : MonoBehaviour
{
    public screenSwiper cameraScreen;
    public instructionalComments subtitleSc;

    public GameObject FrancesObj;
    public GameObject RcObj;

    [TextArea(5, 10)]
    public string[] strings;

    public customerGenerator customerScript;
    public GameObject secondBlack;

    public TimeManager timeSc;
    private bool times = false;

    public Fungus.Flowchart FrancesDiner;

    public int FrancesStates;
    public GameObject blocker;

    public foodCart foodSc; //dishesServed == 4
    public sink sinkSc;
    public screenSwiper screenSc;

    private bool done;
    private bool done2;

    public GameObject eepyRC;
    public GameObject[] lids;
    public AudioSource lidSound;
    public GameObject blackScreen;

    public int tutPhase;
    public AudioSource bgSound;
    public bool allEmpty;

    void Update()
    {


        if (foodSc.dishesServed == 4)
        {
            if (!done)
            {
                Ready2Close();
                done = true;
            }
        }
        if (done)
        {
            if (sinkSc.cleanups == 0 && screenSc.onScreen == 0 && !sinkSc.anyDirty && customerScript.weEmpty)
            {
                if (!done2)
                {
                    StartCoroutine(ClosingDiner2());
                    done2 = true;
                }
            }
        }

        if (tutPhase == 1)
        {
            lids[1].SetActive(false);
        }
        if (tutPhase == 2)
        {
            lids[4].SetActive(false);
        }
        if (tutPhase == 3)
        {
            lids[7].SetActive(false);
        }
        if (tutPhase == 4)
        {
            lids[8].SetActive(false);
        }
        if (tutPhase == 5)
        {
            lids[0].SetActive(false);
        }
        if (tutPhase == 6)
        {
            lids[3].SetActive(false);
        }
        if (tutPhase == 7)
        {
            lids[6].SetActive(false); //shroom
        }
        if (tutPhase == 8)
        {
            lids[2].SetActive(false); //potato
        }
        if (tutPhase == 9)
        {
            lids[5].SetActive(false); //egg
        }
    }

    void Awake()
    {
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
        cameraScreen.ForcePress();
    }

    public void StopEeping()
    {
        eepyRC.SetActive(false);
    }

    public void BreakIn()
    {
        cameraScreen.blackScreen.SetActive(false);
        cameraScreen.self.GetComponent<Button>().enabled = true;
        cameraScreen.extraCase = true;
    }

    public void Frances()
    {
        if(FrancesStates == 0) //screen swiper starts it
        {
            FrancesObj.SetActive(true);
            cameraScreen.self.GetComponent<Button>().enabled = false;
            FrancesDiner.ExecuteBlock("Second");

            FrancesStates = 1;
        }
        else
        {
            if (FrancesStates == 1) //flowchart 2 starts it
            {
                FrancesObj.SetActive(false);
                customerScript.introLevels = true;
                customerScript.GenerateCustomer();

                print("a lid");

                cameraScreen.self.GetComponent<Button>().enabled = true;

                FrancesStates = 2;
            }
            else
            {
                if (FrancesStates == 2)
                {
                    cameraScreen.self.GetComponent<Button>().enabled = false;
                    secondBlack.SetActive(true);
                    blocker.SetActive(true);
                    StartCoroutine(FinishFrances());
                    FrancesDiner.ExecuteBlock("Third");

                    FrancesStates = 3;
                }
                else
                {
                    if (FrancesStates == 3)
                    {
                        FrancesObj.SetActive(false);
                        timeSc.OpenWithoutTime();
                        customerScript.Generator();
                        blocker.SetActive(false);

                        cameraScreen.self.GetComponent<Button>().enabled = true;
                    }
                }
            }
        }
    }

    public IEnumerator FinishFrances()
    {
        yield return new WaitForSeconds(2f);
        FrancesObj.SetActive(true);
        FrancesObj.transform.localPosition = new Vector3(-1466.85f, FrancesObj.transform.localPosition.y, FrancesObj.transform.localPosition.z);
        secondBlack.SetActive(false);
    }

    public void Ready2Close()
    {
        if (!times)
        {
            StartCoroutine(ClosingDiner());
            times = true;
        }
        else
        {
            timeSc.openSign.SetActive(false);
            timeSc.closeSign.SetActive(true);
        }
    }

    IEnumerator ClosingDiner()
    {
        yield return new WaitForSeconds(3f);
        FrancesDiner.ExecuteBlock("beforeclosing");
        InvokeRepeating("RepeatInstructions", 10f, 10f);
    }

    void RepeatInstructions()
    {
        string closeDiner = "Collect all the dishes and tell me when to wash them. Then we should be ready!";
        if (!subtitleSc.playing && !subtitleSc.instComments.Contains(closeDiner))
        {
            subtitleSc.instComments.Add(closeDiner);
            subtitleSc.Subtitles();
        }
    }

    IEnumerator ClosingDiner2()
    {
        yield return null;
        CancelInvoke();
        FrancesDiner.ExecuteBlock("closing");
    }

    public void CabinReturn()
    {
        SceneManager.LoadScene(0);
    }

    public void FinishLevel()
    {
        blackScreen.SetActive(true);
        bgSound.volume = 0.2f;
    }
}
