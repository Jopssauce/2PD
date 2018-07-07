using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffRubyInfuse : BaseBuff 
{
	public GameObject rubyLight;
	GameObject tempLight;
	public float damageModifier = 0.5f;
    public float tempModifier;

	public override void Activate(BuffReceiver receiver)
    {
        PlayerController player = receiver.GetComponent<PlayerController>();
        base.Activate(receiver);
        receiver.GetComponent<SpriteRenderer>().color = color;
        if (isActivated == true)
        {
			Vector3 playerPos = player.transform.position;
			if (rubyLight != null)
			{
				tempLight = Instantiate(rubyLight, new Vector3 (playerPos.x, playerPos.y, rubyLight.transform.position.z), rubyLight.transform.rotation, player.transform);
				//tempModifier = player.GetComponent<PlayerStats>().globalModifier;
            	//player.GetComponent<PlayerStats>().globalModifier = damageModifier;
			}
            Debug.Log("Do" + this.name);
        }
         if (isActivated == false)
        {
			Destroy(tempLight);
			//player.GetComponent<PlayerStats>().globalModifier = tempModifier;
            Debug.Log("Undo" + this.name);
        }
    }

}
