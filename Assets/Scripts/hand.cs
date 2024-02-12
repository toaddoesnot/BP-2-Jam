using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using TMPro;

public class hand : MonoBehaviour
{
    public int foodHave;

    public int toastFill;
    public int noodFill;
    public bool potatoInstead;
    public bool haveEgg;

    public bool haveOrder;

    public bool needInstruction;
    public bool doneInstruction;
    public Fungus.Flowchart myFlowchart;

    public int tutorialLvl; //0-all; 1-toasts; 2-toasts+soups; 3=toasts+soups+drinks;
    
    //public TextMeshProUGUI moneyText;
    //public int moneyAm;

    public int whichFlow;
    public dishwashingMachine dishSc;

    public int EmState;

    void Update()
    {
        //moneyText.SetText("$:", moneyAm);
        //moneyText.text = "$" + moneyAm.ToString();

        if (haveOrder is false)
        {
            foodHave = 4;
            toastFill = 4;
            noodFill = 4;
            potatoInstead = false;
            haveEgg = false;
        }
    }

    public void StartBlock()
    {
        if (needInstruction is true)
        {
            if (doneInstruction is false)
            {
                myFlowchart.ExecuteBlock("step1");
                doneInstruction = true;
            }
        }
    }
}
