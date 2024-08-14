using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guestAssigner : MonoBehaviour
{
    public GameObject[] bears;
    public GameObject[] dogs1;
    public GameObject[] dogs2;
    public GameObject[] rats;

    public int whichCustomer;

    private int whichBear;
    private int whichRat;
    private int whichdDog1;
    private int whichdDog2;

    public bool introLevels;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignGuest()
    {
        if(whichCustomer == 0) //bear
        {
            if(this.GetComponent<characterSlot>().EmState == 1) //depr
            {
                whichBear = Random.Range(1, 5);
            }
            else
            {
                if (this.GetComponent<characterSlot>().EmState == 2) //manic
                {
                    whichBear = Random.Range(0, 4);
                }
                else
                {
                    whichBear = Random.Range(0, 5);
                }
            }

            bears[whichBear].GetComponent<guestRandomizer>().RandomizeGuest();

            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().bearSprites[0] = bears[whichBear].GetComponent<guestRandomizer>().heads[0];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().bearSprites[1] = bears[whichBear].GetComponent<guestRandomizer>().heads[1];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().bearSprites[2] = bears[whichBear].GetComponent<guestRandomizer>().heads[2];

            this.GetComponent<characterSlot>().guestSprites[whichCustomer] = bears[whichBear].GetComponent<guestRandomizer>().bodies[bears[whichBear].GetComponent<guestRandomizer>().body];
        }
        if (whichCustomer == 2) //RATS
        {
            if (introLevels)
            {
                whichRat = 5;
                introLevels = false;
            }
            else
            {
                if (this.GetComponent<characterSlot>().EmState == 1) //depr
                {
                    whichRat = Random.Range(1, 5);
                }
                else
                {
                    whichRat = Random.Range(0, 5);
                }
            }


            rats[whichRat].GetComponent<guestRandomizer>().RandomizeGuest();

            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().ratSprites[0] = rats[whichRat].GetComponent<guestRandomizer>().heads[0];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().ratSprites[1] = rats[whichRat].GetComponent<guestRandomizer>().heads[1];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().ratSprites[2] = rats[whichRat].GetComponent<guestRandomizer>().heads[2];

            this.GetComponent<characterSlot>().guestSprites[whichCustomer] = rats[whichRat].GetComponent<guestRandomizer>().bodies[rats[whichRat].GetComponent<guestRandomizer>().body];
        }
        if (whichCustomer == 1) //doggies
        {
            if (this.GetComponent<characterSlot>().EmState == 1) //depr
            {
                whichdDog1 = 0;
                whichdDog2 = Random.Range(0, 2);
            }
            else
            {
                if (this.GetComponent<characterSlot>().EmState == 2) //manic
                {
                    whichdDog1 = Random.Range(1, 4);
                    whichdDog2 = Random.Range(2, 4);
                }
                else
                {
                    whichdDog1 = Random.Range(0, 4);
                    whichdDog2 = Random.Range(0, 4);
                }
            }
            
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().hound1Sprites[0] = dogs1[whichdDog1].GetComponent<guestRandomizer>().heads[0];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().hound1Sprites[1] = dogs1[whichdDog1].GetComponent<guestRandomizer>().heads[1];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().hound1Sprites[2] = dogs1[whichdDog1].GetComponent<guestRandomizer>().heads[2];

            this.GetComponent<characterSlot>().guestSprites[1] = dogs1[whichdDog1].GetComponent<guestRandomizer>().bodies[dogs1[whichdDog1].GetComponent<guestRandomizer>().body];


            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().hound2Sprites[0] = dogs2[whichdDog2].GetComponent<guestRandomizer>().heads[0];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().hound2Sprites[1] = dogs2[whichdDog2].GetComponent<guestRandomizer>().heads[1];
            this.GetComponent<characterSlot>().myPeep.GetComponent<emotionChanger>().hound2Sprites[2] = dogs2[whichdDog2].GetComponent<guestRandomizer>().heads[2];

            this.GetComponent<characterSlot>().guestSprites[3] = dogs2[whichdDog2].GetComponent<guestRandomizer>().bodies[dogs2[whichdDog2].GetComponent<guestRandomizer>().body];
        }
    }
}
