using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHealOvertime : BaseBuff 
{
	public float effectInterval = 1;
	public float heal = 2;

	public override void Activate(BuffReceiver receiver)
    {
       
        PlayerController player = receiver.GetComponent<PlayerController>();
        base.Activate(receiver);
        if (isActivated == true)
        {
			StartCoroutine(OvertimeEffect(receiver));
            Debug.Log("Do" + this.name);
        }
         if (isActivated == false)
        {
			StopCoroutine(OvertimeEffect(receiver));
			StopCoroutine(Duration(receiver));
            Debug.Log("Undo" + this.name);
        }
    }

	public IEnumerator OvertimeEffect(BuffReceiver receiver)
	{
		StartCoroutine(Duration(receiver));
		while(true)
		{
			receiver.GetComponent<Health>().AddHp(heal);
			yield return new WaitForSeconds(effectInterval);		
		}
		
	}

	public IEnumerator Duration(BuffReceiver receiver)
	{
		yield return new WaitForSeconds(duration);
		StopCoroutine(OvertimeEffect(receiver));	
	}
}
