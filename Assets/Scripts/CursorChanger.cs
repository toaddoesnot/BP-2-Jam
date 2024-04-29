using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorDefault2;
    private Camera _cam;
    public AudioClip _clickClip;
    public GameObject curAnim;

    public GameObject[] Cursors;

    public FoodClasses FoodClassSc;
    public Inventory inventorySc;
    public GameObject foods;

    public hand handSc;

    public bool nothingSelected;

    void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware); /////////////
        _cam = Camera.main;

        //Cursor.visible = false;
        FoodClassSc = foods.GetComponent<FoodClasses>();

        foreach (GameObject cur in Cursors)
        {
            cur.SetActive(false);
        }
        nothingSelected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioSource.PlayClipAtPoint(_clickClip, _cam.transform.position);
            Cursor.SetCursor(cursorDefault2, Vector2.zero, CursorMode.ForceSoftware);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
        }
        



        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursorPos2d = new Vector3(cursorPos.x, cursorPos.y, 1);
        foreach (GameObject cur in Cursors)
        {
            cur.transform.position = cursorPos2d;
        }

        CheckSelectionStatus();

        if (FoodClassSc.currentFoods is -1)
        {
            if (inventorySc.SpaghettiCooked)
            {
                if (inventorySc.sthBurnt)
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[20].SetActive(true);
                    }
                }
                else
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[4].SetActive(true);
                    }
                }
                
            }

            if (inventorySc.ToastCooked)
            {
                if (inventorySc.sthBurnt)
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[21].SetActive(true);
                    }
                }
                else
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[10].SetActive(true);
                    }
                }
            }

            if (inventorySc.PotatoCooked)
            {
                if (inventorySc.sthBurnt)
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[19].SetActive(true);
                    }
                }
                else
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[18].SetActive(true);
                    }
                }
            }

            if (inventorySc.EggCooked)
            {
                if (inventorySc.sthBurnt)
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[22].SetActive(true);
                    }
                }
                else
                {
                    foreach (GameObject cur in Cursors)
                    {
                        cur.SetActive(false);
                        Cursors[1].SetActive(true);
                    }
                }
            }

            if (inventorySc.havePlate)
            {
                foreach (GameObject cur in Cursors)
                {
                    cur.SetActive(false);
                    Cursors[3].SetActive(true);
                }
            }

            if (foods.GetComponent<drinkManager>().HasReadyCoffee)
            {
                foreach (GameObject cur in Cursors)
                {
                    cur.SetActive(false);
                    Cursors[13].SetActive(true);
                }
            }

            if (foods.GetComponent<drinkManager>().HasReadySoda)
            {
                foreach (GameObject cur in Cursors)
                {
                    cur.SetActive(false);
                    Cursors[14].SetActive(true);
                }
            }

            if (foods.GetComponent<drinkManager>().HasReadyOJ)
            {
                foreach (GameObject cur in Cursors)
                {
                    cur.SetActive(false);
                    Cursors[15].SetActive(true);
                }
            }

            if (handSc.haveOrder)
            {
                foreach (GameObject cur in Cursors)
                {
                    cur.SetActive(false);
                    Cursors[16].SetActive(true);
                }
            }

            if (handSc.haveOrder is false && inventorySc.havePlate is false && inventorySc.sthCooked is false && foods.GetComponent<drinkManager>().HasSthReady is false)
            {
                foreach (GameObject cur in Cursors)
                {
                    cur.SetActive(false);
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

        if (FoodClassSc.currentFoods is 8)
        {
            foreach (GameObject cur in Cursors)
            {
                cur.SetActive(false);
                Cursors[17].SetActive(true);
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

    void CheckSelectionStatus()
    {
        nothingSelected = true;

        for (int i = 0; i < Cursors.Length; i++)
        {
            if (Cursors[i].activeInHierarchy)
            {
                nothingSelected = false;
                break;
            }
        }
        //CursorChangerSc.Cursors[1].SetActive(true);
    }

}
