using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class manicLevels : MonoBehaviour
{
    public Fungus.Flowchart Manic;
    public GameObject dogsTalk;

    public screenSwiper swipeSc;
    public GameObject blinkEf;
    public GameObject blocker;
    public AudioSource bgSound;
    public customerGenerator cg;

    public GameObject stoveUp;
    public GameObject stoveDown;
    public miniTimer timerSc;

    public bool wentManic;

    public GameObject blackScreen;
    public AudioSource soundBg;
    public levelManager levelSc;

    private hand handSc;
    public FoodClasses foodSc; //
    public Inventory inventorySc;

    public manicShakes shakeSc;
    public GameObject skies;
    public GameObject accelerateSound;
    public drinkManager drinkSc;


    void Start()
    {
        cg = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<customerGenerator>();
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();

    }

    void Update()
    {
        if (wentManic)
        {
            if (swipeSc.onScreen == 0)
            {
                StartCoroutine(EnsueBlinking());
                swipeSc.blocker.SetActive(true);
                wentManic = false;
            }
        }
    }

    IEnumerator EnsueBlinking()
    {
        blinkEf.GetComponent<Animation>().Play("blinkEffect");
        yield return new WaitForSeconds(2f);
        blinkEf.GetComponent<Animation>().Play("blinkEffect_pre");
        GetComponent<AudioSource>().Play();
        bgSound.volume = 0.2f;


        yield return new WaitForSeconds(2f);


        if (stoveUp.GetComponent<KitchenwareClicked>().HasItem)
        {
            Destroy(stoveUp.GetComponent<KitchenwareClicked>().myObject);
        }
        if (stoveDown.GetComponent<KitchenwareClicked>().HasItem)
        {
            Destroy(stoveDown.GetComponent<KitchenwareClicked>().myObject);
        }

        handSc.haveOrder = false;
        foodSc.currentFoods = -1;
        inventorySc.ToastCooked = false; inventorySc.SpaghettiCooked = false; inventorySc.EggCooked = false; inventorySc.PotatoCooked = false;
        drinkSc.HasReadyCoffee = false; drinkSc.HasReadySoda = false; drinkSc.HasReadyOJ = false;



        cg.StopCoroutine("GenerateCustomer");
        foreach (GameObject order in cg.customerSlots)
        {
            if (order.GetComponent<characterSlot>().occupied)
            {
                order.GetComponent<characterSlot>().drinkDone = true;
                order.GetComponent<characterSlot>().foodDone = true;
            }
        }

        yield return new WaitForSeconds(2f);

        timerSc.PauseTimer();//cg.clockSc.timerSc.PauseTimer();
        cg.clockSc.timeOn = false;

        
        blinkEf.SetActive(false);

        blocker.SetActive(true);
        dogsTalk.SetActive(true);
        Manic.ExecuteBlock("dawgs");
        swipeSc.blocker.SetActive(false);
    }

    public void StopBlinking()
    {
        cg.clockSc.timeOn = true;

        dogsTalk.SetActive(false);
        blocker.SetActive(false);
        GetComponent<AudioSource>().Stop();
        bgSound.volume = 1f;
        
        
        timerSc.UnpauseTimer();

        //////cg.weFull = false;
        cg.StartCoroutine("ManicEpisode");
    }

    public void FinishLevel()
    {
        blackScreen.SetActive(true);
        soundBg.volume = 0.2f;
        StartCoroutine(GentlyClose());
    }

    IEnumerator GentlyClose()
    {
        yield return new WaitForSeconds(5f);
        levelSc.NewLevel();
    }
}
