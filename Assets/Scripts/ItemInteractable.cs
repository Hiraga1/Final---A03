using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractablePhone : MonoBehaviour, IInteractable
{
    public PlayerHealthScript itemsManager;
    public GameObject phone;
    public DialogsTrigger dialogs;
    public Transform playerTransform;
    public GameObject questWindow;
    public void OnInteract()
    {

        itemsManager.phoneChecked = true;
        transform.position = playerTransform.position;
        questWindow.SetActive(false);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {

            dialogs.TriggerDialogue();
            Destroy(gameObject);
        }
    }
}
