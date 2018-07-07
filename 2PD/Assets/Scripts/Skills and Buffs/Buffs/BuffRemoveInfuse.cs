using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffRemoveInfuse : BaseBuff
 {
     public override void Activate(BuffReceiver receiver)
     {
         base.Activate(receiver);
         receiver.GetComponent<SpriteRenderer>().color = color;
         
     }

}
