using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dishwasher : MonoBehaviour
{
    public Cookers CookersScr;
    public GameObject PotItem;

    private void Update()
    {
        
    }


    void OnMouseDown()
    {
        PotItem = GameObject.FindGameObjectWithTag("Cooker");
        CookersScr = PotItem.GetComponent<Cookers>();
        if (CookersScr.Selected)
        {
            Object.Destroy(PotItem);
        }
    }
}
