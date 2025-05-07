using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    public float remainingTime;

    public bool survived;
    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            SurvivorEnding();
        }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = string.Format("{0:00}:{1:00}" , minutes, seconds);
    }

    public void SurvivorEnding()
    {
        survived = true;
    }
}
