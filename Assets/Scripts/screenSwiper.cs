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

    void Start()
    {
        if (blackScreen != null)
        {
            blackScreen.SetActive(true);
        }
        
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
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
        else
        {
            if (extraCase)
            {
                levelScript.GetComponent<levelOne>().FrancesDiner.ExecuteBlock("ExtraCom");
                extraCase = false;
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
