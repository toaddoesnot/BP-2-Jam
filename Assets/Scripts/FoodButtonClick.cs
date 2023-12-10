using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using System.Runtime.InteropServices;
using UnityEngine.EventSystems;

public class FoodButtonClick : MonoBehaviour, IPointerDownHandler
{
    public FoodClasses FoodSelected; 
    public Inventory inventory;
    public GameObject inventoryManager;

    public GameObject self;

    public GameObject toast;
    public GameObject strawberry;
    public GameObject butter;
    public GameObject noodles;
    public GameObject potato;
    public GameObject egg;
    public GameObject shroom;

    public bool HaveToast;
    public bool HaveNoodles;
    public bool HavePotatoes;
    public bool HaveEgg;

    public GameObject myPlace;

    public bool ToastWButter;
    public bool ToastWCherry;
    public bool ToastComplete;

    public bool NoodWShroom;
    public bool NoodWEgg;
    public bool NoodComplete;

    public hand handSc;

    public int myfoodHave;
    public int toastHave;
    public int noodHave;

    public bool doneFlow;

    public instructionalComments subtitleSc;
    public dishwashingMachine dishSc;
    public bool ghostPlate;

    void Awake()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
        FoodSelected = inventoryManager.GetComponent<FoodClasses>();
        dishSc = GameObject.FindGameObjectWithTag("plates").GetComponent<dishwashingMachine>();

        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        subtitleSc = GameObject.FindGameObjectWithTag("narrative").GetComponent<instructionalComments>();
    }

    public void Update()
    {
        if (toast.activeInHierarchy && noodles.activeInHierarchy || toast.activeInHierarchy && potato.activeInHierarchy)
        {
            myfoodHave = 2;
        }
        else
        {
            if(toast.activeInHierarchy && noodles.activeInHierarchy is false || toast.activeInHierarchy && potato.activeInHierarchy is false) 
            {
                myfoodHave = 0;
            }
            else
            {
                if (toast.activeInHierarchy is false && noodles.activeInHierarchy || toast.activeInHierarchy is false && potato.activeInHierarchy)
                {
                    myfoodHave = 1;
                }
                else
                {
                    if(toast.activeInHierarchy is false && noodles.activeInHierarchy is false && potato.activeInHierarchy is false && egg.activeInHierarchy is true)
                    {
                        myfoodHave = 3;
                        HaveEgg = true; //if (egg.activeInHierarchy)
                    }
                    else
                    {
                        myfoodHave = 4;
                        toastHave = 4;
                        noodHave = 4;
                    }
                }
                
            }
        }

        if (egg.activeInHierarchy)
        {
            HaveEgg = true;
        }

        if (toast.activeInHierarchy)
        {
            HaveToast = true;

            if (butter.activeInHierarchy && strawberry.activeInHierarchy)
            {
                ToastComplete = true;
                toastHave = 2;
                ToastWButter = false;
                ToastWCherry = false;
            }
            else
            {
                if (butter.activeInHierarchy)
                {
                    ToastWButter = true;
                    toastHave = 1;
                }
                if (strawberry.activeInHierarchy)
                {
                    ToastWCherry = true;
                    toastHave = 0;
                }
            }
        }

        if (noodles.activeInHierarchy || potato.activeInHierarchy)
        {
            if (potato.activeInHierarchy)
            {
                HavePotatoes = true;
            } 

            if (noodles.activeInHierarchy)
            {
                HaveNoodles = true;
            } 

            if (egg.activeInHierarchy && shroom.activeInHierarchy)
            {
                NoodComplete = true;
                if (handSc.whichFlow is 2)
                {
                    if (doneFlow is false)
                    {
                        handSc.StartBlock();
                        doneFlow = true;
                    }
                }
                noodHave = 2;
                NoodWShroom = false;
                NoodWEgg = false;
            }
            else
            {
                if (egg.activeInHierarchy)
                {
                    NoodWEgg = true;
                    noodHave = 0;
                }
                if (shroom.activeInHierarchy)
                {
                    NoodWShroom = true;
                    noodHave = 1;
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData) //
    {
        string emptyPlate = "You can put your ingredients there.";
        string noBase = "You need a base first: pasta, potatoes, or a French toast.";
        string wrongIngredient = "Oops! These don’t go together.";
        string raw = "You might want to cook it first.";

        
        if (FoodSelected.currentFoods == -1)
        {
            if (HaveToast is false)
            {
                if (inventory.ToastCooked && !inventory.sthBurnt)
                {
                    toast.SetActive(true);
                    HaveToast = true;
                    inventory.ToastCooked = false;
                    FoodSelected.currentFoods = -1;
                    myPlace.GetComponent<plateGenerator>().ToastOn();
                }
            }

            if (HaveNoodles is false)
            {
                if (HavePotatoes is false)
                {
                    if (inventory.SpaghettiCooked && !inventory.sthBurnt)
                    {
                        noodles.SetActive(true);
                        HaveNoodles = true;
                        inventory.SpaghettiCooked = false;
                        FoodSelected.currentFoods = -1;
                        myPlace.GetComponent<plateGenerator>().PastaOn();
                    }
                }
            }

            if (HavePotatoes is false)
            {
                if (HaveNoodles is false)
                {
                    if (inventory.PotatoCooked && !inventory.sthBurnt)
                    {
                        potato.SetActive(true);
                        HavePotatoes = true;
                        inventory.PotatoCooked = false;
                        FoodSelected.currentFoods = -1;
                        myPlace.GetComponent<plateGenerator>().PastaOn();
                    }
                }
                    
            }

            if (!egg.activeInHierarchy)
            {
                if (inventory.EggCooked && !inventory.sthBurnt)
                {
                    egg.SetActive(true);
                    inventory.EggCooked = false;
                    FoodSelected.currentFoods = -1;
                    myPlace.GetComponent<plateGenerator>().EggOn();
                }
            }

            if (inventory.sthCooked is false && FoodSelected.noUcant is false && handSc.haveOrder is false)
            {
                if (myfoodHave is not 4)
                {
                    handSc.foodHave = myfoodHave;
                    handSc.toastFill = toastHave;
                    handSc.noodFill = noodHave;

                    if (HavePotatoes)
                    {
                        handSc.potatoInstead = true;
                    }
                    if (HaveEgg)
                    {
                        handSc.haveEgg = true;
                    }

                    handSc.haveOrder = true;
                    dishSc.recharges++;//DISH +1

                    Destroy(this.gameObject);
                }
                else
                {
                    //empty plate

                    if (!subtitleSc.instComments.Contains(emptyPlate))
                    {
                        subtitleSc.instComments.Add(emptyPlate);
                        subtitleSc.Subtitles();
                    }
                    
                }
            }
            else
            {
                if (handSc.haveOrder && dishSc.recharges > 1 || ghostPlate)
                {
                    print("returning works");

                    if (handSc.foodHave is 0)
                    {
                        if (!HaveToast)
                        {
                            toast.SetActive(true);

                            if (handSc.toastFill is 1 || handSc.toastFill is 2)
                            {
                                butter.SetActive(true);
                            }
                            if (handSc.toastFill is 0 || handSc.toastFill is 2)
                            {
                                strawberry.SetActive(true);
                            }
                            if (handSc.haveEgg)
                            {
                                egg.SetActive(true);
                            }

                            handSc.haveOrder = false;
                            dishSc.recharges--;
                        }
                    }
                    else
                    {
                        if (handSc.foodHave is 1)
                        {
                            if (!HaveNoodles && !HavePotatoes)
                            {
                                noodles.SetActive(true);
                                if (handSc.potatoInstead)
                                {
                                    noodles.SetActive(false);
                                    potato.SetActive(true);
                                }

                                if (handSc.noodFill is 0 || handSc.noodFill is 2)
                                {
                                    egg.SetActive(true);
                                }
                                if (handSc.noodFill is 1 || handSc.noodFill is 2)
                                {
                                    shroom.SetActive(true);
                                }

                                if (handSc.haveEgg)
                                {
                                    egg.SetActive(true);
                                }

                                handSc.haveOrder = false;
                                dishSc.recharges--;
                            }
                        }
                        else
                        {
                            if (handSc.foodHave is 3)
                            {
                                if (!egg.activeInHierarchy)
                                {
                                    egg.SetActive(true);
                                    handSc.haveOrder = false;
                                    dishSc.recharges--;
                                }
                            }
                            else
                            {
                                if (handSc.foodHave is 2 && myfoodHave is 4)
                                {
                                    toast.SetActive(true);

                                    if (handSc.toastFill is 1 || handSc.toastFill is 2)
                                    {
                                        butter.SetActive(true);
                                    }
                                    if (handSc.toastFill is 0 || handSc.toastFill is 2)
                                    {
                                        strawberry.SetActive(true);
                                    }

                                    noodles.SetActive(true);
                                    if (handSc.potatoInstead)
                                    {
                                        noodles.SetActive(false);
                                        potato.SetActive(true);
                                    }

                                    if (handSc.noodFill is 0 || handSc.noodFill is 2)
                                    {
                                        egg.SetActive(true);
                                    }
                                    if (handSc.noodFill is 1 || handSc.noodFill is 2)
                                    {
                                        shroom.SetActive(true);
                                    }
                                    if (handSc.haveEgg)
                                    {
                                        egg.SetActive(true);
                                    }

                                    handSc.haveOrder = false;
                                    dishSc.recharges--;
                                }
                            }

                        }
                    }
                }
            }
        }

        if (FoodSelected.currentFoods == 1)
        {
            if (HaveToast)
            {
                if (!strawberry.activeInHierarchy)
                {
                    strawberry.SetActive(true);
                    FoodSelected.Foods[1].GetComponent<ingridientSupply>().Spend();
                    FoodSelected.currentFoods = -1;
                    myPlace.GetComponent<plateGenerator>().CherryOn();
                }
            }
            else
            {
                if (HaveNoodles || HavePotatoes)
                {
                    //wrong ing
                    if (!subtitleSc.instComments.Contains(wrongIngredient))
                    {
                        subtitleSc.instComments.Add(wrongIngredient);
                        subtitleSc.Subtitles();
                    }
                }
                else
                {
                    //no base
                    if (!subtitleSc.instComments.Contains(noBase))
                    {
                        subtitleSc.instComments.Add(noBase);
                        subtitleSc.Subtitles();
                    }
                    
                }
            }
        }
           
        if (FoodSelected.currentFoods == 2)
        {
            if (HaveToast)
            {
                if (!butter.activeInHierarchy)
                {
                    butter.SetActive(true);
                    FoodSelected.Foods[2].GetComponent<ingridientSupply>().Spend();
                    FoodSelected.currentFoods = -1;
                    myPlace.GetComponent<plateGenerator>().ButterOn();
                }
            }
            else
            {
                if (HaveNoodles || HavePotatoes)
                {
                    //wrong ing
                    if (!subtitleSc.instComments.Contains(wrongIngredient))
                    {
                        subtitleSc.instComments.Add(wrongIngredient);
                        subtitleSc.Subtitles();
                    }
                    
                }
                else
                {
                    //no base
                    if (!subtitleSc.instComments.Contains(noBase))
                    {
                        subtitleSc.instComments.Add(noBase);
                        subtitleSc.Subtitles();
                    }
                    
                }
            }
        }
       
        if (FoodSelected.currentFoods == 6)
        {
            if (HaveNoodles || HavePotatoes)
            {
                if (!shroom.activeInHierarchy)
                {
                    shroom.SetActive(true);
                    FoodSelected.Foods[6].GetComponent<ingridientSupply>().Spend();
                    FoodSelected.currentFoods = -1;
                    myPlace.GetComponent<plateGenerator>().ShroomOn();
                }
            }
            else
            {
                if (HaveToast)
                {
                    //wrong ing

                    if (!subtitleSc.instComments.Contains(wrongIngredient))
                    {
                        subtitleSc.instComments.Add(wrongIngredient);
                        subtitleSc.Subtitles();
                    }
                    
                }
                else
                {
                    //no base
                    if (!subtitleSc.instComments.Contains(noBase))
                    {
                        subtitleSc.instComments.Add(noBase);
                        subtitleSc.Subtitles();
                    }
                    
                }
            }
        }
        
        if (FoodSelected.currentFoods == 8 || FoodSelected.currentFoods == 4 || FoodSelected.currentFoods == 0 || FoodSelected.currentFoods == 5)
        {
            if (!subtitleSc.instComments.Contains(raw))
            {
                subtitleSc.instComments.Add(raw);
                subtitleSc.Subtitles();
            }
            
        }
        
    }

}
