using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedToast : MonoBehaviour
{
    public bool ToastCooked;
    public GameObject Toast;

    void OnMouseDown()
    {
        ToastCooked = true;
        Toast.SetActive(false);
    }
}
