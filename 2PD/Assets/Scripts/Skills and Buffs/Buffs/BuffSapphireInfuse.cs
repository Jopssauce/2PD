﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSapphireInfuse : BaseBuff 
{
    public GameObject sapphireArrow;
    GameObject temp;
    public override void Activate(BuffReceiver receiver)
    {
        base.Activate(receiver);
        receiver.GetComponent<SpriteRenderer>().color = color;
        ArcherCombat combat = receiver.GetComponent<ArcherCombat>();
        if (isActivated == true)
        {
            if(!receiver.GetComponent<ArcherCombat>()) return;
            temp = combat.objPrefab;
            combat.objPrefab = sapphireArrow;
            Debug.Log("Do" + this.name);
        }
         if (isActivated == false)
        {
            combat.objPrefab = temp;
            temp = null;
            Debug.Log("Undo" + this.name);
        }
    }
}
