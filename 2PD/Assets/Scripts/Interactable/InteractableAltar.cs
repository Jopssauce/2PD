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
				Debug.Log ("OOOH Intersting Power");
				GetComponent<SpriteRenderer>().sprite = on;
			} 

			else
			{
				Debug.Log ("This is not for me but for other");
			}
			
		}
	}
	
}
