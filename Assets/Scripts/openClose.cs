using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openClose : MonoBehaviour
{
    public void OnPointerEnter()
    {
        this.GetComponent<Animation>().Play();
        print("I'm over");
    }
}
