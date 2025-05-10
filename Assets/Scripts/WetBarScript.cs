using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WetBarScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxWetValue(int wetValue)
    {
        slider.maxValue = 100;
        slider.value = wetValue;
    }
    public void SetWetValue(int wetValue)
    {
        slider.value = wetValue;
    }
}
