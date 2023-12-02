using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodCart : MonoBehaviour
{
    public GameObject[] jukes;
    
    public drinkManager drinkSc;

    public int drinks;
    public bool breakLoop;

    public AudioSource ping;
    public bool canDrop;

    public FoodClasses FoodSelected;
    public Inventory inventory;
    public instructionalComments subtitleSc;

    public GameObject Robot;
    public hand handSc;
    public levelOne instLevels;

    private bool didCutscenes;
    public GameObject clock;

    public int dishesServed;
    public dishwashingMachine dishSc;

    void Start()
    {
        drinks = 4;
        canDrop = true;

        FoodSelected = GameObject.FindGameObjectWithTag("Inventory").GetComponent<FoodClasses>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
    }

    public void OnMouseDown()
    {
        if (canDrop)
        {
            print("can see you");
            

            drinks = drinkSc.drinkHave;

            foreach (GameObject juke in jukes)
            {
                if (juke.GetComponent<characterSlot>().myOrder != null)
                {
                    juke.GetComponent<characterSlot>().myOrder.GetComponent<orderGenerator>().compareOrder();
                }

                if (breakLoop)
                {
                    StartCoroutine(coolDown());
                    Robot.GetComponent<Animator>().Play("RC_delivery");
                    dishesServed++;
                    if (dishSc.recharges != 0)
                    {
                        dishSc.recharges--;
                        dishSc.recharges--;
                    }

                    if (handSc.tutorialLvl is 1)
                    {
                        clock.GetComponent<Image>().fillAmount -= 0.25f;
                        if (clock.GetComponent<Image>().fillAmount == 0f)
                        {
                            instLevels.Ready2Close();
                        }
                    }

                    if (!didCutscenes)
                    {
                        if (handSc.tutorialLvl is 1)
                        {
                            instLevels.Frances();
                            didCutscenes = true;
                        }
                    }

                    break;
                }
            }
            canDrop = false;
            StartCoroutine(resetCart());

        }

        if (FoodSelected.currentFoods == -1)
        {
            if (inventory.sthCooked)
            {
                string plateFirst = "On the plate first, please!";
                if (!subtitleSc.instComments.Contains(plateFirst))
                {
                    subtitleSc.instComments.Add(plateFirst);
                    subtitleSc.Subtitles();
                }
                
            }
        }
        
    }

    IEnumerator resetCart()
    {
        yield return new WaitForSeconds(1.2f);
        canDrop = true;
    }

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(1f);
        breakLoop = false;
    }
}
