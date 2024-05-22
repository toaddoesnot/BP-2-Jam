using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guestRandomizer : MonoBehaviour
{
    public Sprite[] heads;
    public Sprite[] bodies;

    public int body;
    public int type;

    public void RandomizeGuest()
    {
        body = Random.Range(0, bodies.Length);
    }
}
