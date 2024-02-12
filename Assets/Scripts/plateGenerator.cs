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
    private bool firstTime;

    public hand handSc;
    public bool tutorialed;
    public levelOne tutLvl;

    void Awake()
    {
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();

        if (handSc.tutorialLvl != 1)
        {
            GeneratePlate();
        }
    }

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
            if (!firstTime)
            {
                myPlate.GetComponent<FoodButtonClick>().ghostPlate = false;
                firstTime = true;
            }
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
        if (dishSc.recharges != 0) //!= 0
        {
            if(dishSc.recharges == 1)
            {

            }
            else
            {
                if (HasPlate is false)
                {
                    Instantiate(plate, transform.position, Quaternion.identity, this.transform);

                    HasPlate = true;
                }
            }
        }
    }

    public void ForceGenerate()
    {
        Instantiate(plate, transform.position, Quaternion.identity, this.transform);

        HasPlate = true;

        StartCoroutine(ForceCor());
        
    }

    IEnumerator ForceCor()
    {
        yield return new WaitForSeconds(0.1f);
        myPlate.GetComponent<FoodButtonClick>().ghostPlate = true;
        myPlate.GetComponent<FoodButtonClick>().OnPointerDown(null);
    }

    public void PastaOn()
    {
        myPlateSource.PlayOneShot(plateSounds[0]);
        if (tutorialed)
        {
            if (tutLvl.tutPhase == 6)
            {
                tutLvl.tutPhase = 7;
                tutLvl.lidSound.Play();
            }
            else
            {
                if (tutLvl.tutPhase == 8)
                {
                    tutLvl.tutPhase = 9;
                    tutLvl.lidSound.Play();
                }
            }
        }
            
    }
    public void ToastOn()
    {
        myPlateSource.PlayOneShot(plateSounds[1]);
        if (tutorialed)
        {
            if (tutLvl.tutPhase == 2)
            {
                tutLvl.tutPhase = 3;
                tutLvl.lidSound.Play();
            }
            else
            {
                if (tutLvl.tutPhase == 3)
                {
                    tutLvl.tutPhase = 4;
                    tutLvl.lidSound.Play();
                }
            }
        }
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
