using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedSpaghetti : MonoBehaviour
{
    public bool RamenCooked;
    public GameObject Ramen;

    void OnMouseDown()
    {
        RamenCooked = true;
        Ramen.SetActive(false);
    }
}
