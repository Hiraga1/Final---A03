using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainingScriptSuper : MonoBehaviour
{
    [SerializeField] Throwing throwingScript;
    public bool readyToTake = true;
    public float cooldown = 0f;
    public float baseCD = 2f;
    private void Start()
    {
        cooldown = baseCD;
    }
    public void OnInteract()
    {
        Debug.Log("Interacting");
        if (readyToTake)
        {

            throwingScript.totalWaterBalls += 4;
            readyToTake = false;
            cooldown = baseCD;
        }
    }
    private void Update()
    {
        if (!readyToTake)
        {
            cooldown -= Time.deltaTime;

            if (cooldown < 0f)
            {
                readyToTake = true;
            }
        }

    }
}
