using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterSlot : MonoBehaviour
{
    public bool occupied;

    public GameObject myPeep;

    public GameObject wheel;
    public GameObject menu;
    public GameObject cleanpl;

    public Sprite[] guestSprites;

    public int moodState;

    public float timeWaiting;
    public bool counting;
    public bool canPress;

    public int currentState; //0 need menu //1 choosing //2 waiting for food //3 eating

    public GameObject orderInstance;
    public GameObject orderPlaque;
    public string myNo;

    public GameObject myOrder;
    private bool drinkDone;
    private bool foodDone;
    private bool ready2eat;

    public GameObject timey;
    public GameObject plate;
    public GameObject plate2;

    public AudioSource bye;
    public int myGuest;
    public bool moodChanged;

    public miniTimer timerSc; //timerSc.InitiateTimer();
    public GameObject myNewTimer;
    public menuButton menuSc;

    public int myPrice;
    public int myTPrice;
    public bool leaveTip;
    public bool paid;

    public screenSwiper swiperBt;
    public piggyBank tipSc;

    void Awake()
    {
        timey.GetComponent<miniTimer>().timeText.text = myNo.ToString();
        //timey.SetActive(true);
    }

    void Update()
    {
        if (myPeep.activeInHierarchy)
        {
            myPeep.GetComponent<emotionChanger>().amActive = true;
            myPeep.GetComponent<emotionChanger>().currentGuest = myGuest;
        }
        else
        {
            myPeep.GetComponent<emotionChanger>().amActive = false;
        }

        if(myOrder != null)
        {
            if (!foodDone && myOrder.GetComponent<orderGenerator>().OrderFullfilled)
            {
                print(myNo + ": I received my order");
                foodDone = true;
            }
            if (!drinkDone && myOrder.GetComponent<orderGenerator>().DrinkFullfilled)
            {
                print(myNo + ": I received my drink");
                drinkDone = true;
            }
        }

        if (foodDone && drinkDone)
        {
            if (!ready2eat)
            {
                currentState = 3;
                Destroy(myOrder);
                myOrder = null;

                timey.SetActive(false);
                plate.SetActive(true);

                StartCoroutine(Eating());
                ready2eat = true;
            }
        }

        if (counting)
        {
            timeWaiting += Time.deltaTime;
        }

        if (currentState is 0 && timeWaiting >= 0.01f)
        {
            canPress = true;
            menu.SetActive(true);
            leaveTip = false;
            paid = false;
        }
        else
        {
            menu.SetActive(false);
        }

        if (timeWaiting >= 20f && timeWaiting < 21f)
        {
            if (moodState is 2)
            {
                moodState = 1;
                timeWaiting = 21;
            }
            else
            {
                if (moodState is 1 && timeWaiting < 21f)
                {
                    moodState = 0;
                    timeWaiting = 21;
                }
            }
        }
        else
        {
            if (timeWaiting >= 40f && timeWaiting < 41f)
            {
                   
                if (moodState is 2)
                {
                    moodState = 1;
                    timeWaiting = 41;
                }
                else
                {
                    if (moodState is 1 && timeWaiting < 41f)
                    {
                        moodState = 0;
                        timeWaiting = 41;
                    }
                }
            }
        }
    }

    public IEnumerator Eating()
    {
        yield return null;
        timeWaiting = 0;

        if (moodState != 2)
        {
            moodState++;
        }

        yield return new WaitForSeconds(1f);

        if (currentState is 3)
        {
            counting = false;
            StartCoroutine(ReceivedOrder());
        }
        else
        {
            timerSc.InitiateTimer();

            if (myNewTimer != null && myNewTimer.activeInHierarchy)
            {
                myNewTimer.GetComponent<miniTimer>().InitiateTimer();
            }
        }
    }

    public IEnumerator ReceivedOrder() //leave and empty the place
    {
        yield return new WaitForSeconds(10f);

        plate.SetActive(false);
        plate2.SetActive(true);

        if (moodState == 2)
        {
            leaveTip = true;
        }

        wheel.GetComponent<Animation>().Play("wheelSpin");

        myPeep.SetActive(false);
        canPress = true;
        currentState++;

        ///below new stuff
        
        moodState = 1;
        myNewTimer = null;
    }

    IEnumerator Order()
    {
        yield return null;
        timeWaiting = 0;
        
        timerSc.ResetTimer();
        if(myNewTimer != null && myNewTimer.activeInHierarchy)
        {
            myNewTimer.GetComponent<miniTimer>().ResetTimer();
        }

        canPress = false;

        if (moodState != 2)
        {
            moodState++;
        }
        
        if (currentState is 1)
        {
            yield return new WaitForSeconds(6f); //choosing a meal

            myOrder = Instantiate(orderInstance, orderPlaque.transform.position, Quaternion.identity, orderPlaque.transform); //NEWNEWNE 
            
            myOrder.GetComponent<orderGenerator>().nombre = myNo;
            myOrder.GetComponent<orderGenerator>().myPeepsc = this.gameObject;

            currentState++; //now waiting for food

            timeWaiting = 0;
            timerSc.InitiateTimer();

            yield return new WaitForSeconds(0.1f); //or else assigns incorrectly
            myNewTimer = myOrder.GetComponent<orderGenerator>().timers[myOrder.GetComponent<orderGenerator>().neededTimer];
            myNewTimer.GetComponent<miniTimer>().InitiateTimer();

            myPrice = myOrder.GetComponent<orderGenerator>().orderWorth;
            myTPrice = myOrder.GetComponent<orderGenerator>().myTip;
        }
    }

    public void WheelPress()
    {
        if (canPress)
        {
            if (currentState < 4)
            {
                currentState++;

                StartCoroutine(Order());
            }
            else
            {
                if (!paid)
                {
                    if (leaveTip)
                    {
                        menuSc.moneyLeft += myPrice;
                        tipSc.tipsTotal += myTPrice;
                        swiperBt.addMoney = true;
                        paid = true;
                    }
                    else
                    {
                        menuSc.moneyLeft += myPrice;
                        swiperBt.addMoney = true;
                        paid = true; 
                    }
                }
                
                wheel.GetComponent<Animation>().Play("wheelUnSpin");
                bye.Play();
                plate2.SetActive(false);
                occupied = false;
            }
        }
    }
}
