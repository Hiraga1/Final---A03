using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.GoldPlayer;
using UnityEditor;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    //Scripts
    public GoldPlayerController controller;
    public Throwing throwing;
    //GameObjects
    
    public GameObject tutorialScreen;
    public GameObject player;
    //Enabler
    public GameObject enemy;
    public GameObject stockBuckets;
    public GameObject timer;
    public GameObject escape;

    //Mics
    public Animator transition;

    //Variables
    public PlayerHealthScript healthScript;
    public Timer timerScript;
    public Expelled expelledScript;
    public EscapeEnding escapeScript;

    //ED Scenes
    public GameObject ED1;
    public Transform ED1transform;
    public GameObject ED2;
    public Transform ED2transform;
    public GameObject ED3;
    public Transform ED3transform;
    public GameObject ED4;
    public Transform ED4transform;
    private void OnTriggerEnter(Collider other)
    {
        

        WakingUpPlayer();

        Invoke(nameof(Enabler), 6f);

    }

    private void Enabler()
    {
        enemy.SetActive(true);
        stockBuckets.SetActive(true);
        timer.SetActive(true);
        escape.SetActive(true);
    }

    private void WakingUpPlayer()
    {
        
        transition.SetTrigger("WakeUp");
        controller.enabled = true;
        throwing.enabled = true;
        Invoke(nameof(Tutorial), 1f);

    }

    public void Tutorial()
    {
        tutorialScreen.SetActive(true);


    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            tutorialScreen.SetActive(false);
        }
        if (healthScript.unforgettableMemory)
        {
            controller.enabled = false;
            throwing.enabled = false;
            ED1.SetActive(true);
            player.transform.position = ED1transform.position;
            Cursor.lockState = CursorLockMode.None;
            timer.SetActive(false);
        }
        else



            if (timerScript.remainingTime == 0 && healthScript.playerWetLevel != healthScript.playerMaxWetLevel)
        {
            controller.enabled = false;
            throwing.enabled = false;
            ED2.SetActive(true);
            player.transform.position = ED2transform.position;
            Cursor.lockState = CursorLockMode.None;
            timer.SetActive(false);

        }
        else if (healthScript.apexStudent)
        {
            controller.enabled = false;
            throwing.enabled = false;
            ED3.SetActive(true);
            player.transform.position = ED3transform.position;
            Debug.Log("Apex Student Ending");
            Cursor.lockState = CursorLockMode.None;
            timer.SetActive(false);
        }
        else if (expelledScript.expelled)
        {
            controller.enabled = false;
            throwing.enabled = false;
            ED4.SetActive(true);
            player.transform.position = ED4transform.position;
            Debug.Log("Expelled Ending");
            Cursor.lockState = CursorLockMode.None;
            timer.SetActive(false);
        }

    }

}