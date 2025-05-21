using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractionCard : MonoBehaviour, IInteractable
{
    public PlayerHealthScript itemsManager;
    public GameObject card;
    public DialogsTrigger dialogs;
    public Transform playerTransform;
    public void OnInteract()
    {
        dialogs.TriggerDialogue();
        
        transform.position = playerTransform.position;
        Invoke(nameof(CardDisable), .1f);
    }
    void CardDisable()
    {
        card.SetActive(false);
    }
    
}
