using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class instructionalComments : MonoBehaviour
{
    public GameObject instBubble;
	public Sprite[] bubbles;
	public TextMeshProUGUI instText;

	[TextArea(5, 10)]
	public List<string> instComments;
    //QUIEING pUBLIC Queue<string> queueComments = new Queue<string>();

    public float typingSpeed;
	public string line;

	public bool playing;

	private float lastTipTime;
	public float minTimeBetweenTips = 1.5f;

	public GameObject typeSound;

	private bool changed;
	public GameObject selfNar;
	public GameObject choicesGroup;
	

	public void ChangePosition()
    {
        if (changed)
        {
			selfNar.transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
			changed = false;
		}
        else
        {
			selfNar.transform.localPosition = new Vector3(2350f, transform.localPosition.y, transform.localPosition.z); //2230 maybe need local
			changed = true;
		}
    }

	public void Subtitles()
    {
		if (!playing)
		{
            if (instBubble != null)
            {
                instBubble.SetActive(true);
            }
            StartCoroutine(DisplayLine());
        }
		else
		{
            StopAllCoroutines();
            instComments.RemoveAt(0);
            instText.text = "";
			playing = false;

            StartCoroutine(DisplayLine());
        }
        
        // if (Time.time - lastTipTime > minTimeBetweenTips)
        //{
        //	lastTipTime = Time.time;
        ///instComments.Enqueue("Your new subtitle here");
        //}
    }
	

	IEnumerator DisplayLine()
	{
		yield return null; //new WaitForSeconds(0.6f)

		if (!playing)
        {
			playing = true;
			instText.text = "";
			line = "";
			line = instComments[0];
            ///line = queueComments.Peek();

            foreach (char letter in instComments[0].ToCharArray())
			{
				instText.text += letter;
				yield return new WaitForSeconds(typingSpeed);
			}

			if (instText.text.Length == line.Length)
			{
				StartCoroutine(ExitSubtitles());
			}
		}
		
	}

    IEnumerator ExitSubtitles()
    {
		yield return new WaitForSeconds(1f);
		playing = false;

		yield return new WaitForSeconds(1.5f);
		instComments.RemoveAt(0);
        ////queueComments.Dequeue();

        instText.text = "";
		line = "";

		if (instComments.Count > 0)
		{
			StartCoroutine(DisplayLine());
			
		}
        else
        {
			if(instBubble != null)
			{
				instBubble.GetComponent<Animation>().Play("bubbleUnPop");
				yield return new WaitForSeconds(0.3f);
				instBubble.SetActive(false);
			}
		}
	}

	public void BranchingEnter()
    {
		instBubble.SetActive(false);
		choicesGroup.GetComponent<Animation>().Play("stopBranch");
	}
}
