using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacterCutscene
{
    public string name;

}

[System.Serializable]
public class DialogueLineCutscene
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class DialogueCutscene
{
    public List<DialogueLine> dialogueLinesCutscene = new List<DialogueLine>();
}

public class DialogsTriggerCutscene : MonoBehaviour
{
    public DialogueCutscene Dialogue;


    public void TriggerDialogue()
    {
        DialogManagerCutscene.Instance.StartDialougeCutscene(Dialogue);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            TriggerDialogue();

        }
    }
}