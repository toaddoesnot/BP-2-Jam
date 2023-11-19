using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public TimeManager managerSc;

    public float idleTimer;
    public float respawnTime;

    public hand handSc;
    public levelOne instLevels;

    void Start()
    {
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
    }

    void Update()
    {
        if (managerSc.timeOn)
        {
            if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
            {
                idleTimer += Time.deltaTime;

                if (idleTimer > respawnTime)
                {
                    Replay();
                    idleTimer = 0;
                }
            }
            else
            {
                idleTimer = 0;
            }
        }
        else
        {
            idleTimer = 0;
        }
        
    }

    public void NewLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel);
        }

        Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelsUnlocked") + "unlocked");
        SceneManager.LoadScene(1);
    }

    public void Replay()
    {
        if (handSc.tutorialLvl is 1)
        {
            instLevels.Ready2Close();
        }
        //SceneManager.LoadScene(0);
    }
}
