using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plateGenerator : MonoBehaviour
{
    public bool HasPlate;
    public GameObject plate;

    public GameObject myPlate;
    public GameObject self;

    public AudioSource myPlateSource;
    public AudioClip[] plateSounds;

    public dishwashingMachine dishSc;
    public GameObject reDisher;

    void Update()
    {
        if (!HasPlate)
        {
            reDisher.SetActive(true);
        }
        else
        {
            reDisher.SetActive(false);
            //GetComponent<Collider2D>().enabled = false;
        }
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
            
            GeneratePlate();
        }
    }

    public void GeneratePlate()
    {
        if (dishSc.recharges != 0)
        {
            if (HasPlate is false)
            {
                Instantiate(plate, transform.position, Quaternion.identity, this.transform);

                HasPlate = true;
            }
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
