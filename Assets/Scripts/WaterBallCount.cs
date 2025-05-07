using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterBallCount : MonoBehaviour
{
    public Throwing throwing;
    public TextMeshProUGUI balls;
    public TextMeshProUGUI CD;

    private void Update()
    {
        balls.text = "x " + throwing.totalWaterBalls;
        if (throwing.readyToThrow)
        {
            CD.text = "Ready to throw";
        }
        else
        {
            CD.text = "Not ready to throw";
        }
    }
}
