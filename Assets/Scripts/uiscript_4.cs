using System.Collections;
using System.Collections.Generic;
using Hertzole.GoldPlayer;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
    public GameObject player;
    public Transform freeExplore;
    public GameObject enemyParent;
    public GameObject bucketParent;
    public GameObject freeExploreParent;
    public GameObject principle;
    public GoldPlayerController controller;
    public GameObject ED1_Canvas, ED2_Canvas, ED3_Canvas, ED4_Canvas, ED5_Canvas;
    public DialogueManager manager;
    public Animator transition;
    public GameObject clock, clock_manager;
    public GameObject creditsScreen;
    public GameObject mainScreen;
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Credits()
    {
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void FreeExplore()
    {
        
        EDSceneDisable();
        FreeExploreStart();
        DialogsDisable();
    }
    public void FreeExploreStart()
    {
        freeExploreParent.SetActive(true);
        principle.SetActive(false);
        player.transform.SetPositionAndRotation(freeExplore.position, Quaternion.identity);
        controller.enabled = true;
        controller.Camera.ShouldLockCursor = true;
        Destroy(enemyParent);
        Destroy(bucketParent);
        clock.SetActive(true);
        clock_manager.SetActive(true);
    }
    public void EDSceneDisable()
    {
        ED1_Canvas.SetActive(false);
        ED2_Canvas.SetActive(false);
        ED3_Canvas.SetActive(false);
        ED4_Canvas.SetActive(false);
        ED5_Canvas.SetActive(false);
    }
    public void DialogsDisable()
    {
        manager.EndDialogue();
    }
    public void Transition()
    {
        transition.SetTrigger("WakeUp");
    }
    public void Back()
    {
        creditsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
    
}
