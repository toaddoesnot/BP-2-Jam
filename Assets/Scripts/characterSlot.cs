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
        }
        else
        {
            menu.SetActive(false);
        }

        if (timeWaiting >= 20f && timeWaiting < 40f)
        {
            if (!moodChanged)
            {
                if (moodState is 2)
                {
                    moodState = 1;
                    moodChanged = true;
                }
                else
                {
                    if (moodState is 1)
                    {
                        moodState = 0;
                        moodChanged = true;
                    }
                }
            }
        }
        else
        {
            if (timeWaiting >= 40f)
            {
                if (moodChanged)
                {
                    if (moodState is 2)
                    {
                        moodState = 1;
                        moodChanged = false;
                    }
                    else
                    {
                        if (moodState is 1)
                        {
                            moodState = 0;
                            moodChanged = false;
                        }
                    }
                }
            }
        }
    }

    IEnumerator Eating()
    {
        yield return null;
        timeWaiting = 0;
        timerSc.remainingDuration = timerSc.Duration;

        if (moodState != 2)
        {
            moodState++;
        }

        if (currentState is 3)
        {
            yield return new WaitForSeconds(10f);

            plate.SetActive(false);
            plate2.SetActive(true);
            //leave and empty the place
            wheel.GetComponent<Animation>().Play("wheelSpin");

            counting = false;
            timeWaiting = 0;
            timerSc.remainingDuration = timerSc.Duration;

            myPeep.SetActive(false);
            canPress = true;
        }
    }

    IEnumerator Order()
    {
        yield return null;
        timeWaiting = 0;
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
            
            currentState++; //now waiting for food
            timerSc.remainingDuration = timerSc.Duration;

            yield return new WaitForSeconds(0.1f);
            myNewTimer = myOrder.GetComponent<orderGenerator>().timers[myOrder.GetComponent<orderGenerator>().neededTimer];
            myNewTimer.GetComponent<miniTimer>().InitiateTimer();

            
        }
        else
        {
            if (currentState is 4)
            {
                wheel.GetComponent<Animation>().Play("wheelUnSpin");
                bye.Play();
                plate2.SetActive(false);
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
