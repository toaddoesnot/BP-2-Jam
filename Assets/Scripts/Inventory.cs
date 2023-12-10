using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public bool ToastCooked;
    public bool SpaghettiCooked;
    public bool EggCooked;
    public bool PotatoCooked;

    public bool sthCooked;
    public bool sthBurnt;

    public bool havePlate;

    public int HowManyOrds;
    public instructionalComments subtitleSc;
    public bool gaveInst;
    public hand handSc;

    void Start()
    {
        //orderText.text = HowManyOrds.ToString();
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ToastCooked is true || SpaghettiCooked is true || EggCooked is true || PotatoCooked is true)
        {
            sthCooked = true;
        }
        else
        {
            sthCooked = false;
        }

        if (handSc.tutorialLvl is 1)
        {
            if (sthBurnt)
            {
                if (!gaveInst)
                {
                    string burnt = "No need to worry. Just throw it away!";
                    if (!subtitleSc.instComments.Contains(burnt))
                    {
                        subtitleSc.instComments.Add(burnt);
                        subtitleSc.Subtitles();
                    }
                    gaveInst = true;
                }
            }
        }
    }

    public void AddOrder()
    {
        //orderText.text = HowManyOrds.ToString();
    }
}
