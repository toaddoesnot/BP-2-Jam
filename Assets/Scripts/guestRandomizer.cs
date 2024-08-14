using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guestRandomizer : MonoBehaviour
{
    public Sprite[] heads;
    public Sprite[] bodies;

    public int body;
    public int type;

    public int emState;

    public int deprbody1;
    public int deprbody2;

    public int manbody1;
    public int manbody2;
    public int manbody3;

    void Start()
    {
        if (emState == 1)
        {
            heads[2] = heads[0];
        }
    }

    public void RandomizeGuest()
    {
        if (emState == 0) //norm
        {
            body = Random.Range(0, bodies.Length);
        }
        if (emState == 1 && type != 1) //depr
        {
            int[] optionsD = { deprbody1, deprbody2 };

            body = optionsD[Random.Range(0, optionsD.Length)];
        }
        if (emState == 2 && type != 1) //manic
        {
            int[] optionsM = { manbody1, manbody2, manbody3 };

            body = optionsM[Random.Range(0, optionsM.Length)];
        }
    }
}
