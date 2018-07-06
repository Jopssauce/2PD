using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEventHandler : MonoBehaviour
{
	UIManager uiManager;

	void Start()
	{
		uiManager = UIManager.instance;
	}

	public void ActivateDialogue(string dialogue)
	{
		uiManager.ActivateDialogue (dialogue);
	}


	public void UnlockGemContent(int index)
	{
		uiManager.CanvasUI.GetComponent<CanvasController> ().encyclopedia.GetComponent<EncyclopediaUI> ().UnlockGemContent (index);
	}
}
