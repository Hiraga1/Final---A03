using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTriggerScript : MonoBehaviour
{
    public MainCutscene cutscene;
    public DialogueManager manager;
    public GameObject sideStory;
    public GameObject cinematic;
    public GameObject player;
    public bool isCutscene1Trigger = true; // Set this in Inspector
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            if (isCutscene1Trigger)
            {
                cutscene.cutscene1 = true;
                cutscene.cutscene1Trigger.SetActive(false);

                // Camera switch for Cutscene 1
                sideStory.SetActive(true);
                cinematic.SetActive(false);
                player.SetActive(false);
            }
            else
            {
                cutscene.cutscene2 = true;
                cutscene.cutscene2Trigger.SetActive(false);

                
            }

            
        }
    }
}
