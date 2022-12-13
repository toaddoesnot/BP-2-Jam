using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    //public Texture2D cursorDefault;
    // Start is called before the first frame update
    public GameObject[] Cursors;

    public FoodClasses FoodClassSc;
    public Inventory inventorySc;
    public GameObject foods;

    public hand handSc;

    void Start()
    {
        //Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
        Cursor.visible = false;
        FoodClassSc = foods.GetComponent<FoodClasses>();

        foreach (GameObject cur in Cursors)
        {
            cur.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (FoodClassSc.currentFoods is -1)
        {
            if (inventorySc.SpaghettiCooked)
            {
                foreach (GameObject cur in Cursors)
                {
                    cur.SetActive(false);
                    Cursors[4].SetActive(true);
                }
            }
            else
            {
                if (inventorySc.ToastCooked)
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[10].SetActive(true);
                    }
                }
                else
                {
                    if (inventorySc.havePlate)
                    {
                        foreach (GameObject cur in Cursors)
                        {
                            cur.SetActive(false);
                            Cursors[3].SetActive(true);
                        }
                    }
                    else
                    {
                        if (foods.GetComponent<drinkManager>().HasReadyCoffee)
                        {
                            foreach (GameObject cur in Cursors)
                            {
                                cur.SetActive(false);
                                Cursors[13].SetActive(true);
                            }
                        }
                        else
                        {
                            if (foods.GetComponent<drinkManager>().HasReadySoda)
                            {
                                foreach (GameObject cur in Cursors)
                                {
                                    cur.SetActive(false);
                                    Cursors[14].SetActive(true);
                                }
                            }
                            else
                            {
                                if (foods.GetComponent<drinkManager>().HasReadyOJ)
                                {
                                    foreach (GameObject cur in Cursors)
                                    {
                                        cur.SetActive(false);
                                        Cursors[15].SetActive(true);
                                    }
                                }
                                else
                                {
                                    if (handSc.haveOrder)
                                    {
                                        foreach (GameObject cur in Cursors)
                                        {
                                            cur.SetActive(false);
                                            Cursors[16].SetActive(true);
                                        }
                                    }
                                    else
                                    {
                                        foreach (GameObject cur in Cursors)
                                        {
                                            cur.SetActive(false);
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

        }

        if (FoodClassSc.currentFoods is 0)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[11].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 1)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[9].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 2)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[0].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 6)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[8].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 5)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[2].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 4)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[5].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 9)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[7].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 10)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[6].SetActive(true);
            }
        }

        if (FoodClassSc.currentFoods is 12)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[12].SetActive(true);
            }
        }


        //0 toast
        //1 straw
        //2 butter
        //6 shroom
        //5 egg
        //4 noodles
        //9 pot
        //10 toaster

        //currentFoods
    }

    //CursorChangerSc.Cursors[1].SetActive(true);
}
