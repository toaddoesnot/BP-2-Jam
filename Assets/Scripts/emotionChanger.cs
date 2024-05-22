using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emotionChanger : MonoBehaviour
{
    public Sprite[] bearSprites;
    public Sprite[] hound1Sprites;
    public Sprite[] hound2Sprites;
    public Sprite[] ratSprites;

    public GameObject[] heads; //bear, dog, rat, dog2
    public GameObject[] bodies; //bear dog rat dog2

    public bool amActive;
    public int currentGuest;
    public int currentMood;

    public characterSlot mySlot;

    // Update is called once per frame
    void Update()
    {
        currentMood = mySlot.moodState;

        if (amActive)
        {
            foreach (GameObject bod in bodies)
            {
                bod.SetActive(false);
                bodies[currentGuest].SetActive(true);
                if (currentGuest == 1)
                {
                    bodies[3].SetActive(true); //secondDog
                }
            }

            foreach (GameObject head in heads)
            {
                head.SetActive(false);
                heads[currentGuest].SetActive(true);
                if (currentGuest == 1)
                {
                    heads[3].SetActive(true); //secondDog
                }
            }

            if (currentGuest == 0)
            {
                heads[0].GetComponent<Image>().sprite = bearSprites[currentMood];
            }
            if (currentGuest == 1)
            {
                heads[1].GetComponent<Image>().sprite = hound1Sprites[currentMood];
                heads[3].GetComponent<Image>().sprite = hound2Sprites[currentMood];
            }
            if (currentGuest == 2)
            {
                heads[2].GetComponent<Image>().sprite = ratSprites[currentMood];
            }
        }
    }
}
