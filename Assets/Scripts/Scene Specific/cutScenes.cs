using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class cutScenes : MonoBehaviour
{
    public int onStep;
    public TextMeshProUGUI instText;

    [TextArea(5, 10)]
    public List<string> instComments;

    public float typingSpeed;

    public GameObject spaceID;
    public GameObject nextB;
    public bool playing;

    public GameObject[] sounds;

    void Update()
    {
        if (playing)
        {
            nextB.GetComponent<Image>().color = new Color32(133, 133, 133, 255);
            nextB.GetComponent<Button>().enabled = false;
        }
        else
        {
            nextB.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            nextB.GetComponent<Button>().enabled = true;
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        if (!playing)
        {
            playing = true;
            if (onStep == 0)
            {
                StartCoroutine(DisplayLine());
            }
            else
            {
                if (onStep == 1)
                {
                    instText.text = "";
                    spaceID.SetActive(true);
                    onStep = 2;
                    StartCoroutine(WaitID());
                }
                else
                {
                    if (onStep == 2)
                    {
                        spaceID.SetActive(false);
                        StartCoroutine(DisplayLine());
                    }
                    else
                    {
                        if (onStep == 3)
                        {
                            instText.text = "";
                            StartCoroutine(DisplayLine());
                        }
                        else
                        {
                            if (onStep == 4)
                            {
                                SceneManager.LoadScene(3);
                            }
                        }
                    }
                }
            }
        }
        
    }

    IEnumerator WaitID()
    {
        yield return new WaitForSeconds(2f);

        playing = false;
    }

    IEnumerator DisplayLine()
    {
        yield return null;
        sounds[0].GetComponent<AudioSource>().Play();

        foreach (char letter in instComments[onStep].ToCharArray())
        {
            instText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        playing = false;

        if (onStep == 0 || onStep == 2 || onStep == 3)
        {
            onStep++;
        }
            
    }
}
