using System.Collections;
using System.Collections.Generic;
using Hertzole.GoldPlayer;
using UnityEngine;

public class MainCutscene : MonoBehaviour, IInteractable
{
    // Animator
    public Animator transition;

    // References
    public DialogueManager manager;
    public GoldPlayerController controller;
    public Throwing throwing;
    public GameObject player;
    public GameObject questTrigger5;
    public GameObject exitLocation;
    public GameObject teacherParent;
    public GameObject playerCamera;
    public GameObject cinematic;
    public GameObject cinematicTarget;

    // Transforms
    public Transform sittingLocation;
    public Transform lookPosition;
    public Transform lookPosition2;
    public Transform cinematicCameraPosition;
    public Transform originalLocation;
    public Transform exitLocationTransform;

    // Cutscene Triggers
    public GameObject cutscene1Trigger;
    public GameObject cutscene2Trigger;

    // State Bools
    public bool isSitting;
    public bool isInPosition;
    public bool cutscene1;
    public bool cutscene2;
    private bool hasStarted = false;
    private bool hasTeleported = false;
    private bool cutsceneFinished = false;

    public void OnInteract()
    {
        controller.enabled = false;
        throwing.enabled = false;
        player.transform.position = sittingLocation.position;
        isSitting = true;
        playerCamera.SetActive(false);
        cinematic.SetActive(true);
        cinematic.transform.LookAt(cinematicTarget.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        isInPosition = true;
        questTrigger5.SetActive(false);
    }

    private void Update()
    {
        if (cutsceneFinished) return;

        if (!manager.isDialogue && cutscene1 && cutscene2 && !hasStarted)
        {
            hasStarted = true;
            TriggerMainEvent();
        }
        else if (!manager.isDialogue && isInPosition && isSitting && cutscene1 && !cutscene2)
        {
            Cutscene2();
        }
        else if (!manager.isDialogue && isSitting && isInPosition && !cutscene2)
        {
            Cutscene1();
        }
    }

    private void TriggerMainEvent()
    {
        transition.SetTrigger("Sleep");
        cutsceneFinished = true;

        // Kill any leftover dialogue
        if (manager != null)
        {
            manager.EndDialogue();
            manager.isDialogue = false;
        }

        // Move cutscene triggers back to original location
        cutscene2Trigger.transform.position = originalLocation.position;

        // Destroy any NPC clones if needed
        GameObject[] humanClones = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject clone in humanClones)
        {
            Destroy(clone);
        }
        GameObject[] stoolClones = GameObject.FindGameObjectsWithTag("Stool");
        foreach (GameObject clone in stoolClones)
        {
            Destroy(clone);
        }

        // Show next scene location
        exitLocation.SetActive(true);
        teacherParent.SetActive(false);

        // Start scene change sequence
        Invoke(nameof(StopCutscene), 0.1f);
    }

    private void StopCutscene()
    {
        cutscene2Trigger.transform.position = originalLocation.position;
        cutscene1Trigger.transform.position = originalLocation.position;

        if (!hasTeleported)
        {
            hasTeleported = true;
            GameStart();
        }
    }

    private void Cutscene1()
    {
        if (cutsceneFinished) return;
        cutscene1Trigger.transform.position = player.transform.position;
    }

    private void Cutscene2()
    {
        
        if (cutsceneFinished) return;
        cutscene2Trigger.transform.position = player.transform.position;
    }

    private void GameStart()
    {
        player.transform.position = exitLocationTransform.position;
        playerCamera.SetActive(true);
        cinematic.SetActive(false);
        Debug.Log("Game started");
    }
}
