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
    public bool drinkDone;
    public bool foodDone;
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

    public GameObject myJuke;

    public float midTime = 20f;
    public float maxTime = 40f;
    public float eatingTime = 10f;

    public hand handSc;

    public GameObject mapAnimation;
    public GameObject mapCenter;
    public GameObject menuChoice;

    public sink sinkSc;

    public int EmState;
    public instructionalComments subtitleSc;
    public AudioSource heLeft;

    public bool gaveManic;
    private int chooseTime;

    public bool lidAction; 
    public levelOne tutLvl;

    void Awake()
    {
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        menuChoice.SetActive(false);
        if (timey != null)
        {
            timey.GetComponent<miniTimer>().timeText.text = myNo.ToString();
        }
        //timey.SetActive(true);
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();

        if(EmState == 0 || EmState == 1)
        {
            chooseTime = 6;
        }
        else
        {
            chooseTime = 2;
        }
    }

    void Update()
    {
        if (canPress)
        {
            myJuke.GetComponent<Button>().enabled = true;
        }
        else
        {
            myJuke.GetComponent<Button>().enabled = false;
        }

        if (myPeep.activeInHierarchy)
        {
            myPeep.GetComponent<emotionChanger>().amActive = true;
            myPeep.GetComponent<emotionChanger>().currentGuest = myGuest;
            mapCenter.SetActive(true); //mapAnimation
        }
        else
        {
            myPeep.GetComponent<emotionChanger>().amActive = false;
            if (cleanpl.activeInHierarchy)
            {
                mapCenter.SetActive(true);
            }
            else
            {
                mapCenter.SetActive(false);
            }
            
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

            //INSERT CODE HERE           //public GameObject toast; strawberry; butter; noodles; potato; egg; shroom;
            if (myOrder.GetComponent<orderGenerator>().randomOrder == 1 || myOrder.GetComponent<orderGenerator>().randomOrder == 2)
            {
                if (myOrder.GetComponent<orderGenerator>().PotatoONoodle is 0)
                {
                    plate.GetComponent<FoodButtonClick>().noodles.SetActive(true);

                }
                if (myOrder.GetComponent<orderGenerator>().PotatoONoodle is 1)
                {
                    plate.GetComponent<FoodButtonClick>().potato.SetActive(true);
                }

                if (myOrder.GetComponent<orderGenerator>().secondCourse == 0 && myOrder.GetComponent<orderGenerator>().secondCourse == 2)
                {
                    plate.GetComponent<FoodButtonClick>().egg.SetActive(true);
                }
                if (myOrder.GetComponent<orderGenerator>().secondCourse == 1 && myOrder.GetComponent<orderGenerator>().secondCourse == 2)
                {
                    plate.GetComponent<FoodButtonClick>().shroom.SetActive(true);
                }

                //FOR BOTH SIDES

                if (myOrder.GetComponent<orderGenerator>().randomOrder == 2)
                {
                    plate.GetComponent<FoodButtonClick>().toast.SetActive(true);

                    if (myOrder.GetComponent<orderGenerator>().firstCourse == 0 && myOrder.GetComponent<orderGenerator>().firstCourse == 2)
                    {
                        plate.GetComponent<FoodButtonClick>().strawberry.SetActive(true);
                    }
                    if (myOrder.GetComponent<orderGenerator>().firstCourse == 1 && myOrder.GetComponent<orderGenerator>().firstCourse == 2)
                    {
                        plate.GetComponent<FoodButtonClick>().butter.SetActive(true);
                    }
                }
            }
            else
            {
                if (myOrder.GetComponent<orderGenerator>().randomOrder == 0)
                {
                    plate.GetComponent<FoodButtonClick>().toast.SetActive(true);

                    if (myOrder.GetComponent<orderGenerator>().firstCourse == 0 && myOrder.GetComponent<orderGenerator>().firstCourse == 2)
                    {
                        plate.GetComponent<FoodButtonClick>().strawberry.SetActive(true);
                    }
                    if (myOrder.GetComponent<orderGenerator>().firstCourse == 1 && myOrder.GetComponent<orderGenerator>().firstCourse == 2)
                    {
                        plate.GetComponent<FoodButtonClick>().butter.SetActive(true);
                    }
                }
            }
            //INSERT CODE HERE
        }

        if (foodDone && drinkDone)
        {
            if (!ready2eat)
            {
                ready2eat = true;
                currentState = 3;

                Destroy(myOrder);
                myOrder = null;

                timey.SetActive(false);

                plate.SetActive(true);

                

                StartCoroutine(Eating());
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

            //handSc  lidAction     tutLvl
        }

        if (timeWaiting >= midTime && timeWaiting < midTime + 1f)
        {
            if (moodState is 2)
            {
                moodState = 1;
                timeWaiting = midTime + 1f;
            }
            else
            {
                if (moodState is 1 && timeWaiting < midTime + 1f)
                {
                    moodState = 0;
                    timeWaiting = midTime + 1f;
                }
            }
        }
        else
        {
            if (timeWaiting >= maxTime && timeWaiting < maxTime + 1f)
            {
                   
                if (moodState is 2)
                {
                    moodState = 1;
                    timeWaiting = maxTime + 1f;
                }
                else
                {
                    if (moodState is 1 && timeWaiting < maxTime + 1f)
                    {
                        moodState = 0;
                        timeWaiting = maxTime + 1f;
                    }
                }

                if (EmState == 1)
                {
                    //LEAVE DINER
                    string lostOrder = "I think we just lost an order...";
                    if (!subtitleSc.instComments.Contains(lostOrder))
                    {
                        subtitleSc.instComments.Add(lostOrder);
                        subtitleSc.Subtitles();
                    }
                    heLeft.Play();

                    timeWaiting = 0;
                    counting = false;

                    myPeep.SetActive(false);
                    Destroy(myOrder);
                    myOrder = null;

                    timey.SetActive(false);

                    canPress = true;
                    currentState = 4;

                    ///below new stuff

                    moodState = 1;
                    myNewTimer = null;

                    paid = true;
                    StartCoroutine(forgetClean());

                    occupied = false;
                    canPress = false;

                    drinkDone = false;
                    foodDone = false;
                    ready2eat = false;

                    mapCenter.SetActive(false);
                }
            }
        }
    }

    public IEnumerator Eating()
    {
        yield return null;
        mapAnimation.SetActive(false);

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
        mapCenter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(eatingTime);

        plate.SetActive(false);
        plate2.SetActive(true);

        if (moodState == 2)
        {
            leaveTip = true;
        }

        cleanpl.SetActive(true);
        wheel.GetComponent<Animation>().Play("wheelSpin");

        myPeep.SetActive(false);
        canPress = true;
        currentState++;

        ///below new stuff
        
        moodState = 1;
        myNewTimer = null;

        if (EmState == 2)
        {
            if (gaveManic)
            {
                WheelPress();
            }
            else
            {
                string selfClean = "Don't worry, I can clean for you today!";
                if (!subtitleSc.instComments.Contains(selfClean))
                {
                    subtitleSc.instComments.Add(selfClean);
                    subtitleSc.Subtitles();
                }
                WheelPress();
                gaveManic = true;
            }
            
        }
    }

    public IEnumerator Order()
    {
        yield return null;
        mapAnimation.SetActive(false);
        timeWaiting = 0;

        timerSc.ResetTimer();
        if (myNewTimer != null && myNewTimer.activeInHierarchy)
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
            menuChoice.SetActive(true);
            yield return new WaitForSeconds(chooseTime); //choosing a meal

            myOrder = Instantiate(orderInstance, orderPlaque.transform.position, Quaternion.identity, orderPlaque.transform); //NEWNEWNE 

            myOrder.GetComponent<orderGenerator>().nombre = myNo;
            myOrder.GetComponent<orderGenerator>().myPeepsc = this.gameObject;

            currentState++; //now waiting for food
            menuChoice.SetActive(false);
            mapAnimation.SetActive(true);
            if (lidAction)
            {
                if (handSc.tutorialLvl == 1)
                {
                    if (tutLvl.tutPhase == 0)
                    {
                        tutLvl.tutPhase = 1;
                        tutLvl.lidSound.Play();
                    }

                }
                if (handSc.tutorialLvl == 3)
                {
                    if (tutLvl.tutPhase == 4)
                    {
                        tutLvl.tutPhase = 5;
                        tutLvl.lidSound.Play();
                    }
                }
                if (handSc.tutorialLvl == 4)
                {
                    if (tutLvl.tutPhase == 7)
                    {
                        tutLvl.tutPhase = 8;
                        tutLvl.lidSound.Play();
                    }
                }
            }

            timeWaiting = 0;
            timerSc.InitiateTimer();

            yield return new WaitForSeconds(0.1f); //or else assigns incorrectly
            if (handSc.tutorialLvl != 1)
            {
                myNewTimer = myOrder.GetComponent<orderGenerator>().timers[myOrder.GetComponent<orderGenerator>().neededTimer];
                myNewTimer.GetComponent<miniTimer>().InitiateTimer();
            }

            if (EmState == 1)
            {
                myPrice = myOrder.GetComponent<orderGenerator>().orderWorth / 2;
                myTPrice = 1;
            }
            else
            {
                if (EmState == 2)
                {
                    myPrice = myOrder.GetComponent<orderGenerator>().orderWorth + Random.Range(5, 10);
                    myTPrice = myOrder.GetComponent<orderGenerator>().myTip + Random.Range(7, 10);
                }
                else
                {
                    myPrice = myOrder.GetComponent<orderGenerator>().orderWorth;
                    myTPrice = myOrder.GetComponent<orderGenerator>().myTip;
                }
            }

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
                StartCoroutine(forgetClean());

                bye.Play();
                plate2.SetActive(false);
                occupied = false;
                canPress = false;
                sinkSc.cleanups++;
                sinkSc.switchSc.switchSound.Play();

                drinkDone = false;
                foodDone = false;
                ready2eat = false;

            }
        }
    }

    public void JustLeave()
    {
        timeWaiting = 0;
        counting = false;

        myPeep.SetActive(false);

        timey.SetActive(false);

        canPress = true;
        currentState = 4;

        ///below new stuff

        moodState = 1;
        myNewTimer = null;

        paid = true;
        StartCoroutine(forgetClean());

        occupied = false;
        canPress = false;

        drinkDone = false;
        foodDone = false;
        ready2eat = false;

        mapCenter.SetActive(false);
        mapAnimation.SetActive(false);

    }

    IEnumerator forgetClean()
    {
        yield return new WaitForSeconds(1.5f);
        cleanpl.SetActive(false);
    }
}
