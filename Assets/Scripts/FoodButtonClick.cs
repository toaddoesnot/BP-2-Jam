using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButtonClick : MonoBehaviour
{
    public FoodClasses FoodSelected;
    public cookedToast ToastIsCooked;
    public cookedToast ToastIsCooked2;
    public cookedSpaghetti RamenIsCooked;
    public cookedSpaghetti RamenIsCooked2;

    public GameObject toast;
    public GameObject strawberry;
    public GameObject butter;
    public GameObject noodles;
    public GameObject egg;
    public GameObject shroom;

    public bool HaveToast;
    public bool HaveNoodles;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        if(HaveToast)
        {
            if (FoodSelected.currentFoods == 1)
            {
                strawberry.SetActive(true);
            }
            if (FoodSelected.currentFoods == 2)
            {
                butter.SetActive(true);
            }
        }
        
        if (ToastIsCooked.ToastCooked)
        {
            toast.SetActive(true);
            HaveToast = true;
        }
        else
        {
            if (ToastIsCooked2.ToastCooked)
            {
                toast.SetActive(true);
                HaveToast = true;
            }
        }

        if (HaveNoodles)
        {
            if (FoodSelected.currentFoods == 5)
            {
                print("You have toast!");
                egg.SetActive(true);
            }
            if (FoodSelected.currentFoods == 6)
            {
                shroom.SetActive(true);
            }
        }

        if (RamenIsCooked.RamenCooked)
        {
            noodles.SetActive(true);
            HaveNoodles = true;
        }
        else
        {
            if (RamenIsCooked2.RamenCooked)
            {
                noodles.SetActive(true);
                HaveNoodles = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
