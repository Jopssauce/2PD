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
		if(actor.skills.Any(item => item.ID == skill.ID) && !giveToSpecificPlayer) actor.AddSkill(skill);
		if(actor.skills.Any(item => item.ID == skill.ID) && giveToSpecificPlayer)
		{
			if (player.playerID == playerID)
			{
				actor.AddSkill(skill);
			}
			
		}
	}
	
}
