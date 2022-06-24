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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            HasPlate = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            HasPlate = false;
            GeneratePlate();
        }
    }

    public void GeneratePlate()
    {
        Instantiate(plate, transform.position, Quaternion.identity);
    }

}
