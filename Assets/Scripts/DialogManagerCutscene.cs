using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    public SleepControl sleep;
    public GameObject dialogBox;
    public ChairInteract chair;
    public float typingSpeed = 0.2f;

    private Queue<DialogueLine> lines;
    public bool isDialogue;

    public GameObject sleepObj;
    public GameObject sleepObjDestination;

    public AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        dialogBox.SetActive(false);
        lines = new Queue<DialogueLine>();

        // Set up music source if not assigned in inspector
        if (musicSource == null)
        {
            GameObject musicObj = new GameObject("DialogueMusic");
            musicObj.transform.SetParent(transform);
            musicSource = musicObj.AddComponent<AudioSource>();
            musicSource.loop = false;
            musicSource.playOnAwake = false;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogBox.SetActive(true);
        isDialogue = true;

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isDialogue)
        {
            DisplayNextDialogueLine();
        }

    }
    private void FixedUpdate()
    {
        if (!isDialogue && chair.isSitting)
        {
            sleepObj.transform.position = sleepObjDestination.transform.position;   
        }
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";

        // Handle music playback
        if (dialogueLine.stopCurrentMusic && musicSource.isPlaying)
        {
            musicSource.Stop();
        }

        if (dialogueLine.playMusic && dialogueLine.musicClip != null)
        {
            musicSource.clip = dialogueLine.musicClip;
            musicSource.Play();
        }

        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue()
    {
        dialogBox.SetActive(false);
        isDialogue = false;
        sleep.SleepStart();
    }
}
