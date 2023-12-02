using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class redish : MonoBehaviour
{
    public plateGenerator myPlace;
    public hand inventory;
    public dishwashingMachine dishSc;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
    }

    public void OnMouseDown()
    {
        if (inventory.haveOrder)
        {
            //inventory.haveOrder = false;
            //dishSc.recharges++;

            //myPlace.GeneratePlate();
            
            StartCoroutine(returningDish());
        }

    }

    public IEnumerator returningDish()
    {
        
        yield return null;
        //Instantiate(myPlace.plate, transform.position, Quaternion.identity, myPlace.self.transform);
        myPlace.ForceGenerate();

        
        

        yield return new WaitForSeconds(2f);
        
        myPlace.myPlate.GetComponent<FoodButtonClick>().ghostPlate = false;
        //
    }
}
