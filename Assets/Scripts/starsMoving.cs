using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starsMoving : MonoBehaviour
{
    public Animation animationComponent;
    public string animation1Name = "Animation1Name"; // Replace with the actual name of your first animation clip.
    public string animation2Name = "Animation2Name"; // Replace with the actual name of your second animation clip.

    private bool isAnimation1Playing = false;

    void Start()
    {
        PlayAnimation1();
    }

    void Update()
    {
        // Check if the first animation has finished playing.
        if (!isAnimation1Playing && !animationComponent.isPlaying)
        {
            // Switch to the second animation.
            PlayAnimation2();
        }
        // Check if the second animation has finished playing.
        else if (isAnimation1Playing && !animationComponent.isPlaying)
        {
            // Switch back to the first animation.
            PlayAnimation1();
        }
    }

    void PlayAnimation1()
    {
        isAnimation1Playing = true;
        animationComponent.Play(animation1Name);
    }

    void PlayAnimation2()
    {
        isAnimation1Playing = false;
        animationComponent.Play(animation2Name);
    }
}
