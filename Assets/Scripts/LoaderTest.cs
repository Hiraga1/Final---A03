using System.Collections;
using System.Collections.Generic;
using Hertzole.GoldPlayer;
using UnityEngine;

public class LoaderTest : MonoBehaviour
{
    public GoldPlayerController controller;
    public GameObject freeExplore;
    public GameObject player;

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && other.CompareTag("Player"))
        {
            controller.enabled = true;
            player.transform.position = freeExplore.transform.position;
        }
    }
}
