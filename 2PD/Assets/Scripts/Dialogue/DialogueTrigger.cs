using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue Dialogues;

	// Update is called once per frame
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager> ().StartDialogue (Dialogues);
	}
}
