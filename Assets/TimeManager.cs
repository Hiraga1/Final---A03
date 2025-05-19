using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int minutes;
    [SerializeField] private Texture2D skyBoxDay;
    [SerializeField] private Texture2D skyBoxSunSet;
    [SerializeField] private Texture2D skyBoxNight;
    [SerializeField] private Texture2D skyBoxSunRise;
    public int Minutes
    { get { return minutes; } set { minutes = value; OnMinuteChange(value); } }


    public int hour;
    public int Hours
    { get { return hour; } set { hour = value; OnHoursChange(value); } }


    private float tempSecond;
    private void Update()
    {
        tempSecond += Time.deltaTime;
        if(tempSecond >= 1)
        {
            minutes += 1;
            tempSecond = 0;
        }
        Debug.Log(Hours);
        Debug.Log(Minutes);
    }
    private void OnMinuteChange(int value)
    {
        if(value >= 60)
        {
            Hours ++;
            minutes = 0;
        }
        if (Hours >= 24)
        {
            Hours = 0;
        }
       
    }
    private void OnHoursChange(int value)
    {
        if (value == 18)
        {
            StartCoroutine(LerpSkyBox(skyBoxDay, skyBoxSunSet, 10f));
        }
        if (value == 22)
        {
            StartCoroutine(LerpSkyBox(skyBoxSunSet, skyBoxNight, 10f));
        }
    }
    private IEnumerator LerpSkyBox(Texture2D a , Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0);
        for (float i = 0; i<time; i += Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture1", b);
    }
}
