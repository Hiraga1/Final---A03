using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SleepControl : MonoBehaviour
{
    public Animator transition;

    //References
    public GameObject playerObj;
    public DialogueManager manager;
    public ChairInteract chair;   
    public GameObject questTrigger4;
    

    //Variables
    public GameObject phone;
    public GameObject studentCard;
    public GameObject jacket;
    public GameObject maleObject;
    public GameObject femaleObject;
    public Transform[] malePositions;
    public Transform[] femalePositions;
    public GameObject dialogTrigger4;
    public Transform triggerLocation;
    public Transform phoneLocation;
    public Transform studentCardLocation;
    public Transform jacketLocation;
    public GameObject NPC_Control;
    
    //Bools
    public bool playerInPosition;
    bool playerReadyToSleep;
    bool hasSpawned;
   
    private void OnTriggerEnter(Collider other)
    {
        playerInPosition = true;
        
    }
    public void SleepStart()
    {
        playerReadyToSleep = true;
    }
    private void Update()
    {
        if (playerReadyToSleep && playerInPosition && manager.isDialogue == false)
        {
            Sleep();
        }
    }
    private void Sleep()
    {
        transition.SetTrigger("Sleeping");
        if (!hasSpawned)
        {
            foreach (Transform m in malePositions)
            {
                Instantiate(maleObject, m.position, m.rotation);
            }
            foreach (Transform f in femalePositions)
            {
                Instantiate(femaleObject, f.position, f.rotation);
            }
            hasSpawned = true;
        }
        playerReadyToSleep = false;
        Invoke(nameof(WakeUp), 5f);
    }
    private void WakeUp()
    {
        dialogTrigger4.transform.position = triggerLocation.position;
        transition.SetTrigger("Waking UP");
        chair.SitUp();
        questTrigger4.SetActive(true);
        NPC_Control.SetActive(false);
        Invoke(nameof(DestroyChair), 1f);
        Instantiate(phone, phoneLocation.position, phoneLocation.rotation);
        Instantiate(studentCard, studentCardLocation.position, studentCardLocation.rotation);
        Instantiate(jacket, jacketLocation.position, jacketLocation.rotation);
       
        
    }

    private void DestroyChair()
    {
        Destroy(chair);
    }
}
