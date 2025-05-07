using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoalGateKeep : MonoBehaviour
{
    public GameObject questWindow;
    public QuestTrigger quest;
    public PlayerHealthScript itemManager;
    public DialogsTrigger dialog;

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Player"))
        {
        if (itemManager.phoneChecked && itemManager.studentCard && itemManager.jacket)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            dialog.TriggerDialogue();
        }

        }
    }
}
