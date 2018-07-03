using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractableAltar : Interactable
{
	public BaseSkill skill;
	public bool giveToSpecificPlayer;
	public int playerID;

	public Sprite off;
	public Sprite on;

	[SerializeField]
	private string ObtainedDialogue;

	[SerializeField]
	private string UnobtainedDialogue;

	[SerializeField]
	private int encyclopediaIndex;

	private UIManager uiManager;

	void Start()
	{
		uiManager = UIManager.instance;
	}

	public override void Interact(GameObject obj)
	{
		PlayerController player = obj.GetComponent<PlayerController>();
		SkillActor actor = player.GetComponent<SkillActor>();
		Debug.Log(actor);
		if(!actor.skills.Any(item => item.ID == skill.ID) && !giveToSpecificPlayer) actor.AddSkill(skill);
		if(!actor.skills.Any(item => item.ID == skill.ID) && giveToSpecificPlayer)
		{
			if (player.ID == playerID)
			{
				actor.AddSkill (skill);
				ShowDialogue (ObtainedDialogue);
				uiManager.CanvasUI.encyclopedia.GetComponent<EncyclopediaUI> ().UnlockGemContent (encyclopediaIndex);
				GetComponent<SpriteRenderer>().sprite = on;
			} 

			else
			{
				ShowDialogue (UnobtainedDialogue);
			}
			
		}
	}

	void ShowDialogue(string dialogue)
	{
		uiManager.CanvasUI.dialogueBox.SetActive (true);
		uiManager.CanvasUI.dialogue.text = dialogue;
		StartCoroutine (uiManager.CanvasUI.HideDialogue ());
	}
	
}
