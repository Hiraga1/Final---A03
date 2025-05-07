using System.Collections;
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
    public DialogueCharacterCutscene character;
    [TextArea(3, 10)]
    public string line;
}
[System.Serializable]
public class DialogueCutscene
{
    public List<DialogueLineCutscene> lines1 = new List<DialogueLineCutscene>(); 
}
public class DialogTriggerCutscene : MonoBehaviour
{
    public DialogueCutscene dialogue1;

    public bool isCutscene;
    public void TriggerCutsceneDialog()
    {
        DialogManagerCutscene.Instance.StartDialougeCutscene(dialogue1);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isCutscene = true;
            TriggerCutsceneDialog();

        }
    }
}
