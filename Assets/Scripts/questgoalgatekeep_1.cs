using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoalGateKeep : MonoBehaviour
{
    public GameObject questWindow;
    public GameObject questTrigger6;
    public PlayerHealthScript itemManager;
    public DialogsTrigger dialog;

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Player"))
        {
        if (itemManager.phoneChecked && itemManager.studentCard && itemManager.jacket)
        {
            this.gameObject.SetActive(false);
            questTrigger6.SetActive(true);
                questWindow.SetActive(false);
        }
        else
        {
            dialog.TriggerDialogue();
        }

        }
    }
}
