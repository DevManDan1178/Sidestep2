using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelBar : MonoBehaviour
{
    
    public Image timeBar;
    public Slider timeSlider;
    public Gradient timeGradient;
    public void SetMaxTime(int maxTime)
    {
        timeSlider.maxValue = maxTime;
        timeSlider.value = maxTime;
    }

    public void SetTime(int time)
    {
        timeSlider.value = time;
        timeBar.color = timeGradient.Evaluate(timeSlider.normalizedValue);
    }

}
