using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalSystem : MonoBehaviour
{
    public GameObject flagIcon;
    public GameObject tickIcon;

    public Slider moneySlider;
    public float goalAmount;
    public float currentMoney;

    public bool goalAchieved;

    /// ////// public menuButton menuSc; public int moneyLeft; 

    // Start is called before the first frame update
    void Start()
    {
        goalAchieved = false;
        moneySlider.maxValue = goalAmount;
        moneySlider.value = 0;  

        flagIcon.SetActive(true);
        tickIcon.SetActive(false);
    }

    public void AddToGoal()
    {
        moneySlider.value = currentMoney; // Update the slider value

        // Check if the goal is reached
        if (currentMoney >= goalAmount)
        {
            GoalCompleted(); // Call the function to handle goal completion
        }
    }


    void GoalCompleted()
    {
        flagIcon.SetActive(false);
        tickIcon.SetActive(true);
        
        goalAchieved = true;
    }
}
