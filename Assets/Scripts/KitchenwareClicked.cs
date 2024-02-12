using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenwareClicked : MonoBehaviour
{
    public FoodClasses FoodSelected;

    public GameObject Pot;
    public GameObject Toaster;

    public bool HasItem;

    public GameObject myObject;
    public Cookers myObjectsSc;

    public Slider myTimer;

    public AudioSource mySound;
    public bool isPlaying;

    public AudioSource foodSound;
    public AudioClip[] foodSounds;

    public GameObject self;
    public bool henss;

    public int myState;

    public bool needAdvice;
    public levelOne tutLvl;
    public GameObject[] plateSc; //

    public void Update()
    {
        if (myObject != null)
        {
            HasItem = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (isPlaying is false)
            {
                mySound.Play();
                isPlaying = true;
            }
            
        }
        else
        {
            HasItem = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            mySound.Stop();
            isPlaying = false;
        }
    }


    void OnMouseDown()
    {
        if (FoodSelected.currentFoods == 9)
        {
            if(HasItem)
            {
                
            }
            else
            {
                Instantiate(Pot, transform.position, Quaternion.identity, this.transform);
                FoodSelected.currentFoods = -1;
                if (needAdvice)
                {
                    if (tutLvl.tutPhase == 5)
                    {
                        tutLvl.tutPhase = 6;
                        tutLvl.lidSound.Play();
                    }
                }
            }
        }
           
        if (FoodSelected.currentFoods == 10)
        {
            if (HasItem)
            {
                
            }
            else
            {
                Instantiate(Toaster, transform.position, Quaternion.identity, this.transform);
                FoodSelected.currentFoods = -1;
                if (needAdvice)
                {
                    if(tutLvl.tutPhase == 1)
                    {
                        tutLvl.tutPhase = 2;
                        tutLvl.lidSound.Play();
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cooker")
        {
            myObject = collision.gameObject;
            
            myObjectsSc = myObject.GetComponent<Cookers>();
            myObjectsSc.timer = myTimer;
            myObjectsSc.myStove = self;

            //em states here

            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //HasItem = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
       // //if (collision.gameObject.tag == "Cooker")
      //  {
         //   myObject = null;
          //  myObjectsSc = null;
       // }
    }

    public void Boiling()
    {
        foodSound.PlayOneShot(foodSounds[0]);
    }
    public void BoilingReady()
    {
        foodSound.PlayOneShot(foodSounds[1]);
    }
    public void Frying()
    {
        foodSound.PlayOneShot(foodSounds[2]);
    }
    public void FryingReady()
    {
        foodSound.PlayOneShot(foodSounds[3]);
        if (needAdvice)
        {
            if (tutLvl.tutPhase == 2)
            {
                plateSc[0].GetComponent<plateGenerator>().GeneratePlate();
                plateSc[1].GetComponent<plateGenerator>().GeneratePlate();
                plateSc[2].GetComponent<plateGenerator>().GeneratePlate();
                plateSc[3].GetComponent<plateGenerator>().GeneratePlate();
            }
        }
    }
    public void TakeBread()
    {
        foodSound.PlayOneShot(foodSounds[4]);
    }
    public void TakePasta()
    {
        foodSound.PlayOneShot(foodSounds[5]);
    }
}

