using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
	UIManager uiManager;

	void Start()
	{
		uiManager = UIManager.instance;
	}

	public void ActivateDialogue(string dialogue)
	{
		uiManager.CanvasUI.GetComponent<CanvasController>().dialogueBox.SetActive (true);
		uiManager.CanvasUI.GetComponent<CanvasController>().dialogue.text = dialogue;
		StartCoroutine (uiManager.CanvasUI.HideDialogue ());
	}
}
