using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderDisplayer : MonoBehaviour
{
    public GameObject mySpot;

    public GameObject myPerson;
    public orderGenerator personSc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myPerson = mySpot.GetComponent<characterSlot>().myPeep;
        personSc = myPerson.GetComponent<orderGenerator>();
    }

    public void MakeOrder()
    {
        if (personSc.randomOrder is 0)
        {
            //only take toast
        }
        if (personSc.randomOrder is 1)
        {
            //only take soup
        }
        if (personSc.randomOrder is 2)
        {
            //take toast AND soup
        }
    }
}
