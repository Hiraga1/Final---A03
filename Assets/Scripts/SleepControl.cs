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
    public GameObject stool;
    public Transform[] malePositions;
    public Transform[] femalePositions;
    public Transform[] stoolPositions;
    public GameObject dialogTrigger1;
    public GameObject dialogTrigger2;
    public GameObject teacherParent;
    public Transform phoneLocation;
    public Transform studentCardLocation;
    public Transform jacketLocation;
    public GameObject NPC_Control;
    
    //Bools
    public bool playerInPosition;
    public bool playerReadyToSleep;
    bool hasSpawned;
   
    private void OnTriggerEnter(Collider other)
    {
        playerInPosition = true;
        Debug.Log("ready");
    }
    public void SleepStart()
    {
        playerReadyToSleep = true;
    }
    private void Update()
    {
        if (playerReadyToSleep && playerInPosition && manager.isDialogue == false)
        {
            Debug.Log("Sleep");
            Sleep();
        }
    }
    private void Sleep()
    {
        transition.SetTrigger("Sleep");
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
            foreach (Transform s in stoolPositions)
            {
                Instantiate(stool, s.position, s.rotation);
            }
            hasSpawned = true;
        }
        playerReadyToSleep = false;
        Invoke(nameof(WakeUp), 5f);
    }
    private void WakeUp()
    {
        dialogTrigger1.SetActive(true);
        dialogTrigger2.SetActive(true);
        transition.SetTrigger("WakeUp");
        chair.SitUp();
        questTrigger4.SetActive(true);
        teacherParent.SetActive(true);
        Invoke(nameof(DestroyChair), 1f);
        Instantiate(phone, phoneLocation.position, phoneLocation.rotation);
        Instantiate(studentCard, studentCardLocation.position, studentCardLocation.rotation);
        Instantiate(jacket, jacketLocation.position, jacketLocation.rotation);
        NPC_Control.SetActive(false);
        
    }

    private void DestroyChair()
    {
        Destroy(chair);
    }
}
