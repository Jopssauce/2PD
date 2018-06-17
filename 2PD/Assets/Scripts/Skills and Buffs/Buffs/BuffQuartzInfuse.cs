using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffQuartzInfuse : BaseBuff 
{
    
	public override void Activate(BuffReceiver receiver)
    {
        base.Activate(receiver);
        if (isActivated == true)
        {
            Debug.Log("Do" + this.name);
        }
         if (isActivated == false)
        {
            Debug.Log("Undo" + this.name);
        }
    }
}
