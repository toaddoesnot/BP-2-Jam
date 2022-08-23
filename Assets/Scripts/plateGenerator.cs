using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateGenerator : MonoBehaviour
{
    public bool HasPlate;
    public GameObject plate;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlate();
    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            Destroy(collision); 
            HasPlate = false;
            
            //GeneratePlate();
        }
    }

    public void GeneratePlate()
    {
        if (HasPlate is false)
        {
            
            Instantiate(plate, transform.position, Quaternion.identity);

            HasPlate = true;
        }
        else
        {

        }
    }

}
