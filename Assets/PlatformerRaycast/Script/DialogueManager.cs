using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI text;
    public Animator dialogueAnim;
    DialogueTrigger currentDialogue;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger)
    {
        currentDialogue = trigger;
        dialogueAnim.SetTrigger("Open");
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue(currentDialogue);
            return;
        }

        string sentence = sentences.Dequeue();
        text.text = sentence;
    }

    public void EndDialogue(DialogueTrigger trigger)
    {
        trigger.gameObject.SetActive(false);
        currentDialogue = null;
        dialogueAnim.SetTrigger("Close");
        FindObjectOfType<Player>().cannotMove = false;

    }

}
