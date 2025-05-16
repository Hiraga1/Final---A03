using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;

    public bool playMusic;
    public AudioClip musicClip;
    public bool stopCurrentMusic;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogsTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public SleepControl sleep;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            TriggerDialogue();
            sleep.playerReadyToSleep = false;
        }
    }
}