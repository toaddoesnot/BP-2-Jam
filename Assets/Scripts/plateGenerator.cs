using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateGenerator : MonoBehaviour
{
    public bool HasPlate;
    public GameObject plate;

    public GameObject myCoaster;
    public GameObject myPlate;
    public GameObject self;

    public AudioSource myPlateSource;
    public AudioClip[] plateSounds;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlate();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            myPlate = collision.gameObject;
            myPlate.GetComponent<FoodButtonClick>().myPlace = self;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            Destroy(collision);
            myPlate = null;
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

    public void PastaOn()
    {
        myPlateSource.PlayOneShot(plateSounds[0]);
    }
    public void ToastOn()
    {
        myPlateSource.PlayOneShot(plateSounds[1]);
    }
    public void ButterOn()
    {
        myPlateSource.PlayOneShot(plateSounds[2]);
    }
    public void CherryOn()
    {
        myPlateSource.PlayOneShot(plateSounds[3]);
    }
    public void EggOn()
    {
        myPlateSource.PlayOneShot(plateSounds[4]);
    }
    public void ShroomOn()
    {
        myPlateSource.PlayOneShot(plateSounds[5]);
    }

}
