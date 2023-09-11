using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dateManager : MonoBehaviour
{
    public GameObject UIobj;

    public void Start()
    {
        //Time.timeScale = 0;
    }

    public void Update()
    {
       
    }

    public void StartGameTut()
    {
        //UIobj.SetActive(false);
        Time.timeScale = 1;
    }
}
