using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public TimeManager time;

    public GameObject schoolStart;

    private void Update()
    {
        if(time.hours == 13 && time.minutes == 30)
        {
            schoolStart.SetActive(true);
        }
    }
}
