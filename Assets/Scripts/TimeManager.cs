using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Texture2D skyboxNight;
    [SerializeField] private Texture2D skyboxSunrise;
    [SerializeField] private Texture2D skyboxDay;
    [SerializeField] private Texture2D skyboxSunset;

    [SerializeField] private Gradient graddientNightToSunrise;
    [SerializeField] private Gradient graddientSunriseToDay;
    [SerializeField] private Gradient graddientDayToSunset;
    [SerializeField] private Gradient graddientSunsetToNight;

    
    [SerializeField] private Light globalLight;
    [SerializeField] TextMeshProUGUI clock;

    bool triggerWhenStart;
   
    public int minutes;

    public int Minutes
    { get { return minutes; } set { minutes = value; OnMinutesChange(value); } }

    public int hours = 12;

    public int Hours
    { get { return hours; } set { hours = value; OnHoursChange(value); } }

    

    private float tempSecond;
    public void Start()
    {
        hours = 11;
        minutes = 59;
        triggerWhenStart = false;
    }
    public void Update()
    {
        tempSecond += Time.deltaTime;

        if (tempSecond >= 1)
        {
            Minutes += 1;
            tempSecond = 0;
        }
        clock.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }

    private void OnMinutesChange(int value)
    {
        globalLight.transform.Rotate(Vector3.up, (1f / (1440f / 4f)) * 360f, Space.World);
        if (value >= 60)
        {
            Hours++;
            minutes = 0;
        }
        if (Hours >= 24)
        {
            Hours = 0;
            
        }
    }

    private void OnHoursChange(int value)
    {
        if (value == 6)
        {
            StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, 10f));
            StartCoroutine(LerpLight(graddientNightToSunrise, 10f));
            globalLight.intensity = .75f;
        }
        else if (value == 8)
        {
            StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, 10f));
            StartCoroutine(LerpLight(graddientSunriseToDay, 10f));
            globalLight.intensity = 1f;
        }else if (value == 12 && !triggerWhenStart)
        {
            StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, .1f));
            StartCoroutine(LerpLight(graddientSunriseToDay, .1f));
            globalLight.intensity = 1f;
            triggerWhenStart = true;
        }
        else if (value == 17)
        {
            StartCoroutine(LerpSkybox(skyboxDay, skyboxSunset, 10f));
            StartCoroutine(LerpLight(graddientDayToSunset, 10f));
            globalLight.intensity = .75f;
            Debug.Log("Triggered");
        }
        else if (value == 18)
        {
            StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, 10f));
            StartCoroutine(LerpLight(graddientSunsetToNight, 10f));
            globalLight.intensity = .5f;
        }
    }

    private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0);
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture1", b);
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.color = lightGradient.Evaluate(i / time);
            
            yield return null;
        }
    }
    
}