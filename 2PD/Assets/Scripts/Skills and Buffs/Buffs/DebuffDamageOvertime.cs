﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDamageOvertime : BaseBuff 
{
 	public float effectInterval = 0.4f;
	public float damage = 8;

	public override void Activate(BuffReceiver receiver)
    {
       
        PlayerController player = receiver.GetComponent<PlayerController>();
        base.Activate(receiver);
        if (isActivated == true)
        {
			StartCoroutine(OvertimeEffect(receiver));
			StartCoroutine(Duration(receiver));
            Debug.Log("Do" + this.name);
        }
         if (isActivated == false)
        {
			StopCoroutine(OvertimeEffect(receiver));
			StopCoroutine(Duration(receiver));
			receiver.RemoveBuff(this);
            Debug.Log("Undo" + this.name);
        }
    }

	public IEnumerator OvertimeEffect(BuffReceiver receiver)
	{

		while(true)
		{
			if (receiver.GetComponent<Health>().fireModifier > 0)
			{
				receiver.GetComponent<Health>().DeductHpWhileInvulnerable(damage);
			}
			yield return new WaitForSeconds(effectInterval);		
		}
		
	}

	public IEnumerator Duration(BuffReceiver receiver)
	{
		yield return new WaitForSeconds(duration);
		StopCoroutine(OvertimeEffect(receiver));
		Deactivate(receiver);
		receiver.RemoveBuff(this);	
	}

}
