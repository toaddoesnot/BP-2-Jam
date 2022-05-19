using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dishwasher : MonoBehaviour
{
    public Cookers CookersScr;
    public GameObject PotItem;

    public GameObject scrapToast;
    public GameObject scrapRamen;

    public Inventory inventory;
    public GameObject inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryManager.GetComponent<Inventory>();
    }

    private void Update()
    {
        
    }


    void OnMouseDown()
    {
        PotItem = GameObject.FindGameObjectWithTag("Cooker");
        CookersScr = PotItem.GetComponent<Cookers>();

        scrapToast = GameObject.FindGameObjectWithTag("Toast");
        scrapRamen = GameObject.FindGameObjectWithTag("Noodles");

        if (CookersScr.Selected)
        {
            Object.Destroy(PotItem);
        }

        if (inventory.ToastCooked)
        {
            Object.Destroy(scrapToast);
            inventory.ToastCooked = false;
        }

        if (inventory.SpaghettiCooked)
        {
            Object.Destroy(scrapRamen);
            inventory.SpaghettiCooked = false;
        }

    }
}
