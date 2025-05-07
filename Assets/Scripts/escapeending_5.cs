using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.GoldPlayer;
using UnityEngine;

public class EscapeEnding : MonoBehaviour
{
    
    public GoldPlayerController controller;
    public Throwing throwing;
    public Transform continueGame;
    public Transform ED5transform;
    public GameObject player;
    public GameObject ED5;
    public GameObject ED5_Leave;
    public GameObject playerUI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the escape area.");
            
            Confirmation();
        }
    }

    private void Confirmation()
    {
        // Freeze player movement by disabling controls and throwing
        controller.enabled = false;
        throwing.enabled = false;

        // Show the "Leave" canvas for the escape decision
        ED5_Leave.SetActive(true);
        controller.Camera.LockCursor(false);
        Debug.Log("Showing the confirmation screen.");
    }

    public void Stay()
    {
        

        // Move player back to the original position and re-enable controls
        player.transform.position = continueGame.position;
        controller.enabled = true;
        throwing.enabled = true;
        controller.Camera.LockCursor(true);

        // Hide the confirmation canvas
        ED5_Leave.SetActive(false);
    }

    public void GoHome()
    {
        

        // Move player to the escape ending position and trigger the end scene
        player.transform.position = ED5transform.position;
        playerUI.SetActive(false);
        controller.enabled = false;
        throwing.enabled = false;

        // Hide the confirmation canvas and show the escape ending
        ED5_Leave.SetActive(false);
        ED5.SetActive(true);
    }

}
