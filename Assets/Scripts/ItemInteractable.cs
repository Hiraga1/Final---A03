using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractablePhone : MonoBehaviour, IInteractable
{
    public PlayerHealthScript itemsManager;
    public DialogsTrigger dialogs;
    public Transform playerTransform;
   
    public void OnInteract()
    {
        transform.position = playerTransform.position;
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            
                dialogs.TriggerDialogue();
                Destroy(this.gameObject);
            
        }
    }
}
