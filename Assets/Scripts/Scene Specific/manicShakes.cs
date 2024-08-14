using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manicShakes : MonoBehaviour
{
    public GameObject camAnim;


    public void CanShakeS()
    {
        camAnim.GetComponent<Animation>().Play("evr_Small"); //evr_Big
    }
    public void CanShakeB()
    {
        camAnim.GetComponent<Animation>().Play("evr_Big");
    }
}
