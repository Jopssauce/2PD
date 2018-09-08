using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEventHandler : MonoBehaviour
{
	GameManager gameManager;

	void Start()
	{
		gameManager = GameManager.instance;
	}

	public void ActivateDialogue(string dialogue)
	{
		gameManager.uiManager.ActivateDialogue (dialogue);
	}


	public void UnlockGemContent(int index)
	{
		gameManager.uiManager.CanvasUI.GetComponent<CanvasController> ().encyclopedia.GetComponent<EncyclopediaUI> ().UnlockGemContent (index);
	}

	public void CheckPointSet(bool state)
	{
		gameManager.uiManager.CanvasUI.GetComponent<CanvasController> ().checkpointAnim.ChangeAnimState (state);
		StartCoroutine (gameManager.uiManager.CanvasUI.GetComponent<CanvasController>().HideCheckpointNotif());
	}
}
