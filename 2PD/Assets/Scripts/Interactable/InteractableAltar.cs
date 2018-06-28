using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractableAltar : Interactable
{
	public BaseSkill skill;
	public bool giveToSpecificPlayer;
	public int playerID;
	public override void Interact(PlayerController player)
	{
		SkillActor actor = player.GetComponent<SkillActor>();
		Debug.Log(actor);
		if(!actor.skills.Any(item => item.ID == skill.ID) && !giveToSpecificPlayer) actor.AddSkill(skill);
		if(!actor.skills.Any(item => item.ID == skill.ID) && giveToSpecificPlayer)
		{
			if (player.ID == playerID)
			{
				actor.AddSkill (skill);
				Debug.Log ("OOOH Intersting Power");
			} 

			else
			{
				Debug.Log ("This is not for me but for other");
			}
			
		}
	}
	
}
