using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelOne : MonoBehaviour
{
    public screenSwiper cameraScreen;
    public instructionalComments subtitleSc;

    public GameObject breakSound;

    public GameObject FrancesObj;
    public GameObject RcObj;

    [TextArea(5, 10)]
    public string[] strings;

    void Awake()
    {
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
        cameraScreen.ForcePress();
        StartCoroutine(Frances());
    }

    public IEnumerator Frances()
    {
        yield return new WaitForSeconds(26f); //27 overall
        breakSound.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2f);
        cameraScreen.blackScreen.SetActive(false);
        cameraScreen.self.GetComponent<Button>().enabled = true;
        cameraScreen.extraCase = true;
    }

    public void StartFrances()
    {
        FrancesObj.SetActive(true);
        subtitleSc.ChangePosition();

        StartCoroutine(FrancesInteractions());
    }

    IEnumerator FrancesInteractions()
    {
        yield return null;

        subtitleSc.instComments.Add(strings[0]);
        subtitleSc.instComments.Add(strings[1]);
        subtitleSc.Subtitles();

        yield return new WaitForSeconds(8f);

        RcObj.GetComponent<Animation>().Play("RC_out"); //rc-1000 rolls in
         //change sprite to the one facing left

        yield return new WaitForSeconds(4f);

        subtitleSc.instComments.Add(strings[2]);
        subtitleSc.instComments.Add(strings[3]);
        subtitleSc.Subtitles();
        subtitleSc.instBubble.GetComponent<Image>().sprite = subtitleSc.bubbles[1];

        yield return new WaitForSeconds(11.5f);

        subtitleSc.instComments.Add(strings[4]);
        subtitleSc.instComments.Add(strings[5]);
        subtitleSc.Subtitles();
        subtitleSc.instBubble.GetComponent<Image>().sprite = subtitleSc.bubbles[0];

        yield return new WaitForSeconds(10f);
        RcObj.GetComponent<Animation>().Play("RC_in");
        FrancesObj.SetActive(false);
        //then in another script spawn Frances on chair 1 and you can give her a menu, then go to the first screen and prepare food for her
    }
}
