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

    void Start()
    {
        cg = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<customerGenerator>();
    }

    void Update()
    {
        if (wentManic)
        {
            if (swipeSc.onScreen == 0)
            {
                StartCoroutine(EnsueBlinking());
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
        cg.clockSc.timerSc.PauseTimer();
        cg.clockSc.timeOn = false;
        
        blinkEf.SetActive(false);

        blocker.SetActive(true);
        dogsTalk.SetActive(true);
        Manic.ExecuteBlock("dawgs");
    }

    public void StopBlinking()
    {
        dogsTalk.SetActive(false);
        blocker.SetActive(false);
        GetComponent<AudioSource>().Stop();
        bgSound.volume = 1f;

        timerSc.PauseTimer();
        cg.clockSc.timeOn = true;

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
