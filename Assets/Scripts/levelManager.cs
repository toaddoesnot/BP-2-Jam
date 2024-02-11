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

    public bool needRespawn;
    public int myScene;

    void Start()
    {
        handSc = GameObject.FindGameObjectWithTag("OrderManager").GetComponent<hand>();
    }

    void Update()
    {
        if (needRespawn)
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
        
        
    }

    public void NewLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelsUnlocked") + "unlocked");
        SceneManager.LoadScene(myScene);
    }

    public void Replay()
    {
        if (handSc.tutorialLvl is 1)
        {
            SceneManager.LoadScene(0);
        }
        if (handSc.tutorialLvl is 100)
        {
            SceneManager.LoadScene(0); //for now sample scene
        }
        //
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
