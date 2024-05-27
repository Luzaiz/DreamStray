using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerDia : NpcDialogue
{
    public override void AfterEndDialog() 
    {
        gameObject.SetActive(false);
        //NextTrigger.SetActive(true);
        base.AfterEndDialog();
    }
}
