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

    public void Start()
    {
        
    }


    public void Update()
    {
        if (myObject != null)
        {
            HasItem = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            HasItem = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
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


}

