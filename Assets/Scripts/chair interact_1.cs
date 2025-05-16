using System.Collections;
using System.Collections.Generic;
using Hertzole.GoldPlayer;
using Unity.VisualScripting;
using UnityEngine;

public class ChairInteract : MonoBehaviour, IInteractable
{
    public Transform sittingLocation;
    public Transform exitLocation;
    public Transform lookLocation;

    public GameObject player;
    public GameObject playerCamera;
    public GameObject cinematicCamera;
    public GoldPlayerController controller;
    public Throwing throwing;
    public SleepControl sleepControl;

    public bool isSitting;
    
    public void OnInteract()
    {
        controller.enabled = false;
        throwing.enabled = false;
        player.transform.position = sittingLocation.position;
        isSitting = true;
        playerCamera.SetActive(false);
        cinematicCamera.SetActive(true);
        cinematicCamera.transform.LookAt(lookLocation);
    }
    public void EnableMovement()
    {
        controller.enabled = true;
        throwing.enabled = true;    
    }
    private void Update()
    {
        if (isSitting && Input.GetKeyDown(KeyCode.Q))
        {
            SitUp();
            
        }
    }
    public void SitUp()
    {
        isSitting = false;
        sleepControl.playerInPosition = false;
        player.transform.position = exitLocation.position;
        Invoke(nameof(EnableMovement), 0.2f);
        Vector3 euler = transform.eulerAngles;
        cinematicCamera.SetActive(false);
        playerCamera.SetActive(true);
    }
}
