using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class InteractableChecker : MonoBehaviour 
{
	public List<Interactable> genericInteractable;

	public bool areAllInteracted;
	
	public UnityEvent EventOnAllInteracted;

	public bool checkAllInteracted()
	{
		if(genericInteractable.All(pad => pad.isInteracted == true)) 
		{
			areAllInteracted = true;
			EventOnAllInteracted.Invoke();
			return true;
		}
		areAllInteracted = false;
		return false;
	}
}
