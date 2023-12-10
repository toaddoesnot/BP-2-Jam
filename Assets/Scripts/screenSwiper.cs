using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenSwiper : MonoBehaviour
{
    public int onScreen;

    public GameObject cameraObj;
    public GameObject camL;
    public GameObject camR;

    public Sprite room1;
    public Sprite room2;

    public GameObject exclamation;
    public GameObject[] notes;
    public bool sthActive;

    //EVENTS
    public bool addMoney;
    public GameObject cashR;
    public menuButton menuSc;
    public piggyBank tipSc;

    public float transitionDuration;
    public instructionalComments subtitleSc;
    public bool extraCase;
    public GameObject self;

    public GameObject music;
    public GameObject blackScreen;
    public GameObject levelScript;
    public GameObject blocker;

    private FoodClasses foodSc;
    private hand handSc;
    private Inventory inventory;

    void Start()
    {
        
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
        foodSc = GameObject.FindGameObjectWithTag("Inventory").GetComponent<FoodClasses>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

        if (handSc.tutorialLvl is 1 && blackScreen != null)
        {
            blackScreen.SetActive(true);
        }

        self = this.gameObject;
    }

    void Update()
    {
        if (notes[0].activeInHierarchy || notes[1].activeInHierarchy || notes[2].activeInHierarchy || notes[3].activeInHierarchy || notes[4].activeInHierarchy || notes[5].activeInHierarchy || extraCase)
        {
            sthActive = true;
        }
        else
        {
            sthActive = false;
        }

        if (sthActive)
        {
            exclamation.SetActive(true);
        }
        else
        {
            exclamation.SetActive(false);
        }
    }

    public void PressButton()
    {
        if (onScreen == 0)
        {
            if (foodSc.currentFoods == -1 && !handSc.haveOrder && !inventory.sthCooked)
            {
                if (extraCase)
                {
                    music.GetComponent<AudioSource>().Play();
                    levelScript.GetComponent<levelOne>().Frances();
                }

                cameraObj.transform.localPosition = camL.transform.localPosition;
                this.GetComponent<Image>().sprite = room2;
                onScreen = 1;
                addMoney = false;
            }

            if (handSc.haveOrder)
            {
                string tray = "I'll get it, just put in on the conveyor belt!";
                if (!subtitleSc.instComments.Contains(tray))
                {
                    subtitleSc.instComments.Add(tray);
                    subtitleSc.Subtitles();
                }
            }
        }
        else
        {
            if (extraCase)
            {
                levelScript.GetComponent<levelOne>().FrancesDiner.ExecuteBlock("ExtraCom");
                extraCase = false;
                StartCoroutine(unblock());
            }

            cameraObj.transform.localPosition = camR.transform.localPosition;
            this.GetComponent<Image>().sprite = room1;
            onScreen = 0;

            if (addMoney)
            {
                PaymentAnim();
            }
        }
    }

    IEnumerator unblock()
    {
        yield return new WaitForSeconds(2f);
        blocker.SetActive(false);
    }

    public void PaymentAnim()
    {
        cashR.GetComponent<AudioSource>().Play();

        menuSc.SetValue();
        tipSc.PlayAnimation();
    }

    public void ForcePress()
    {
        cameraObj.transform.localPosition = camL.transform.localPosition;
        this.GetComponent<Image>().sprite = room1;
        this.GetComponent<Button>().enabled = false;

        StartCoroutine(MoveCamera(camR.transform.localPosition));
    }

    private IEnumerator MoveCamera(Vector3 targetPosition) //from right to left
    {
        yield return null;
        blackScreen.GetComponent<Animation>().Play();

        yield return 2f;

        Vector3 startPosition = cameraObj.transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            cameraObj.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraObj.transform.localPosition = targetPosition;
    }

}
