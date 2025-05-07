using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2TriggerScript : MonoBehaviour
{
    public MainCutscene cutscene;
    public DialogueManager manager;
    public GameObject sideStory;
    public GameObject cinematic;
    public GameObject cinematicTarget;
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
                
            }
            else
            {
                cutscene.cutscene2 = true;
                cutscene.cutscene2Trigger.SetActive(false);

                // Camera switch for Cutscene 2
                sideStory.SetActive(false);
                cinematic.SetActive(true);
                cinematic.transform.LookAt(cinematicTarget.transform.position);
                player.SetActive(false);
            }

            
        }
    }
}
