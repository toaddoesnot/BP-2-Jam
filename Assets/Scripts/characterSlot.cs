using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSlot : MonoBehaviour
{
    public bool occupied;

    public GameObject myPeep;

    public GameObject wheel;
    public GameObject menu;
    public GameObject cleanpl;

    public Sprite[] guestSprites;

    private int moodState;

    public float timeWaiting;
    public bool counting;
    public bool canPress;

    public int currentState; //0 need menu //1 choosing //2 waiting for food //3 eating

    public GameObject orderInstance;
    public GameObject orderPlaque;
    public string myNo;

    public bool TEST;
    public GameObject myOrder;

    void Update()
    {
        if(myOrder != null)
        {
            if (myOrder.GetComponent<orderGenerator>().OrderFullfilled)
            {
                print(myNo + ": I received my order");
            }
        }

        if (TEST)
        {
            currentState = 3;
            StartCoroutine(Eating());
            TEST = false;
        }
        
        if (canPress && currentState == 0)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }

        if (counting)
        {
            timeWaiting += Time.deltaTime;
        }

        if (currentState is 0 && timeWaiting >= 5f)
        {
            canPress = true;
        }

        if (timeWaiting >= 20f && timeWaiting < 40f)
        {
            if (moodState is 2)
            {
                moodState = 1;
            }
            else
            {
                if (moodState is 1)
                {
                    moodState = 0;
                }
            }

            if (timeWaiting >= 40f)
            {
                if (moodState is 2)
                {
                    moodState = 1;
                }
                else
                {
                    if (moodState is 1)
                    {
                        moodState = 0;
                    }
                }
            }
        }
    }

    IEnumerator Eating()
    {
        yield return null;
        timeWaiting = 0;

        if (currentState is 3)
        {
            yield return new WaitForSeconds(10f);

            //leave and empty the place
            wheel.GetComponent<Animation>().Play("wheelSpin");

            counting = false;
            timeWaiting = 0;
            myPeep.SetActive(false);
            canPress = true;
        }
    }

    IEnumerator Order()
    {
        yield return null;
        timeWaiting = 0;
        canPress = false;

        if (currentState is 1)
        {
            yield return new WaitForSeconds(6f); //choosing a meal

            myOrder = Instantiate(orderInstance, orderPlaque.transform.position, Quaternion.identity, orderPlaque.transform); //NEWNEWNE 
            currentState++; //now waiting for food
        }
        else
        {
            if (currentState is 4)
            {
                wheel.GetComponent<Animation>().Play("wheelUnSpin");
                occupied = false;
            }
        }
    }

    public void WheelPress()
    {
        if (canPress)
        {
            currentState++;
            StartCoroutine(Order());
        }
    }

    
}
