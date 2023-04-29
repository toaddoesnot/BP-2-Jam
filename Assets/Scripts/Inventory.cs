using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public bool ToastCooked;
    public bool SpaghettiCooked;
    public bool EggCooked;
    public bool PotatoCooked;

    public bool sthCooked;

    public bool havePlate;

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
        
        if (ToastCooked is true || SpaghettiCooked is true || EggCooked is true || PotatoCooked is true)
        {
            sthCooked = true;
        }
        else
        {
            sthCooked = false;
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
