using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodClasses : MonoBehaviour
{
    public GameObject[] Foods;
    public int currentFoods = -1;
    public hand handSc;
     
    public bool noUcant;

    public bool needInstruction;
    private bool gaveInstruction;

    private instructionalComments subtitleSc;

    void Awake()
    {
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
    }

    public void Update()
    {
        if (this.GetComponent<Inventory>().sthCooked is true || this.GetComponent<drinkManager>().HasSthReady is true || handSc.haveOrder)
        {
            noUcant = true;
        }
        else
        {
            noUcant = false;
        }

        if (Input.GetMouseButtonDown(1))//right mouse button
        {
            if(currentFoods != -1)
            {
                currentFoods = -1;
            }
        }
    }

    public void SetButton(int index)
    {
        if (!noUcant)
        {
            currentFoods = index;

            if (needInstruction)
            {
                if (!gaveInstruction)
                {
                    string rightMouse = "You may also press Right Mouse Button to drop it.";

                    if (!subtitleSc.instComments.Contains(rightMouse))
                    {
                        subtitleSc.instComments.Add(rightMouse);
                        if (!subtitleSc.playing)
                        {
                            subtitleSc.Subtitles();
                        }
                        gaveInstruction = true;
                        needInstruction = false;
                    }
                    
                }
            }
        }
    }
}
