using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool ToastCooked;
    public bool SpaghettiCooked;
    public bool sthCooked;
    public bool havePlate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ToastCooked)
        {
            sthCooked = true;
        }

        if (SpaghettiCooked)
        {
            sthCooked = true;
        }

        if (ToastCooked is false)
            {
                if (SpaghettiCooked is false)
                {
                    sthCooked = false;
                }
            }
        
        if (havePlate)
        {

        }

    }
}
