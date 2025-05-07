using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GainingScript : MonoBehaviour, IInteractable
{
    [SerializeField]Throwing throwingScript;
    public bool readyToTake = true;
    public float cooldown = 4f;
    private float currentCD = 0f;
    public void OnInteract()
    {
        Debug.Log("Interacting");
        if(readyToTake)
        {

        throwingScript.totalWaterBalls += 4;
        readyToTake = false;
        currentCD = cooldown;
        }
    }
    private void Update()
    {
        if (!readyToTake)
        {
            currentCD -= Time.deltaTime;

            if (currentCD < 0f)
            {
                readyToTake = true;
            }
        }

    }
}
