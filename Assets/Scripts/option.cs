using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class option : MonoBehaviour
{
    public int myNo;
    private instructionalComments subtitleSc;

    public string shortResponse;
    public string fullResponse;
    public string reaction;

    public TextMeshProUGUI myText; 
    public hand handSc;

    public GameObject levelConditions;

    void Awake()
    {
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        myText.text = shortResponse.ToString();
    }

    public void ChooseMe()
    {
        subtitleSc.instComments.Add(fullResponse);
        subtitleSc.instComments.Add(reaction);

        if (handSc.tutorialLvl is 1)
        {
            //levelConditions.GetComponent<levelOne>().FinishFrances2();
            print("not my fault at least");
        }
        subtitleSc.Subtitles();
        subtitleSc.choicesGroup.GetComponent<Animation>().Play("startBranch");
        
    }
}
