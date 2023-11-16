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

    void Start()
    {
        drinks = 4;
        canDrop = true;
        FoodSelected = GameObject.FindGameObjectWithTag("Inventory").GetComponent<FoodClasses>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
    }

    public void OnMouseDown()
    {
        if (canDrop)
        {
            print("can see you");
            Robot.GetComponent<Animation>().Play("RC_delivery");

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
                if (!subtitleSc.playing && !subtitleSc.instComments.Contains(plateFirst))
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
