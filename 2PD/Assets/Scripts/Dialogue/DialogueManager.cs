using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
	public Queue<string> Sentences;

	// Use this for initialization
	void Start () 
	{
		Sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		Debug.Log (dialogue.Name);
		Sentences.Clear ();

		foreach (string sentence in dialogue.DialogueText)
		{
			Sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence()
	{
		if (Sentences.Count == 0) 
		{
			EndDialogue ();
			return;
		}

		string sentence = Sentences.Dequeue ();
		Debug.Log (sentence);
	}

	public void EndDialogue()
	{
		Debug.Log ("End");
	}
}
