using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public bool ToastCooked;
    public bool SpaghettiCooked;
    public bool sthCooked;
    public bool havePlate;

    public int OrderStatus;
    public int HowManyOrds;

    //public TextMeshProUGUI orderText;


    // Start is called before the first frame update
    void Start()
    {
        //orderText.text = HowManyOrds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (ToastCooked is true)
        {
            sthCooked = true;
        }
        else
        {
            if (SpaghettiCooked is true)
            {
                sthCooked = true;
            }
            else
            {
                if (ToastCooked is false)
                {
                    sthCooked = false;
                }
                else
                {
                    if (SpaghettiCooked is false)
                    {
                        sthCooked = false;
                    }
                }
            }
        }

        if (havePlate)
        {
            
        }

    }

    public void AddOrder()
    {
        //orderText.text = HowManyOrds.ToString();
    }
}
