using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestTrigger : MonoBehaviour
{

    public Quest quest;
    public GameObject questGoal;
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    
    public GameObject prevQuestGoal;

    public void OpenQuestWindow()
    {
        quest.isActive = true;
        questWindow.SetActive(true);
        titleText.text = quest.questTitle;
        descriptionText.text = quest.questDescription;
        questGoal.SetActive(true);
        prevQuestGoal.SetActive(false);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        OpenQuestWindow();
        
    }
}
