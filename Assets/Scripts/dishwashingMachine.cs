using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dishwashingMachine : MonoBehaviour
{
    public int platesLeft;
    public GameObject[] places;

    public int recharges;
    public int maxRecharges; /////now 4 CHANGE TO 100

    public hand handSc;

    // Start is called before the first frame update
    void Start()
    {
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
        recharges = maxRecharges; 
        
    }

    public void Replate()
    {
        foreach (GameObject place in places)
        {
            place.GetComponent<plateGenerator>().GeneratePlate();
        }
    }

}
