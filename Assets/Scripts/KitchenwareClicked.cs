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

    public void Start()
    {
        
    }


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
                Instantiate(Pot, transform.position, Quaternion.identity);
                FoodSelected.currentFoods = -1;
            }
        }
           
        if (FoodSelected.currentFoods == 10)
        {
            if (HasItem)
            {
                
            }
            else
            {
                Instantiate(Toaster, transform.position, Quaternion.identity);
                FoodSelected.currentFoods = -1;
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

