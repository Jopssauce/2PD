using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class IntroDialogue : MonoBehaviour
{
    public float timer = 5;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;
    [TextArea]
    public List<string> dialogue;
    IEnumerator startDialogue;
	public UnityEvent EventDialogueEnded;
    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue();
    }

    public void StartDialogue()
    {
        sentences.Clear();

        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        startDialogue = DisplayNextSentence();
        StartCoroutine(startDialogue);
    }

    public IEnumerator DisplayNextSentence()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            dialogueBox.SetActive(true);
            if (sentences.Count == 0)
            {
                EndDialogue();
				EventDialogueEnded.Invoke();
                yield break;
            }

            string sentence = sentences.Dequeue();
			StartCoroutine(TypeText(sentence));
        }

    }
	
	public IEnumerator TypeText(string text)
	{
		string display = "";
		foreach (char letter in text.ToCharArray())
		{
			//Use display to get dialogue letter per letter
			display += letter;
			 dialogueText.text = display;
			yield return new WaitForSeconds(0f);
		}
	}

    public void EndDialogue()
    {
        Debug.Log("End");
    }

}
